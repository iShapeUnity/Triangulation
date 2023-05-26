using iShape.Geometry;
using iShape.Geometry.Container;
using iShape.Triangulation.Shape.Delaunay;
using Tests.Triangulation.Util;
using Tests.Triangulation.Data;
using NUnit.Framework;
using Unity.Collections;
using UnityEngine;
using Triangle = Tests.Triangulation.Util.Triangle;

namespace Tests.Triangulation {

	public class ComplexDelaunayTests {

		private NativeArray<int> Triangulate(int index) {
			var iGeom = IntGeom.DefGeom;

			var data = ComplexTests.data[index];

			var hull = iGeom.Int(data[0]);
			var holes = new IntVector[data.Length - 1][];
			for(int i = 1; i < data.Length; ++i) {
				holes[i - 1] = iGeom.Int(data[i]);
			}

			var iShape = new IntShape(hull, holes);
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
		public void TestTriangulate_02() {
			var triangles = this.Triangulate(2);
			var origin = new NativeArray<int>(new int[] {
				0, 5, 6,
				0, 6, 3,
				6, 7, 3,
				0, 1, 5,
				1, 4, 5,
				1, 7, 4,
				1, 2, 7,
				7, 2, 3
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
				2, 3, 1,
				0, 1, 3
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
                1, 4, 0,
                1, 2, 3,
                1, 3, 4
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
                1, 4, 0,
                1, 2, 3,
                1, 3, 4
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
				0, 2, 3,
				0, 1, 2
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
                1, 7, 0,
                7, 5, 6,
                7, 1, 4,
                3, 1, 2,
                1, 3, 4,
                7, 4, 5
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
                7, 5, 6,
                1, 2, 0,
                7, 0, 2,
                2, 3, 4,
                2, 4, 7,
                4, 5, 7
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
                2, 0, 1,
                3, 0, 2,
                7, 5, 6,
                0, 5, 7,
                0, 3, 4,
                0, 4, 5
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
                7, 0, 6,
                5, 6, 0,
                4, 5, 0,
                1, 2, 4,
                1, 4, 0,
                3, 4, 2
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
                0, 1, 4,
                0, 4, 7,
                4, 5, 7,
                7, 5, 6,
                4, 1, 3,
                1, 2, 3
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
				0, 4, 7,
				4, 5, 7,
				6, 7, 5,
				2, 3, 1,
				0, 1, 4,
				4, 1, 3
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
                0, 1, 6,
                0, 6, 11,
                11, 9, 10,
                7, 9, 11,
                8, 9, 7,
                7, 11, 6,
                6, 1, 5,
                1, 2, 3,
                1, 3, 5,
                5, 3, 4
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
                9, 0, 1,
                4, 9, 1,
                8, 9, 5,
                6, 7, 5,
                8, 5, 7,
                4, 5, 9,
                1, 2, 3,
                1, 3, 4
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
				4, 2, 3,
				4, 0, 2,
				0, 1, 2
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
                33, 1, 2,
                20, 21, 0,
                0, 35, 20,
                27, 28, 16,
                27, 16, 26,
                29, 16, 28,
                19, 16, 29,
                15, 22, 14,
                13, 14, 22,
                23, 13, 22,
                13, 23, 24,
                25, 13, 24,
                25, 12, 13,
                25, 26, 10,
                11, 12, 25,
                16, 17, 26,
                26, 17, 10,
                25, 10, 11,
                9, 10, 17,
                18, 9, 17,
                8, 9, 18,
                21, 22, 15,
                0, 21, 15,
                1, 34, 0,
                0, 34, 35,
                33, 34, 1,
                33, 2, 3,
                33, 3, 32,
                31, 32, 3,
                30, 31, 3,
                4, 30, 3,
                5, 30, 4,
                29, 30, 5,
                29, 5, 19,
                19, 5, 6,
                19, 6, 18,
                18, 6, 7,
                18, 7, 8
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
                6, 7, 8,
                6, 8, 5,
                0, 8, 7,
                11, 8, 0,
                1, 11, 0,
                1, 10, 11,
                8, 9, 5,
                4, 5, 9,
                10, 4, 9,
                2, 10, 1,
                10, 3, 4,
                2, 3, 10
            }, Allocator.Temp);

			bool isEqual = triangles.CompareTriangles(origin);
			Assert.IsTrue(isEqual);
			triangles.Dispose();
			origin.Dispose();
		}


		[Test]
		public void TestTriangulate_18()
		{
			var triangles = this.Triangulate(18);
			var origin = new NativeArray<int>(new int[] {
                8, 4, 0,
                4, 5, 3,
                6, 3, 5,
                4, 3, 0,
                8, 0, 11,
                0, 1, 11,
                11, 1, 10,
                10, 1, 2,
                3, 6, 2,
                10, 2, 6
            }, Allocator.Temp);

			bool isEqual = triangles.CompareTriangles(origin);
			Assert.IsTrue(isEqual);
			triangles.Dispose();
			origin.Dispose();
		}

		[Test]
		public void TestTriangulate_19()
		{
			var triangles = this.Triangulate(19);
			var origin = new NativeArray<int>(new int[] {
                6, 8, 9,
                8, 6, 7,
                6, 9, 5,
                1, 2, 4,
                1, 4, 5,
                4, 2, 3
            }, Allocator.Temp);

			bool isEqual = triangles.CompareTriangles(origin);
			Assert.IsTrue(isEqual);
			triangles.Dispose();
			origin.Dispose();
		}

		[Test]
		public void TestTriangulate_20()
		{
			var triangles = this.Triangulate(20);
			var origin = new NativeArray<int>(new int[] {
                1, 3, 4,
                3, 1, 2,
                1, 4, 0,
                6, 7, 9,
                6, 9, 0,
                9, 7, 8
            }, Allocator.Temp);

			bool isEqual = triangles.CompareTriangles(origin);
			Assert.IsTrue(isEqual);
			triangles.Dispose();
			origin.Dispose();
		}

		[Test]
		public void TestTriangulate_21()
		{
			var triangles = this.Triangulate(21);
			var origin = new NativeArray<int>(new int[] {
                4, 5, 0,
                8, 9, 5,
                5, 9, 0,
                10, 3, 9,
                9, 3, 0,
                0, 1, 4,
                4, 1, 7,
                8, 7, 11,
                7, 1, 11,
                3, 10, 2,
                10, 11, 2,
                11, 1, 2
            }, Allocator.Temp);

			bool isEqual = triangles.CompareTriangles(origin);
			Assert.IsTrue(isEqual);
			triangles.Dispose();
			origin.Dispose();
		}

		[Test]
		public void TestTriangulate_22()
		{
			var triangles = this.Triangulate(22);
			var origin = new NativeArray<int>(new int[] {
                4, 5, 8,
                10, 5, 6,
                8, 9, 3,
                6, 2, 10,
                10, 2, 9,
                9, 2, 3,
                3, 0, 8,
                8, 0, 4,
                4, 0, 7,
                2, 6, 1,
                6, 7, 1,
                7, 0, 1
            }, Allocator.Temp);

			bool isEqual = triangles.CompareTriangles(origin);
			Assert.IsTrue(isEqual);
			triangles.Dispose();
			origin.Dispose();
		}

		[Test]
		public void TestTriangulate_23()
		{
			var triangles = this.Triangulate(23);
			var origin = new NativeArray<int>(new int[] {
                8, 7, 4,
                6, 7, 10,
                4, 5, 3,
                10, 2, 6,
                6, 2, 5,
                5, 2, 3,
                3, 0, 4,
                4, 0, 8,
                8, 0, 11,
                2, 10, 1,
                10, 11, 1,
                11, 0, 1
            }, Allocator.Temp);

			bool isEqual = triangles.CompareTriangles(origin);
			Assert.IsTrue(isEqual);
			triangles.Dispose();
			origin.Dispose();
		}

		[Test]
		public void TestTriangulate_24()
		{
			var triangles = this.Triangulate(24);
			var origin = new NativeArray<int>(new int[] {
                6, 0, 7,
                0, 1, 7,
                1, 2, 7,
                9, 2, 3,
                7, 8, 6,
                3, 4, 9,
                4, 5, 9,
                9, 5, 8,
                8, 5, 6
            }, Allocator.Temp);

			bool isEqual = triangles.CompareTriangles(origin);
			Assert.IsTrue(isEqual);
			triangles.Dispose();
			origin.Dispose();
		}

		[Test]
		public void TestTriangulate_25()
		{
			var triangles = this.Triangulate(25);
			var origin = new NativeArray<int>(new int[] {
                7, 4, 5,
                4, 9, 3,
                2, 3, 9,
                6, 0, 7,
                6, 7, 5,
                7, 0, 10,
                2, 9, 1,
                9, 10, 1,
                10, 0, 1
            }, Allocator.Temp);

			bool isEqual = triangles.CompareTriangles(origin);
			Assert.IsTrue(isEqual);
			triangles.Dispose();
			origin.Dispose();
		}

		[Test]
		public void TestTriangulate_26()
		{
			var triangles = this.Triangulate(26);
			var origin = new NativeArray<int>(new int[] {
                9, 0, 10,
                9, 10, 8,
                0, 1, 10,
                1, 2, 10,
                12, 2, 3,
                10, 7, 8,
                7, 12, 6,
                4, 12, 3,
                12, 5, 6,
                4, 5, 12
            }, Allocator.Temp);

			bool isEqual = triangles.CompareTriangles(origin);
			Assert.IsTrue(isEqual);
			triangles.Dispose();
			origin.Dispose();
		}

		[Test]
		public void TestTriangulate_27()
		{
			var triangles = this.Triangulate(27);
			var origin = new NativeArray<int>(new int[] {
                6, 0, 2,
                2, 0, 1,
                2, 3, 6,
                6, 3, 5,
                5, 3, 1
            }, Allocator.Temp);

			bool isEqual = triangles.CompareTriangles(origin);
			Assert.IsTrue(isEqual);
			triangles.Dispose();
			origin.Dispose();
		}

		[Test]
		public void TestTriangulate_28()
		{
			var triangles = this.Triangulate(28);
			var origin = new NativeArray<int>(new int[] {
                4, 5, 3,
                5, 6, 3,
                3, 6, 2,
                4, 2, 0,
                2, 6, 0
            }, Allocator.Temp);

			bool isEqual = triangles.CompareTriangles(origin);
			Assert.IsTrue(isEqual);
			triangles.Dispose();
			origin.Dispose();
		}

		[Test]
		public void TestTriangulate_29()
		{
			var triangles = this.Triangulate(29);
			var origin = new NativeArray<int>(new int[] {
                1, 2, 3,
                2, 6, 4,
                0, 4, 6,
                0, 3, 4,
                3, 0, 1
            }, Allocator.Temp);

			bool isEqual = triangles.CompareTriangles(origin);
			Assert.IsTrue(isEqual);
			triangles.Dispose();
			origin.Dispose();
		}

		[Test]
		public void TestTriangulate_30()
		{
			var triangles = this.Triangulate(30);
			var origin = new NativeArray<int>(new int[] {
                3, 1, 6,
                1, 2, 5,
                1, 5, 6,
                5, 2, 4,
                2, 3, 4
            }, Allocator.Temp);

			bool isEqual = triangles.CompareTriangles(origin);
			Assert.IsTrue(isEqual);
			triangles.Dispose();
			origin.Dispose();
		}
		
		[Test]
		public void TestTriangulate_33()
		{
			var triangles = this.Triangulate(33);
			var origin = new NativeArray<int>(new int[] {
				2, 4, 6,
				6, 4, 5,
				2, 3, 4,
				6, 0, 2,
				2, 0, 1
			}, Allocator.Temp);

			bool isEqual = triangles.CompareTriangles(origin);
			Assert.IsTrue(isEqual);
			triangles.Dispose();
			origin.Dispose();
		}

		[Test]
		public void TestTriangulate_34()
		{
			var triangles = this.Triangulate(34);
			var origin = new NativeArray<int>(new int[] {
				16, 17, 15,
				21, 22, 20,
				20, 22, 19,
				22, 23, 19,
				23, 24, 19,
				19, 24, 18,
				17, 18, 25,
				24, 25, 18,
				17, 25, 15,
				12, 13, 11,
				6, 8, 10,
				10, 8, 9,
				6, 7, 8,
				26, 0, 1,
				1, 2, 3,
				14, 15, 13,
				10, 15, 25,
				10, 13, 15,
				13, 10, 11,
				10, 25, 6,
				25, 26, 6,
				26, 1, 3,
				26, 3, 6,
				6, 3, 5,
				3, 4, 5
			}, Allocator.Temp);

			bool isEqual = triangles.CompareTriangles(origin);
			Assert.IsTrue(isEqual);
			triangles.Dispose();
			origin.Dispose();
		}
	}
}
