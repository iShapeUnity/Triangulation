using NUnit.Framework;
using iShape.Geometry;
using iShape.Triangulation.Shape;
using Tests.Triangulation.Util;
using Tests.Triangulation.Data;
using Unity.Collections;
using iShape.Geometry.Container;
using Triangle = Tests.Triangulation.Util.Triangle;


namespace Tests.Triangulation {

    public class MonotonePlainTests {

        private NativeArray<int> Triangulate(int index) {
            var iGeom = IntGeom.DefGeom;

            var data = MonotoneTests.data[index];
            var iPoints = iGeom.Int(data);

            var iShape = new IntShape(iPoints, new IntVector[0][]);
            var pShape = new PlainShape(iShape, Allocator.Temp);

            var triangles = pShape.Triangulate(Allocator.Temp);

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
                0, 1, 2,
                0, 2, 3,
                0, 3, 4
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
        public void TestTriangulate_08() {
            var triangles = this.Triangulate(8);
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
        public void TestTriangulate_09() {
            var triangles = this.Triangulate(9);
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
                8, 0, 7,
                0, 6, 7,
                0, 1, 6,
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
        public void TestTriangulate_12() {
            var triangles = this.Triangulate(12);
            var origin = new NativeArray<int>(new int[] {
                0, 13, 14,
                0, 1, 13,
                13, 1, 2,
                13, 2, 12,
                2, 11, 12,
                2, 10, 11,
                2, 3, 10,
                10, 3, 4,
                10, 4, 9,
                4, 5, 9,
                9, 5, 6,
                9, 6, 8,
                6, 7, 8
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
                0, 13, 14,
                0, 1, 13,
                13, 1, 12,
                1, 2, 12,
                12, 2, 11,
                2, 10, 11,
                2, 3, 10,
                10, 3, 4,
                10, 4, 9,
                4, 5, 9,
                9, 5, 6,
                9, 6, 8,
                6, 7, 8
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
                0, 4, 9,
                4, 8, 9,
                4, 7, 8,
                4, 6, 7,
                4, 5, 6
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
                0, 1, 15,
                1, 2, 15,
                15, 2, 14,
                2, 3, 14,
                14, 3, 13,
                3, 4, 13,
                13, 4, 12,
                4, 5, 12,
                12, 5, 11,
                5, 6, 11,
                11, 6, 10,
                6, 7, 10,
                10, 7, 9,
                7, 8, 9
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
                0, 11, 12,
                0, 1, 11,
                11, 1, 2,
                11, 2, 10,
                2, 3, 10,
                10, 3, 9,
                3, 4, 9,
                9, 4, 5,
                9, 5, 8,
                5, 6, 8,
                8, 6, 7
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
                0, 1, 13,
                13, 1, 12,
                1, 2, 12,
                12, 10, 11,
                2, 10, 12,
                2, 9, 10,
                2, 3, 9,
                9, 3, 4,
                9, 4, 5,
                9, 5, 8,
                5, 6, 8,
                8, 6, 7
                }, Allocator.Temp);
            bool isEqual = triangles.CompareTriangles(origin);
            Assert.IsTrue(isEqual);
            triangles.Dispose();
            origin.Dispose();
        }
    }
}
