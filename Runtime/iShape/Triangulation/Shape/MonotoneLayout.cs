using Unity.Collections;

namespace iShape.Extension.Shape {

    public struct MonotoneLayout {

		public NativeArray<Link> links;
		public NativeArray<Slice> slices;
		public NativeArray<int> indices;

        public MonotoneLayout(NativeArray<Link> links, NativeArray<Slice> slices, NativeArray<int> indices) {
            this.links = links;
            this.slices = slices;
            this.indices = indices;
        }

        public void Dispose() {
        	links.Dispose();
        	slices.Dispose();
        	indices.Dispose();
        }
    }
}