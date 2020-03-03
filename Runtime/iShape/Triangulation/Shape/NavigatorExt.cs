using Unity.Collections;
using iShape.Geometry;
using iShape.Geometry.Container;

namespace iShape.Triangulation.Shape {

    internal static class PlainShapeNavigatorExt {

		private struct SortData {
			internal readonly int index;
			internal readonly long factor;
			private readonly int nature;

			internal SortData(int index, long factor, int nature) {
				this.index = index;
				this.factor = factor;
				this.nature = nature;
			}

			public static bool operator <(SortData a, SortData b) {
				if(a.factor != b.factor) {
					return a.factor < b.factor;
				} else if (a.nature != b.nature) {
                    return a.nature < b.nature;
                } else {
                    return a.index < b.index;
                }
			}

			public static bool operator >(SortData a, SortData b) {
				if(a.factor != b.factor) {
					return a.factor > b.factor;
                } else if(a.nature != b.nature) {
                    return a.nature > b.nature;
                } else {
                    return a.index > b.index;
                }
            }
		}

		internal static ShapeNavigator GetNavigator(this PlainShape shape, Allocator allocator) {
            int n = shape.points.Length;

            var iPoints = new NativeArray<IntVector>(n, allocator);
            var links = new NativeArray<Link>(n, allocator);

            var natures = new NativeArray<LinkNature>(n, allocator);

            int m = shape.layouts.Length;
            for(int j = 0; j < m; ++j) {
                var layout = shape.layouts[j];
                var prev = layout.end - 1;

                var self = layout.end;
                var next = layout.begin;

                var a = shape.points[prev];
                var b = shape.points[self];

                var A = a.BitPack;
                var B = b.BitPack;

                while(next <= layout.end) {
                    var c = shape.points[next];
                    var C = c.BitPack;

                    var nature = LinkNature.simple;
                    bool isCCW = IsCCW(a, b, c);

                    if(!layout.isClockWise) {
                        if(A > B && B < C) {
                            if(isCCW) {
                                nature = LinkNature.start;
                            } else {
                                nature = LinkNature.split;
                            }
                        }

                        if(A < B && B > C) {
                            if(isCCW) {
                                nature = LinkNature.end;
                            } else {
                                nature = LinkNature.merge;
                            }
                        }

                    } else {
                        if(A > B && B < C) {
                            if(isCCW) {
                                nature = LinkNature.start;
                            } else {
                                nature = LinkNature.split;
                            }
                        }

                        if(A < B && B > C) {
                            if(isCCW) {
                                nature = LinkNature.end;
                            } else {
                                nature = LinkNature.merge;

                            }
                        }
                    }

                    iPoints[self] = b;

                    links[self] = new Link(prev, self, next, new Vertex(self, b));

                    natures[self] = nature;

                    a = b;
                    b = c;

                    A = B;
                    B = C;

                    prev = self;
                    self = next;

                    ++next;
                }
            }

			var dataList = new NativeArray<SortData>(n, Allocator.Temp);

			for(int j = 0; j < n; ++j) {
				dataList[j] = new SortData(j, iPoints[j].BitPack, (int)natures[j]);
			}

			Sort(dataList);


			var indices = new NativeArray<int>(n, allocator);

			// filter same points
			var x1 = new SortData(-1, long.MinValue, int.MinValue);

			int i = 0;

			while(i < n) {
				var x0 = dataList[i];

				indices[i] = x0.index;

				if(x0.factor == x1.factor) {
					int index = links[x1.index].vertex.index;

					do {
						var link = links[x0.index];

						links[x0.index] = new Link(link.prev, link.self, link.next, new Vertex(index, link.vertex.point));

						++i;

						if(i < n) {
							x0 = dataList[i];
							indices[i] = x0.index;
						} else {
							break;
						}
					} while(x0.factor == x1.factor);

				}
				x1 = x0;

				++i;

			}

			dataList.Dispose();
			iPoints.Dispose();

			return new ShapeNavigator(links, natures, indices);
        }

		private static void Sort(NativeArray<SortData> array) {
			int n = array.Length;
			int r = 2;
			int rank = 1;

			while(r <= n) {
				rank = r;
				r <<= 1;
			}
			rank -= 1;

			int jEnd = rank;

			int jStart = ((jEnd + 1) >> 1) - 1;


			while(jStart >= 0) {
				int k = jStart;
				while(k < jEnd) {
					int j = k;

					var a = array[j];
					bool fallDown;
					do {
						fallDown = false;

						int j0 = (j << 1) + 1;
						int j1 = j0 + 1;


						if(j1 < n) {
							var a0 = array[j0];
							var a1 = array[j1];

							if(a < a0 || a < a1) {
								if(a0 > a1) {
									array[j0] = a;
									array[j] = a0;
									j = j0;
								} else {
									array[j1] = a;
									array[j] = a1;
									j = j1;
								}
								fallDown = j < rank;

							}
						} else if(j0 < n) {
							var ax = array[j];
							var a0 = array[j0];
							if(ax < a0) {
								array[j0] = ax;
								array[j] = a0;
							}
						}

					} while(fallDown);
					++k;
				}

				jEnd = jStart;
				jStart = ((jEnd + 1) >> 1) - 1;
			}

			while(n > 0) {
				int m = n - 1;

				var a = array[m];
				array[m] = array[0];
				array[0] = a;

				int j = 0;
				bool fallDown;
				do {
					fallDown = false;

					int j0 = (j << 1) + 1;
					int j1 = j0 + 1;

					if(j1 < m) {
						var a0 = array[j0];
						var a1 = array[j1];
						fallDown = a < a0 || a < a1;

						if(fallDown) {
							if(a0 > a1) {
								array[j0] = a;
								array[j] = a0;
								j = j0;
							} else {
								array[j1] = a;
								array[j] = a1;
								j = j1;
							}
						}
					} else if(j0 < m) {
						var ax = array[j];
						var a0 = array[j0];
						if(ax < a0) {
							array[j0] = ax;
							array[j] = a0;
						}
					}

				} while(fallDown);

				n = m;
			}
		}

		private static bool IsCCW(IntVector a, IntVector b, IntVector c) {
            long m0 = (c.y - a.y) * (b.x - a.x);
            long m1 = (b.y - a.y) * (c.x - a.x);

            return m0 < m1;
        }

    }

}