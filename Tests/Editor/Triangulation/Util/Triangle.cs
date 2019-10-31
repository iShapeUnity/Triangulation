using iShape.Geometry;
using Unity.Collections;

namespace Tests.Triangulation.Util {

	internal struct Triangle {

		internal static bool IsCCW(NativeArray<IntVector> points, NativeArray<int> triangles) {
			int n = triangles.Length;

			var i = 0;
			while(i < n) {
				int ai = triangles[i];
				int bi = triangles[i + 1];
				int ci = triangles[i + 2];


				var a = points[ai];

				var b = points[bi];

				var c = points[ci];

				if(!IsCCW_or_Line(a, b, c)) {
					return false;

				}
				i += 3;
			}
			return true;
		}

		private static bool IsCCW_or_Line(IntVector a, IntVector b, IntVector c) {
			long m0 = (c.y - a.y) * (b.x - a.x);

			long m1 = (b.y - a.y) * (c.x - a.x);

			return m0 <= m1;
		}
	}
}