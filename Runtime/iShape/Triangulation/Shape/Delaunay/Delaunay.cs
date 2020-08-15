using Unity.Collections;
using iShape.Geometry;
using iShape.Collections;

namespace iShape.Triangulation.Shape.Delaunay {

    public struct Delaunay {
        internal readonly int pathCount;
        internal int extraCount;
        internal NativeArray<Triangle> triangles;

        public NativeArray<int> Indices(Allocator allocator) {
            int n = triangles.Length;
            var result = new NativeArray<int>(3 * n, allocator);
            int i = 0;
            int j = 0;
            do {
                var triangle = this.triangles[i];
                result[j] = triangle.vA.index;
                result[j + 1] = triangle.vB.index;
                result[j + 2] = triangle.vC.index;

                j += 3;
                i += 1;
            } while(i < n);

            return result;
        }

        public Delaunay(int pathCount, int extraCount, NativeArray<Triangle> triangles) {
            this.pathCount = pathCount;
            this.extraCount = extraCount;
            this.triangles = triangles;
        }

        public void Build() {
            int count = triangles.Length;
            var visitMarks = new NativeArray<bool>(count, Allocator.Temp);
            var visitIndex = 0;

            var origin = new DynamicArray<int>(16, Allocator.Temp);
            var buffer = new DynamicArray<int>(16, Allocator.Temp);

            origin.Add(0);

            while(origin.Count > 0) {
                buffer.RemoveAll();
                for(int l = 0; l < origin.Count; ++l) {
                    int i = origin[l];
                    var triangle = this.triangles[i];
                    visitMarks[i] = true;

                    for(int k = 0; k < 3; ++k) {
                        
                        int neighborIndex = triangle.Neighbor(k);
                        if(neighborIndex >= 0) {
                            var neighbor = triangles[neighborIndex];
                            if(Swap(ref this.triangles, triangle, neighbor)) {

                                triangle = this.triangles[triangle.index];
                                neighbor = this.triangles[neighbor.index];

                                for(int j = 0; j < 3; ++j) {
                                    int ni = triangle.Neighbor(j);
                                    if(ni >= 0 && ni != neighbor.index) {
                                        buffer.Add(ni);
                                    }
                                }

                                for(int j = 0; j < 3; ++j) {
                                    int ni = neighbor.Neighbor(j);
                                    if(ni >= 0 && ni != triangle.index) {
                                        buffer.Add(ni);
                                    }
                                }
                            }
                        }
                    }
                }
                origin.RemoveAll();
                
                if(buffer.Count == 0 && visitIndex < count) {
                    ++visitIndex;
                    while(visitIndex < count) {
                        if(visitMarks[visitIndex] == false) {
                            origin.Add(visitIndex);
                            break;
                        }
                        ++visitIndex;
                    }
                } else {
                    origin.Add(buffer);   
                }
            }

			origin.Dispose();
			buffer.Dispose();
            visitMarks.Dispose();
		}

        internal static int Fix(ref DynamicArray<Triangle> triangles, NativeArray<int> indices)  {
            int count = triangles.Count;

            int minFixIndex = count;
            
            var origin = new DynamicArray<int>(indices, Allocator.Temp);
            var buffer = new DynamicArray<int>(16, Allocator.Temp);

            while(origin.Count > 0) {
                buffer.RemoveAll();
                for(int l = 0; l < origin.Count; ++l) {
                    int i = origin[l];
                    var triangle = triangles[i];

                    for(int k = 0; k < 3; ++k) {
                        
                        int neighborIndex = triangle.Neighbor(k);
                        if(neighborIndex >= 0) {
                            var neighbor = triangles[neighborIndex];
                            if(Swap(ref triangles.array, triangle, neighbor)) {

                                if (minFixIndex > neighborIndex) {
                                    minFixIndex = neighborIndex;
                                }
                                if (minFixIndex > i) {
                                    minFixIndex = i;
                                }
                                
                                triangle = triangles[triangle.index];
                                neighbor = triangles[neighbor.index];

                                for(int j = 0; j < 3; ++j) {
                                    int ni = triangle.Neighbor(j);
                                    if(ni >= 0 && ni != neighbor.index) {
                                        buffer.Add(ni);
                                    }
                                }

                                for(int j = 0; j < 3; ++j) {
                                    int ni = neighbor.Neighbor(j);
                                    if(ni >= 0 && ni != triangle.index) {
                                        buffer.Add(ni);
                                    }
                                }
                            }
                        }
                    }
                }
                origin.RemoveAll();
                origin.Add(buffer);
            }

			origin.Dispose();
			buffer.Dispose();

            return minFixIndex;
        }

        public void Dispose() {
            this.triangles.Dispose();
        }

        private static bool Swap(ref NativeArray<Triangle> triangles, Triangle abc, Triangle pbc) {
            int ai = abc.Opposite(pbc.index);    // opposite a-p
            int bi;                              // edge bc
            int ci;

            Vertex a, b, c;

            int acIndex;
            
            switch (ai) {
            case 0: 
                bi = 1;
                ci = 2;
                a = abc.vA;
                b = abc.vB;
                c = abc.vC;

                acIndex = abc.nB;
                break;
            case 1:
                bi = 2;
                ci = 0;
                a = abc.vB;
                b = abc.vC;
                c = abc.vA;
                
                acIndex = abc.nC;
                break;
            default:
                bi = 0;
                ci = 1;
                a = abc.vC;
                b = abc.vA;
                c = abc.vB;
                
                acIndex = abc.nA;
                break;
            }

            var p = pbc.OppositeVertex(abc.index);

            bool isPrefect = IsDelaunay(p.point, c.point, a.point, b.point);

            if(isPrefect) {
                return false;
            }

            bool isABP_CCW = IsCCW(a.point, b.point, p.point);

            int bp = pbc.FindNeighbor(c.index);
            int cp = pbc.FindNeighbor(b.index);
            int ab = abc.Neighbor(ci);
            int ac = abc.Neighbor(bi);

            // abc -> abp
            Triangle abp;

            // pbc -> acp
            Triangle acp;

            if(isABP_CCW) {
                abp = new Triangle(abc.index, a, b, p) {
                    nA = bp,            // a - bp
                    nB = pbc.index,     // b - ap
                    nC = ab             // p - ab
                };

                acp = new Triangle(pbc.index, a, p, c) {
                    nA = cp,            // a - cp
                    nB = ac,            // p - ac
                    nC = abc.index      // c - ap
                };
            } else {
                abp = new Triangle(abc.index, a, p, b) {
                    nA = bp,            // a - bp
                    nB = ab,            // p - ab
                    nC = pbc.index      // b - ap
                };

                acp = new Triangle(pbc.index, a, c, p) {
                    nA = cp,            // a - cp
                    nB = abc.index,     // c - ap
                    nC = ac             // p - ac
                };
            }

            // fix neighbor's link
            // ab, cp didn't change neighbor
            // bc -> ap, so no changes

            // ac (abc) is now edge of acp
            // int acIndex = abc.GetNeighborByIndex(bi); // b - angle
            if(acIndex >= 0) {
                var neighbor = triangles[acIndex];
                neighbor.UpdateOpposite(abc.index, acp.index);
                triangles[acIndex] = neighbor;
            }

            // bp (pbc) is now edge of abp
            int bpIndex = pbc.FindNeighbor(c.index); // c - angle
            if(bpIndex >= 0) {
                var neighbor = triangles[bpIndex];
                neighbor.UpdateOpposite(pbc.index, abp.index);
                triangles[bpIndex] = neighbor;
            }

            triangles[abc.index] = abp;
            triangles[pbc.index] = acp;

            return true;
        }
        private static bool IsDelaunay(IntVector p0, IntVector p1, IntVector p2, IntVector p3) {
            long x01 = p0.x - p1.x;
            long x03 = p0.x - p3.x;
            long x12 = p1.x - p2.x;
            long x32 = p3.x - p2.x;

            long y01 = p0.y - p1.y;
            long y03 = p0.y - p3.y;
            long y12 = p1.y - p2.y;
            long y23 = p2.y - p3.y;

            long cosA = x01 * x03 + y01 * y03;
            long cosB = x12 * x32 - y12 * y23;
        
            if (cosA < 0 && cosB < 0) {
                return false;
            }
        
            if (cosA >= 0 && cosB >= 0) {
                return true;
            }
        
            // we can not just compare
            // sinA * cosB + cosA * sinB ? 0
            // cause we need weak Delaunay condition

            long sinA = x01 * y03 - x03 * y01;
            long sinB = x12 * y23 + x32 * y12;

            long sl01 = x01 * x01 + y01 * y01;
            long sl03 = x03 * x03 + y03 * y03;
            long sl12 = x12 * x12 + y12 * y12;
            long sl23 = x32 * x32 + y23 * y23;

            double max0 = sl01 > sl03 ? sl01 : sl03;
            double max1 = sl12 > sl23 ? sl12 : sl23;

            double sinAB = ((double) sinA * (double) cosB + (double) cosA * (double) sinB) / (max0 * max1);

            return sinAB < 0.001;
        }

        private static bool IsCCW(IntVector a, IntVector b, IntVector c) {
            long m0 = (c.y - a.y) * (b.x - a.x);
            long m1 = (b.y - a.y) * (c.x - a.x);

            return m0 < m1;
        }

    }
}
