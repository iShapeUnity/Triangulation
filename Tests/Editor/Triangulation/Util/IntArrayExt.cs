using Unity.Collections;
using System.Collections.Generic;

namespace Tests.Triangulation.Util {

    public static class IntArrayExt {

		private struct Triangle {

			private readonly int a;
			private readonly int b;
			private readonly int c;

			internal Triangle(int a, int b, int c) {
				this.a = a;
				this.b = b;
				this.c = c;
			}

			public override bool Equals(object obj) {
				return (obj is Triangle triangle) && Equals(triangle);
			}

			private bool Equals(Triangle other) {
				return
				   this.a == other.a && this.b == other.b && this.c == other.c ||
					   this.a == other.b && this.b == other.c && this.c == other.a ||
					   this.a == other.c && this.b == other.a && this.c == other.b;
			}

			public override int GetHashCode() {
				if(a > b && a > c) {
					return a;
				}

				if(b > a && b > c) {
					return b;
				}

				return c;
			}
		}

		public static bool CompareTriangles(this NativeArray<int> self, NativeArray<int> array) {
            int n = self.Length;
            if(n != array.Length || n % 3 != 0) {
                return false;
            }

            var set = new HashSet<Triangle>();
            for(int i = 0; i < n; i += 3) {
                set.Add(new Triangle(self[i], self[i + 1], self[i + 2]));
            }

            for(int i = 0; i < n; i += 3) {
                var trinagle = new Triangle(array[i], array[i + 1], array[i + 2]);
                if (!set.Remove(trinagle)) {
                    return false;
                }
            }

            return true;
        }


    }
}