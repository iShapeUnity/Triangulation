using iShape.Geometry;

namespace iShape.Triangulation.Shape.Delaunay {

    internal struct Triangle {

        internal readonly int index;

        // a(0), b(1), c(2)
        internal Vertex vA;
        internal Vertex vB;
        internal Vertex vC;

        // BC - a(0), AC - b(1), AB - c(2)
        internal int nA;
        internal int nB;
        internal int nC;

        internal Triangle(int index, Vertex a, Vertex b, Vertex c) {
            this.index = index;
            this.vA = a;
            this.vB = b;
            this.vC = c;

            this.nA = -1;
            this.nB = -1;
            this.nC = -1;
        }

        internal int Opposite(int neighbor) {
            if(nA == neighbor) {
                return 0;
            }

            return nB == neighbor ? 1 : 2;
        }
        
        internal Vertex oppositeVertex(int neighbor) {
            if(nA == neighbor) {
                return vA;
            }

            return nB == neighbor ? vB : vC;
        }

        internal int GetNeighborByIndex(int index) {
            switch(index) {
                case 0:
                    return nA;
                case 1:
                    return nB;
                default:
                    return nC;
            }
        }

        internal int GetNeighborByVertex(int vertex) {
            if(vA.index == vertex) {
                return nA;
            }

            return vB.index == vertex ? nB : nC;
        }

        internal void SetNeighborByIndex(int index, int value) {
            switch(index) {
                case 0:
                    nA = value;
                    break;
                case 1:
                    nB = value;
                    break;
                default:
                    nC = value;
                    break;
            }
        }

        internal void UpdateOpposite(int oldNeighbor, int newNeighbor) {
            if(nA == oldNeighbor) {
                nA = newNeighbor;
				return;
            }

            if(nB == oldNeighbor) {
                nB = newNeighbor;
				return;
			}

            if(nC == oldNeighbor) {
                nC = newNeighbor;
            }
        }
    }

}
