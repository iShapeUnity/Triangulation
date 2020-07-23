using iShape.Collections;
using iShape.Geometry;
using Unity.Collections;

namespace iShape.Triangulation.Shape.Delaunay {

    public static class Breaker {
        
        public static void BuildCentroidNet(this Delaunay self, Allocator allocator) {

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