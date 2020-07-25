using iShape.Collections;
using iShape.Geometry;
using iShape.Geometry.Container;
using Unity.Collections;
using UnityEngine;

namespace iShape.Triangulation.Shape {

    public static class Modification {

        public static PlainShape Modified(this PlainShape self, long maxEgeSize, Allocator allocator) {
            var points = new DynamicArray<IntVector>(self.points.Length, allocator);
            var layouts = new DynamicArray<PathLayout>(self.layouts.Length, allocator);

            long sqrMaxSize = maxEgeSize * maxEgeSize;

            int n = 0;
        
            for(int k = 0; k < self.layouts.Length; ++k) {
                var layout = self.layouts[k];
                int last = layout.end;
                var a = self.points[last];
                int j = 0;
                for (int i = layout.begin; i <= last; ++i ) {
                    var b = self.points[i];
                    long dx = b.x - a.x;
                    long dy = b.y - a.y;
                    long sqrSize = dx * dx + dy * dy;
                    if (sqrSize <= sqrMaxSize) {
                        j += 1;
                        points.Add(b);
                    } else {
                        long l = (long)Mathf.Sqrt(sqrSize);
                        int s = (int)(l / maxEgeSize);
                        double ds = s;

                        double sx = dx / ds;
                        double sy = dy / ds;
                        double fx = 0;
                        double fy = 0;
                        for (int t = 1; t < s; ++t) {
                            fx += sx;
                            fy += sy;

                            long x = a.x + (long)fx;
                            long y = a.y + (long)fy;
                            points.Add(new IntVector(x, y));
                        }

                        points.Add(b);
                        j += s;
                    }

                    a = b;
                }

                layouts.Add(new PathLayout(n, j, layout.isClockWise));
                n += j;
            }
            
            return new PlainShape(points.Convert(), layouts.Convert());
        }

        public static void Modify(ref this PlainShape self, long maxEgeSize, Allocator allocator) {
            var shape = self.Modified(maxEgeSize, allocator);
            self.Dispose();
            self.points = shape.points;
            self.layouts = shape.layouts;
        }

    }

}