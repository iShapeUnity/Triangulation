using iShape.Collections;
using iShape.Geometry;
using iShape.Geometry.Container;
using Unity.Collections;

namespace iShape.Triangulation.Shape.Delaunay {

    public static class Breaker {

        private readonly struct Detail {
            internal readonly IntVector center;
            internal readonly int count;

            internal Detail(IntVector center, int count) {
                this.center = center;
                this.count = count;
            }
        }

        public static PlainShape BuildCentroidNet(this Delaunay self, Allocator allocator) {
            int n = self.triangles.Length;
            var details = new NativeArray<Detail>(n, Allocator.Temp);
            for (int i = 0; i < n; ++i) {
                var triangle = self.triangles[i];
                var count = 0;
                if (triangle.nA >= 0) {
                    ++count;
                }

                if (triangle.nB >= 0) {
                    ++count;
                }

                if (triangle.nC >= 0) {
                    ++count;
                }

                details[i] = new Detail(triangle.Center(), count);
            }

            int capacity = self.pathCount + self.extraCount;
            
            var visitedIndex = new NativeArray<bool>(capacity, Allocator.Temp);
            var result = new DynamicPlainShape(8 * capacity,capacity, allocator);
            var forePoints = new NativeArray<IntVector>(4, Allocator.Temp);
            var path = new DynamicArray<IntVector>(8, Allocator.Temp);
            
            for (int i = 0; i < n; ++i) {
                var triangle = self.triangles[i];
                var detail = details[i];

                for (int j = 0; j <= 2; ++j) {

                    var v = triangle.Vertex(j);
                    if (visitedIndex[v.index]) {
                        continue;
                    }

                    visitedIndex[v.index] = true;

                    if (v.index < self.pathCount) {
                        if (detail.count == 1 && triangle.Neighbor(j) >= 0) {
                            switch (j) {
                                case 0: // a
                                    var ab0 = v.point.Center(triangle.vB.point);
                                    var ca0 = v.point.Center(triangle.vC.point);

                                    forePoints[0] = v.point;
                                    forePoints[1] = ab0;
                                    forePoints[2] = detail.center;
                                    forePoints[3] = ca0;
                                    break;
                                case 1: // b
                                    var bc1 = v.point.Center(point: triangle.vC.point);
                                    var ab1 = v.point.Center(point: triangle.vA.point);

                                    forePoints[0] = v.point;
                                    forePoints[1] = bc1;
                                    forePoints[2] = detail.center;
                                    forePoints[3] = ab1;
                                    break;
                                default: // c
                                    var ca2 = v.point.Center(point: triangle.vA.point);
                                    var bc2 = v.point.Center(point: triangle.vB.point);
                                        
                                    forePoints[0] = v.point;
                                    forePoints[1] = ca2;
                                    forePoints[2] = detail.center;
                                    forePoints[3] = bc2;
                                    break;
                            }
                            
                            result.Add(forePoints, true);
                        } else {
                            path.RemoveAll();
                            // first going in a counterclockwise direction
                            var current = triangle;
                            int k = triangle.FindIndex(v.index);
                            int right = (k + 2) % 3;
                            var prev = triangle.Neighbor(right);
                            while (prev >= 0) {
                                var prevTriangle = self.triangles[prev];
                                k = prevTriangle.FindIndex(v.index);
                                if (k < 0) {
                                    break;
                                }

                                current = prevTriangle;
                                path.Add(details[prev].center);

                                right = (k + 2) % 3;
                                prev = current.Neighbor(right);
                            }

                            var left = (k + 1) % 3;
                            var lastPrevPair = current.Vertex(left).point;
                            path.Add(lastPrevPair.Center(v.point));

                            path.array.Reverse();

                            path.Add(details[i].center);

                            // now going in a clockwise direction
                            current = triangle;
                            k = triangle.FindIndex(v.index);
                            left = (k + 1) % 3;
                            var next = triangle.Neighbor(left);
                            while (next >= 0) {
                                var nextTriangle = self.triangles[next];
                                k = nextTriangle.FindIndex(v.index);
                                if (k < 0) {
                                    break;
                                }

                                current = nextTriangle;
                                path.Add(details[next].center);
                                left = (k + 1) % 3;
                                next = current.Neighbor(left);
                            }

                            right = (k + 2) % 3;
                            var lastNextPair = current.Vertex(right).point;
                            path.Add(lastNextPair.Center(v.point));
                            path.Add(v.point);
                            result.Add(path.slice, true);
                        }
                    } else {
                        path.RemoveAll();
                        int start = i;
                        var next = start;
                        do {
                            var t = self.triangles[next];
                            var center = details[next].center;
                            path.Add(center);
                            int index = (t.FindIndex(v.index) + 1) % 3;
                            next = t.Neighbor(index);
                        }
                        while (next != start);

                        result.Add(path.slice, true);
                    }

                }
            }

            path.Dispose();
            forePoints.Dispose();
            details.Dispose();
            visitedIndex.Dispose();
            return result.Convert();
        }
    }

    internal static class BreakerExt {
        internal static IntVector Center(this Triangle self) {
            var a = self.vA.point;
            var b = self.vB.point;
            var c = self.vC.point;

            return new IntVector((a.x + b.x + c.x) / 3, (a.y + b.y + c.y) / 3);
        }
        
        internal static IntVector Center(this IntVector self, IntVector point) {
            return new IntVector((self.x + point.x) / 2, (self.y + point.y) / 2);
        }
    }
}