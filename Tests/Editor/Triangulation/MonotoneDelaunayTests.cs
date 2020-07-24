using NUnit.Framework;
using iShape.Geometry;
using iShape.Geometry.Container;
using iShape.Triangulation.Shape.Delaunay;
using Tests.Triangulation.Util;
using Tests.Triangulation.Data;
using Unity.Collections;
using Triangle = Tests.Triangulation.Util.Triangle;


namespace Tests.Triangulation {

    public class MonotoneDelaunayTests {

        private NativeArray<int> Triangulate(int index) {
            var iGeom = IntGeom.DefGeom;

            var data = MonotoneTests.data[index];
            var iPoints = iGeom.Int(data);

            var iShape = new IntShape(iPoints, new IntVector[0][]);
            var pShape = new PlainShape(iShape, Allocator.Temp);

            var triangles = pShape.DelaunayTriangulate(Allocator.Temp);

			Assert.IsTrue(Triangle.IsCCW(pShape.points, triangles));

			pShape.Dispose();

            return triangles;
        }

        [Test]
        public void TestTriangulate_00() {
            var triangles = this.Triangulate(0);
            var origin = new NativeArray<int>(new int[] {
                0, 1, 3,
                1, 2, 3
            }, Allocator.Temp);

            bool isEqual = triangles.CompareTriangles(origin);
            Assert.IsTrue(isEqual);
            triangles.Dispose();
            origin.Dispose();
        }

        [Test]
        public void TestTriangulate_01() {
            var triangles = this.Triangulate(1);
            var origin = new NativeArray<int>(new int[] {
                0, 1, 3,
                3, 1, 2
            }, Allocator.Temp);

            bool isEqual = triangles.CompareTriangles(origin);
            Assert.IsTrue(isEqual);
            triangles.Dispose();
            origin.Dispose();
        }

        [Test]
        public void TestTriangulate_02() {
            var triangles = this.Triangulate(2);
            var origin = new NativeArray<int>(new int[] {
                1, 2, 0,
                0, 2, 4,
                2, 3, 4
            }, Allocator.Temp);

            bool isEqual = triangles.CompareTriangles(origin);
            Assert.IsTrue(isEqual);
            triangles.Dispose();
            origin.Dispose();
        }

        [Test]
        public void TestTriangulate_03() {
            var triangles = this.Triangulate(3);
            var origin = new NativeArray<int>(new int[] {
                3, 1, 2,
                1, 4, 0,
                3, 4, 1
            }, Allocator.Temp);

            bool isEqual = triangles.CompareTriangles(origin);
            Assert.IsTrue(isEqual);
            triangles.Dispose();
            origin.Dispose();
        }

        [Test]
        public void TestTriangulate_04() {
            var triangles = this.Triangulate(4);
            var origin = new NativeArray<int>(new int[] {
                3, 0, 2,
                0, 1, 2
            }, Allocator.Temp);

            bool isEqual = triangles.CompareTriangles(origin);
            Assert.IsTrue(isEqual);
            triangles.Dispose();
            origin.Dispose();
        }

        [Test]
        public void TestTriangulate_05() {
            var triangles = this.Triangulate(5);
            var origin = new NativeArray<int>(new int[] {
                0, 1, 2,
                0, 2, 4,
                2, 3, 4
            }, Allocator.Temp);

            bool isEqual = triangles.CompareTriangles(origin);
            Assert.IsTrue(isEqual);
            triangles.Dispose();
            origin.Dispose();
        }

        [Test]
        public void TestTriangulate_06() {
            var triangles = this.Triangulate(6);
            var origin = new NativeArray<int>(new int[] {
                1, 2, 3,
                1, 3, 0,
                4, 0, 3
            }, Allocator.Temp);

            bool isEqual = triangles.CompareTriangles(origin);
            Assert.IsTrue(isEqual);
            triangles.Dispose();
            origin.Dispose();
        }

        [Test]
        public void TestTriangulate_07() {
            var triangles = this.Triangulate(7);
            var origin = new NativeArray<int>(new int[] {
                0, 1, 8,
                8, 1, 6,
                8, 6, 7,
                2, 6, 1,
                3, 6, 2,
                5, 6, 3,
                4, 5, 3
            }, Allocator.Temp);

            bool isEqual = triangles.CompareTriangles(origin);
            Assert.IsTrue(isEqual);
            triangles.Dispose();
            origin.Dispose();
        }

        [Test]
        public void TestTriangulate_08() {
            var triangles = this.Triangulate(8);
            var origin = new NativeArray<int>(new int[] {
                6, 0, 1,
                8, 0, 6,
                8, 6, 7,
                2, 6, 1,
                3, 6, 2,
                5, 6, 3,
                4, 5, 3
            }, Allocator.Temp);

            bool isEqual = triangles.CompareTriangles(origin);
            Assert.IsTrue(isEqual);
            triangles.Dispose();
            origin.Dispose();
        }

        [Test]
        public void TestTriangulate_09() {
            var triangles = this.Triangulate(9);
            var origin = new NativeArray<int>(new int[] {
                0, 1, 8,
                7, 8, 1,
                6, 7, 1,
                1, 2, 3,
                1, 3, 6,
                5, 6, 3,
                4, 5, 3
            }, Allocator.Temp);

            bool isEqual = triangles.CompareTriangles(origin);
            Assert.IsTrue(isEqual);
            triangles.Dispose();
            origin.Dispose();
        }

        [Test]
        public void TestTriangulate_10() {
            var triangles = this.Triangulate(10);
            var origin = new NativeArray<int>(new int[] {
                8, 0, 1,
                8, 1, 7,
                1, 6, 7,
                1, 2, 6,
                6, 2, 3,
                6, 3, 5,
                3, 4, 5
            }, Allocator.Temp);

            bool isEqual = triangles.CompareTriangles(origin);
            Assert.IsTrue(isEqual);
            triangles.Dispose();
            origin.Dispose();
        }

        [Test]
        public void TestTriangulate_11() {
            var triangles = this.Triangulate(11);
            var origin = new NativeArray<int>(new int[] {
                8, 0, 6,
                8, 6, 7,
                1, 6, 0,
                1, 2, 3,
                1, 3, 6,
                5, 6, 3,
                4, 5, 3
            }, Allocator.Temp);

            bool isEqual = triangles.CompareTriangles(origin);
            Assert.IsTrue(isEqual);
            triangles.Dispose();
            origin.Dispose();
        }

        [Test]
        public void TestTriangulate_12() {
            var triangles = this.Triangulate(12);
            var origin = new NativeArray<int>(new int[] {
                14, 0, 1,
                14, 1, 13,
                1, 2, 3,
                13, 1, 10,
                10, 12, 13,
                10, 11, 12,
                1, 3, 4,
                1, 4, 10,
                9, 10, 4,
                5, 9, 4,
                5, 6, 8,
                5, 8, 9,
                7, 8, 6
            }, Allocator.Temp);

            bool isEqual = triangles.CompareTriangles(origin);
            Assert.IsTrue(isEqual);
            triangles.Dispose();
            origin.Dispose();
        }

        [Test]
        public void TestTriangulate_13() {
            var triangles = this.Triangulate(13);
            var origin = new NativeArray<int>(new int[] {
                14, 0, 1,
                14, 1, 13,
                2, 3, 4,
                10, 13, 1,
                12, 13, 10,
                12, 10, 11,
                2, 4, 1,
                1, 4, 10,
                9, 10, 4,
                5, 9, 4,
                5, 6, 8,
                5, 8, 9,
                7, 8, 6
            }, Allocator.Temp);

            bool isEqual = triangles.CompareTriangles(origin);
            Assert.IsTrue(isEqual);
            triangles.Dispose();
            origin.Dispose();
        }

        [Test]
        public void TestTriangulate_14() {
            var triangles = this.Triangulate(14);
            var origin = new NativeArray<int>(new int[] {
				1, 2, 8,
				2, 3, 7,
				6, 3, 4,
				9, 0, 1,
				1, 8, 9,
				2, 7, 8,
				6, 7, 3,
				5, 6, 4
			}, Allocator.Temp);

            bool isEqual = triangles.CompareTriangles(origin);
            Assert.IsTrue(isEqual);
            triangles.Dispose();
            origin.Dispose();
        }

        [Test]
        public void TestTriangulate_15() {
            var triangles = this.Triangulate(15);
            var origin = new NativeArray<int>(new int[] {
                0, 1, 3,
                3, 1, 2,
                13, 0, 3,
                13, 15, 0,
                13, 14, 15,
                5, 3, 4,
                5, 13, 3,
                11, 13, 5,
                11, 12, 13,
                7, 5, 6,
                8, 5, 7,
                8, 11, 5,
                9, 10, 11,
                11, 8, 9
            }, Allocator.Temp);

            bool isEqual = triangles.CompareTriangles(origin);
            Assert.IsTrue(isEqual);
            triangles.Dispose();
            origin.Dispose();
        }

        [Test]
        public void TestTriangulate_16() {
            var triangles = this.Triangulate(16);
            var origin = new NativeArray<int>(new int[] {
                12, 0, 1,
                12, 1, 11,
                1, 2, 4,
                5, 11, 1,
                4, 2, 3,
                5, 1, 4,
                5, 10, 11,
                10, 5, 8,
                10, 8, 9,
                5, 6, 7,
                5, 7, 8
            }, Allocator.Temp);

            bool isEqual = triangles.CompareTriangles(origin);
            Assert.IsTrue(isEqual);
            triangles.Dispose();
            origin.Dispose();
        }

        [Test]
        public void TestTriangulate_17() {
            var triangles = this.Triangulate(17);
            var origin = new NativeArray<int>(new int[] {
				1, 13, 0,
				12, 13, 1,
				2, 12, 1,
				3, 12, 2,
				10, 11, 12,
				9, 10, 12,
				12, 3, 9,
				4, 9, 3,
				5, 9, 4,
				8, 9, 5,
				5, 6, 7,
				5, 7, 8
			}, Allocator.Temp);

            bool isEqual = triangles.CompareTriangles(origin);
            Assert.IsTrue(isEqual);
            triangles.Dispose();
            origin.Dispose();
        }
    }
}