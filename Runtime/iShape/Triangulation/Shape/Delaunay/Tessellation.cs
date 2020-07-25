using System;
using iShape.Collections;
using iShape.Geometry;
using Unity.Collections;
using UnityEngine;

namespace iShape.Triangulation.Shape.Delaunay {

    public static class Tessellation {
        
        public static NativeArray<Vertex> Tessellate(ref this Delaunay self, float maxAngle, long minEdge, Allocator allocator) {
            if (0.5f * Mathf.PI > maxAngle || maxAngle > Mathf.PI) {
                return new NativeArray<Vertex>(0, allocator);
            }

            var extraPoints = new DynamicArray<Vertex>(16, allocator);
            int extraPointsIndex = self.pathCount + self.extraCount;

            int i = 0;

            float maxCos = Mathf.Cos(maxAngle);
            float sqrCos = maxCos * maxCos;
            long sqrMinEdge = minEdge * minEdge;
            
            var triangles = new DynamicArray<Triangle>(self.triangles, allocator);
            var indices = new NativeArray<int>(4, Allocator.Temp);
            
            while (i < triangles.Count) {
                var triangle = triangles[i];

                var a = triangle.vA;
                var b = triangle.vB;
                var c = triangle.vC;

                long ab = a.point.SqrDistance(b.point);
                long ca = c.point.SqrDistance(a.point);
                long bc = b.point.SqrDistance(c.point);

                if (ab < sqrMinEdge && ca < sqrMinEdge && bc < sqrMinEdge) {
                    i += 1;
                    continue;
                }

                int k;
                float aa = bc;
                float bb = ca;
                float cc = ab;
                float sCos;

                if (ab >= bc + ca) {
                    // c, ab
                    k = 2;
                    float lc = aa + bb - cc;
                    sCos = lc * lc / (4 * aa * bb);
                } else if (bc >= ca + ab) {
                    // a, bc
                    k = 0;
                    float la = bb + cc - aa;
                    sCos = la * la / (4 * bb * cc);
                } else if (ca >= bc + ab) {
                    // b, ca
                    k = 1;
                    float lb = aa + cc - bb;
                    sCos = lb * lb / (4 * aa * cc);
                } else {
                    i += 1;
                    continue;
                }

                int j = triangle.Neighbor(k);
                if (j < 0 || sCos < sqrCos) {
                    i += 1;
                    continue;
                }

                var p = triangle.CircumscribedCenter();
                var neighbor = triangles[j];

                if (!neighbor.IsContain(p)) {
                    i += 1;
                    continue;
                }

                int k_next = (k + 1) % 3;
                int k_prev = (k + 2) % 3;

                int l = neighbor.Opposite(i);

                int l_next = (l + 1) % 3;
                int l_prev = (l + 2) % 3;

                var vertex = new Vertex(extraPointsIndex, p);
                extraPoints.Add(vertex);

                int n = triangles.Count;
                extraPointsIndex += 1;

                var t0 = triangle;
                t0.SetVertex(k_prev, vertex);
                t0.SetNeighbor(k_next, n);
                triangles[i] = t0;

                var t1 = neighbor;
                t1.SetVertex(l_next, vertex);
                t1.SetNeighbor(l_prev, n + 1);
                triangles[j] = t1;

                int t2Neighbor = triangle.Neighbor(k_next);
                var t2 = new Triangle(
                    n,
                    triangle.Vertex(k),
                    vertex,
                    triangle.Vertex(k_prev),
                    n + 1,
                    t2Neighbor,
                    i
                );

                if (t2Neighbor >= 0) {
                    var t2n = triangles[t2Neighbor];
                    t2n.UpdateOpposite(i, n);
                    triangles[t2Neighbor] = t2n;
                }

                triangles.Add(t2);

                var t3Neighbor = neighbor.Neighbor(l_prev);
                var t3 = new Triangle(
                    n + 1,
                    neighbor.Vertex(l),
                    neighbor.Vertex(l_next),
                    vertex,
                    n,
                    j,
                    t3Neighbor
                );

                if (t3Neighbor >= 0) {
                    var t3n = triangles[t3Neighbor];
                    t3n.UpdateOpposite(j, n + 1);
                    triangles[t3Neighbor] = t3n;
                }

                triangles.Add(t3);
                
                indices[0] = i;
                indices[1] = j;
                indices[2] = n;
                indices[3] = n + 1;
                
                int minIndex = Delaunay.Fix(ref triangles, indices);
                
                if (minIndex < i) {
                    i = minIndex;
                }
            }

            indices.Dispose();
            
            if (extraPoints.Count > 0) {
                self.triangles.Dispose();
                self.triangles = triangles.Convert();
                self.extraCount += extraPoints.Count;
            }

            return extraPoints.Convert();
        }
    }


    internal static class TessellationExt {
        internal static IntVector CircumscribedCenter(this Triangle self) {
            var a = self.vA.point;
            var b = self.vB.point;
            var c = self.vC.point;
            double ax = a.x;
            double ay = a.y;
            double bx = b.x;
            double by = b.y;
            double cx = c.x;
            double cy = c.y;

            double d = 2 * (ax * (by - cy) + bx * (cy - ay) + cx * (ay - by));
            double aa = ax * ax + ay * ay;
            double bb = bx * bx + by * by;
            double cc = cx * cx + cy * cy;
            double x = (aa * (by - cy) + bb * (cy - ay) + cc * (ay - by)) / d;
            double y = (aa * (cx - bx) + bb * (ax - cx) + cc * (bx - ax)) / d;

            return new IntVector((long) Math.Round(x, MidpointRounding.AwayFromZero), (long) Math.Round(y, MidpointRounding.AwayFromZero));
        }

        internal static bool IsContain(this Triangle self, IntVector p) {
            var a = self.vA.point;
            var b = self.vB.point;
            var c = self.vC.point;

            var d1 = Sign(p, a, b);
            var d2 = Sign(p, b, c);
            var d3 = Sign(p, c, a);

            bool has_neg = d1 < 0 || d2 < 0 || d3 < 0;
            bool has_pos = d1 > 0 || d2 > 0 || d3 > 0;

            return !(has_neg && has_pos);
        }

        private static long Sign(IntVector a, IntVector b, IntVector c) {
            return (a.x - c.x) * (b.y - c.y) - (b.x - c.x) * (a.y - c.y);
        }
    }

}