using UnityEngine;

namespace Tests.Triangulation.Data {

	 public struct MonotoneTests {

        public static readonly Vector2[][] data = {
            // test 0
            new Vector2[] {
                new Vector2(-15, -15),
                new Vector2(-15, 15),
                new Vector2(15, 15),
                new Vector2(15, -15)
            },
            // test 1
            new Vector2[] {
                new Vector2(-15, 10),
                new Vector2(5, 10),
                new Vector2(15, -10),
                new Vector2(-5, -10)
            },
            // test 2
            new Vector2[] {
                new Vector2(-15, -15),
                new Vector2(-25, 0),
                new Vector2(-15, 15),
                new Vector2(15, 15),
                new Vector2(15, -15)
            },
            // test 3
            new Vector2[] {
                new Vector2(-5, -15),
                new Vector2(-10,  0),
                new Vector2( 0, 15),
                new Vector2(10,  5),
                new Vector2( 5, -10)
            },
            // test 4
            new Vector2[] {
                new Vector2(0, -5),
                new Vector2(0, 0),
                new Vector2(10, -10),
                new Vector2(-10, -10)
            },
            // test 5
            new Vector2[] {
                new Vector2(-15, -15),
                new Vector2(-15, 0),
                new Vector2(0, 0),
                new Vector2(0, 15),
                new Vector2(15, -15)
            },
            // test 6
            new Vector2[] {
                new Vector2(-15, -15),
                new Vector2(-15, 0),
                new Vector2(-1, 20),
                new Vector2(0, 5),
                new Vector2(15, -15)
            },
            // test 7
            new Vector2[] {
                new Vector2(-10, 10),
                new Vector2(-5, 5),
                new Vector2(10, 20),
                new Vector2(20, 20),
                new Vector2(25, 20),
                new Vector2(25, -5),
                new Vector2(10, -5),
                new Vector2(10, -10),
                new Vector2(-10, -10)
            },
            // test 8
            new Vector2[] {
                new Vector2(-10, 10),
                new Vector2(-5, 15),
                new Vector2(10, 20),
                new Vector2(20, 20),
                new Vector2(25, 20),
                new Vector2(25, -5),
                new Vector2(10, -5),
                new Vector2(10, -10),
                new Vector2(-10, -10)
            },
            // test 9
            new Vector2[] {
                new Vector2(-10, 10),
                new Vector2( -5, 5),
                new Vector2( 10, 20),
                new Vector2( 15, 10),
                new Vector2( 25, 20),
                new Vector2( 25, 0),
                new Vector2(10, 0),
                new Vector2(10, -10),
                new Vector2(-10, -10)
            },
            // test 10
            new Vector2[] {
                new Vector2(-10, 10),
                new Vector2( -5, -5),
                new Vector2( 10, 20),
                new Vector2( 15, 10),
                new Vector2( 25, 20),
                new Vector2(25, 0),
                new Vector2(10, 0),
                new Vector2(10, -10),
                new Vector2(-10, -10)
            },
            // test 11
            new Vector2[] {
                new Vector2(-10, 10),
                new Vector2( 10, 10),
                new Vector2( 10, 20),
                new Vector2( 15, 10),
                new Vector2( 25, 20),
                new Vector2(25, 0),
                new Vector2(10, 0),
                new Vector2(10, -10),
                new Vector2(-10, -10)
            },
            // test 12
            new Vector2[] {
                new Vector2(-35, 5),
                new Vector2(-20, 10),
                new Vector2(-18, 20),
                new Vector2(0, 20),
                new Vector2(5, 10),
                new Vector2(15, 5),
                new Vector2(20, 10),
                new Vector2(35, 0),
                new Vector2(25, -10),
                new Vector2(10, -4),
                new Vector2(-5, -15),
                new Vector2(-5, -20),
                new Vector2(-15, -25),
                new Vector2(-20, -10),
                new Vector2(-30, -5)
            },
            // test 13
            new Vector2[] {
                new Vector2(-35, 5),
                new Vector2(-20, 10),
                new Vector2(-10, 20),
                new Vector2(0, 20),
                new Vector2(5, 10),
                new Vector2(15, 5),
                new Vector2(20, 10),
                new Vector2(35, 0),
                new Vector2(25, -10),
                new Vector2(10, -4),
                new Vector2(-5, -15),
                new Vector2(-5, -20),
                new Vector2(-15, -25),
                new Vector2(-20, -10),
                new Vector2(-30, -5)
            },
            // test 14
            new Vector2[] {
                new Vector2(-10, -10),
                new Vector2(-10, -5),
                new Vector2(-10, 0),
                new Vector2(-10, 5),
                new Vector2(-10, 10),
                new Vector2(10, 10),
                new Vector2(10, 5),
                new Vector2(10, 0),
                new Vector2(10, -5),
                new Vector2(10, -10)
            },
            // test 15
            new Vector2[] {
                new Vector2(-20, 0),
                new Vector2(-15,  15),
                new Vector2(-10,  20),
                new Vector2( -5,  15),
                new Vector2(  0,  20),
                new Vector2(  5,  15),
                new Vector2( 10,  20),
                new Vector2( 15,  15),
                new Vector2( 25,   0),
                new Vector2( 20, -15),
                new Vector2( 15, -20),
                new Vector2( 10, -15),
                new Vector2(  5, -20),
                new Vector2(  0, -15),
                new Vector2( -5, -20),
                new Vector2(-10, -15)
            },
            // test 16
            new Vector2[] {
                new Vector2(-20,  5),
                new Vector2(-10,  10),
                new Vector2( -5,  20),
                new Vector2(  0,  25),
                new Vector2(  5,  15),
                new Vector2( 10,   0),
                new Vector2( 15,   5),
                new Vector2( 20,  -5),
                new Vector2( 15, -15),
                new Vector2(  5, -25),
                new Vector2(  0, -15),
                new Vector2(-10, -10),
                new Vector2(-15,  -5),
            },
            // test 17
            new Vector2[] {
                new Vector2(-35, 5),
                new Vector2(-13.5f, 8),
                new Vector2(-9.5f, 20),
                new Vector2(3, 20),
                new Vector2(8.5f, 11),
                new Vector2( 15, 5),
                new Vector2( 32, 14.5f),
                new Vector2( 35, 0),
                new Vector2( 25, -10),
                new Vector2(  0, 1.5f),
                new Vector2(-0.5f, -12.5f),
                new Vector2( -5, -20),
                new Vector2(-7.5f, 2.5f),
                new Vector2(-31, -4)
            },
            // test 18
            new Vector2[] {
                new Vector2(-10,  5),
                new Vector2( -5,  5),
                new Vector2(  0,  0),
                new Vector2(  5,  5),
                new Vector2( 10,  5),
                new Vector2( 10, -5),
                new Vector2(  5, -5),
                new Vector2(  0,  0),
                new Vector2( -5, -5),
                new Vector2(-10, -5)
            }
        };
    }
}