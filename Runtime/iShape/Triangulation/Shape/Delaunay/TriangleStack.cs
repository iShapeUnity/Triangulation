using Unity.Collections;
using iShape.Geometry;
using iShape.Collections;

namespace iShape.Extension.Shape.Delaunay {

	public struct TriangleStack {

		private struct Edge {
			internal readonly int a;            // vertex index
			internal readonly int b;            // vertex index
			internal readonly int neighbor;     // prev triangle index

			internal Edge(int a, int b, int neighbor) {
				this.a = a;
				this.b = b;
				this.neighbor = neighbor;
			}
		}

		private DynamicArray<Edge> edges;
		private NativeArray<Triangle> triangles;
		private int counter;

		public TriangleStack(int count) {
			this.counter = 0;
			this.edges = new DynamicArray<Edge>(8, Allocator.Temp);
			this.triangles = new NativeArray<Triangle>(count, Allocator.Temp);
		}

		public NativeArray<Triangle> Convert() {
			edges.Dispose();
			if (this.counter == triangles.Length) {
				return triangles;
			} else {
				var newTriangles = new NativeArray<Triangle>(counter, Allocator.Temp);
				newTriangles.Slice(0, counter).CopyFrom(triangles.Slice(0, counter));
				triangles.Dispose();
				return newTriangles;
            }
		}

		public void Reset() {
			edges.RemoveAll();
		}

		internal void Add(Vertex a, Vertex b, Vertex c) {
            if (a.index == b.index || a.index == c.index|| b.index == c.index) {
                // ignore triangle with tween vertices
                return;
            }

            var triangle = new Triangle(this.counter++, a, b, c);

			var ac = this.Pop(a.index, c.index);
			if (ac.a != -1) {
				var neighbor = triangles[ac.neighbor];

				neighbor.nA = triangle.index;
				triangle.nB = neighbor.index;

				triangles[neighbor.index] = neighbor;
			}

			var ab = this.Pop(a.index, b.index);
			if(ab.a != -1) {
				var neighbor = triangles[ab.neighbor];

				neighbor.nA = triangle.index;
				triangle.nC = neighbor.index;

				triangles[neighbor.index] = neighbor;
			}

			this.edges.Add(new Edge(b.index, c.index, triangle.index)); // bc is always slice

			triangles[triangle.index] = triangle;
		}

		private Edge Pop(int a, int b) {
			int last = edges.Count - 1;

			var i = 0;
            while (i <= last) {
				var e = edges[i];
                if ((e.a == a || e.a == b) && (e.b == a || e.b == b)) {
                    if (i != last) {
						edges[i] = edges[last];
                    }
					edges.RemoveLast();

					return e;
                }
				++i;
            }
			return new Edge(-1, -1, -1);
        }


	}
}