using Unity.Collections;

namespace iShape.Triangulation.Shape {

    internal struct ShapeNavigator {
	    
        internal readonly NativeArray<Link> links;
        internal readonly NativeArray<LinkNature> natures;
		internal readonly NativeArray<int> indices;

		internal ShapeNavigator(NativeArray<Link> links, NativeArray<LinkNature> natures, NativeArray<int> indices) {
			this.links = links;
            this.natures = natures;
			this.indices = indices;
		}

        internal void Dispose() {
	        this.links.Dispose();
            this.natures.Dispose();
			this.indices.Dispose();
		}

    }

}
