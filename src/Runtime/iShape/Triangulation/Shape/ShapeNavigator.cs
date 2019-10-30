using Unity.Collections;
using iShape.Geometry;

namespace iShape.Triangulation.Shape {

    internal struct ShapeNavigator {

        internal readonly NativeArray<IntVector> iPoints;
        internal readonly NativeArray<Link> links;
        internal readonly NativeArray<LinkNature> natures;
		internal readonly NativeArray<int> indices;

		internal ShapeNavigator(NativeArray<IntVector> iPoints, NativeArray<Link> links, NativeArray<LinkNature> natures, NativeArray<int> indices) {
            this.iPoints = iPoints;
            this.links = links;
            this.natures = natures;
			this.indices = indices;

		}

        internal void Dispose() {
            this.iPoints.Dispose();
            this.links.Dispose();
            this.natures.Dispose();
			this.indices.Dispose();
		}

    }

}
