using UnityEngine;

namespace Tests.Triangulation.Data {

    public struct ComplexTests {

        public static readonly Vector2[][][] data = {
        // test 0
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -15, -15),
                new Vector2( -15, 15),
                new Vector2( 15, 15),
                new Vector2( 15, -15)
            }
        },
        // test 1
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -15, -15),
                new Vector2( -25, 0),
                new Vector2( -15, 15),
                new Vector2( 15, 15),
                new Vector2( 15, -15)
            }
        },
        // test 2
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -15, -15),
                new Vector2( -15, 15),
                new Vector2( 15, 15),
                new Vector2( 15, -15)
            },
            new Vector2[] {
                new Vector2( -10, 10),
                new Vector2( -10, -10),
                new Vector2( 10, -10),
                new Vector2( 10, 10)
            }
        },
        // test 3
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -10, -10),
                new Vector2( 0, 0),
                new Vector2( -10, 10),
                new Vector2( 10, 0)
            }
        },
        // test 4
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -15, -15),
                new Vector2( -10, 0),
                new Vector2( -15, 15),
                new Vector2( 15, 15),
                new Vector2( 15, -15)
            }
        },
        // test 5
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -15, -15),
                new Vector2( -15, -5),
                new Vector2( -20, 10),
                new Vector2( 15, 15),
                new Vector2( 15, -15)
            }
        },
        // test 6
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -10, 0),
                new Vector2( 10, 10),
                new Vector2( 0, 0),
                new Vector2( 10, -10)
            }
        },
        // test 7
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -15, 0),
                new Vector2( -5, 10),
                new Vector2( -10, 15),
                new Vector2( 5, 20),
                new Vector2( 15, 0),
                new Vector2( 5, -20),
                new Vector2( -10, -15),
                new Vector2( -5, -10)
            }
        },
        // test 8
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -15, 0),
                new Vector2( -15, 10),
                new Vector2( -10, 15),
                new Vector2( 5, 20),
                new Vector2( 15, 0),
                new Vector2( 5, -20),
                new Vector2( -10, -15),
                new Vector2( -5, -10)
            }
        },
        // test 9
        new Vector2[][] {
            new Vector2[] {
                new Vector2( 5, 0),
                new Vector2( -10, 5),
                new Vector2( -10, 15),
                new Vector2( 5, 20),
                new Vector2( 15, 0),
                new Vector2( 5, -20),
                new Vector2( -10, -15),
                new Vector2( -10, -5)
            }
        },
        // test 10
        new Vector2[][] {
            new Vector2[] {
                new Vector2( 0, 0),
                new Vector2( -10, 5),
                new Vector2( -10, 15),
                new Vector2( 10, 15),
                new Vector2( 5, 10),
                new Vector2( 10, -15),
                new Vector2( -10, -15),
                new Vector2( -10, -5)
            }
        },
        // test 11
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -15, 0),
                new Vector2( -5, 10),
                new Vector2( -10, 15),
                new Vector2( 5, 20),
                new Vector2( 0, 0),
                new Vector2( 5, -20),
                new Vector2( -10, -15),
                new Vector2( -5, -10)
            }
        },
        // test 12
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -15, 0),
                new Vector2( -5, 10),
                new Vector2( -10, 15),
                new Vector2( 5, 20),
                new Vector2( -7, 0),
                new Vector2( 5, -20),
                new Vector2( -10, -15),
                new Vector2( -5, -10)
            }
        },
        // test 13
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -15, 0),
                new Vector2( -5, 10),
                new Vector2( -10, 15),
                new Vector2( -2.5f, 20),
                new Vector2( 5, 20),
                new Vector2( 2.5f, 10),
                new Vector2( 0, 0),
                new Vector2( 2.5f, -10),
                new Vector2( 5, -20),
                new Vector2( -2.5f, -20),
                new Vector2( -10, -15),
                new Vector2( -5, -10)
            }
        },
        // test 14
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -15, 0),
                new Vector2( -5, 10),
                new Vector2( -10, 15),
                new Vector2( -2.5f, 20),
                new Vector2( 5, 20),
                new Vector2( -2.5f, -15),
                new Vector2( 5, -20),
                new Vector2( -2.5f, -20),
                new Vector2( -10, -15),
                new Vector2( -5, -10)
            }
        },
        // test 15
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -10, 0),
                new Vector2( 10, 10),
                new Vector2( 0, 0),
                new Vector2( 10, -20),
                new Vector2( -10, -20)
            }
        },
        // test 16
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -25, 5),

                new Vector2( -30, 20),
                new Vector2( -25, 30),
                new Vector2( -10, 25),
                new Vector2( 0, 30),

                new Vector2( 15, 15),
                new Vector2( 30, 15),
                new Vector2( 35, 5),

                new Vector2( 30, -10),
                new Vector2( 25, -10),
                new Vector2( 15, -20),
                new Vector2( 15, -30),

                new Vector2( -5, -35),

                new Vector2( -15, -20),
                new Vector2( -40, -25),
                new Vector2( -35, -5)
            },
            new Vector2[] {
                new Vector2( 5, 0),
                new Vector2( 10, -10),
                new Vector2( 25, 0),
                new Vector2( 15, 5)
            },
            new Vector2[] {
                new Vector2( -15, 0),
                new Vector2( -25, -5),
                new Vector2( -30, -15),
                new Vector2( -15, -10),
                new Vector2( -5, -15),
                new Vector2( 0, -25),
                new Vector2( 5, -15),
                new Vector2( -5, -5),
                new Vector2( -5, 5),
                new Vector2( 5, 10),
                new Vector2( 0, 20),
                new Vector2( -5, 15),
                new Vector2( -10, 15),
                new Vector2( -15, 20),
                new Vector2( -20, 10),
                new Vector2( -15, 5)
            }
        },
        // test 17
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -5, 10),
                new Vector2( 5, 10),
                new Vector2( 10, 5),
                new Vector2( 10, -5),
                new Vector2( 5, -10),
                new Vector2( -5, -10),
                new Vector2( -10, -5),
                new Vector2( -10, 5)
            },
            new Vector2[] {
                new Vector2( -5, 0),
                new Vector2( 0, -5),
                new Vector2( 5, 0),
                new Vector2( 0, 5)
            },
        },
        // test 18
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -10, -10),
                new Vector2( -10, 10),
                new Vector2( 10, 10),
                new Vector2( 10, -10)
            },
            new Vector2[] {
                new Vector2( 0, -5),
                new Vector2( 5, -5),
                new Vector2( 5, 5),
                new Vector2( 0, 5)
            },
            new Vector2[] {
                new Vector2( -5, -5),
                new Vector2( 0, -5),
                new Vector2( 0, 5),
                new Vector2( -5, 5)
            }
        },
        // test 19
        new Vector2[][] {
            new Vector2[] {
                new Vector2( 0, 0),

                new Vector2( -5, 5),
                new Vector2( -5, 10),
                new Vector2( 5, 10),
                new Vector2( 5, 5),

                new Vector2( 0, 0),

                new Vector2( 5, -5),
                new Vector2( 5, -10),
                new Vector2( -5, -10),
                new Vector2( -5, -5)
            }
        },
        // test 20
        new Vector2[][] {
            new Vector2[] {
                new Vector2( 0, 0),

                new Vector2( 5, -5),
                new Vector2( 5, -10),
                new Vector2( -5, -10),
                new Vector2( -5, -5),

                new Vector2( 0, 0),

                new Vector2( -5, 5),
                new Vector2( -5, 10),
                new Vector2( 5, 10),
                new Vector2( 5, 5)
            }
        },
        // test 21
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -15, -10),
                new Vector2( -15, 10),
                new Vector2( 15, 10),
                new Vector2( 15, -10)
            },
            new Vector2[] {
                new Vector2( -10, 0),
                new Vector2( -5, -5),
                new Vector2( 0, 0),
                new Vector2( -5, 5)
            },
            new Vector2[] {
                new Vector2( 0, 0),
                new Vector2( 5, -5),
                new Vector2( 10, 0),
                new Vector2( 5, 5)
            }
        },
        // test 22
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -10, 15),
                new Vector2( 10, 15),
                new Vector2( 10, -15),
                new Vector2( -10, -15)
            },
            new Vector2[] {
                new Vector2( -5, 5),
                new Vector2( 0, 0),
                new Vector2( 5, 5),
                new Vector2( 0, 10)
            },
            new Vector2[] {
                new Vector2( -5, -5),
                new Vector2( 0, -10),
                new Vector2( 5, -5),
                new Vector2( 0, 0)
            }
        },
        // test 23
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -10, 15),
                new Vector2( 10, 15),
                new Vector2( 10, -15),
                new Vector2( -10, -15)
            },
            new Vector2[] {
                new Vector2( -5, -5),
                new Vector2( 0, -10),
                new Vector2( 5, -5),
                new Vector2( 0, 0)
            },
            new Vector2[] {
                new Vector2( -5, 5),
                new Vector2( 0, 0),
                new Vector2( 5, 5),
                new Vector2( 0, 10)
            }
        },
        // test 24
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -10, 10),
                new Vector2( -5, 10),
                new Vector2( 0, 5),
                new Vector2( 5, 10),
                new Vector2( 10, 10),
                new Vector2( 10, -10),
                new Vector2( -10, -10)
            },
            new Vector2[] {
                new Vector2( -5, 0),
                new Vector2( 0, -5),
                new Vector2( 5, 0),
                new Vector2( 0, 5)
            }
        },
        // test 25
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -10, 10),
                new Vector2( 10, 10),
                new Vector2( 10, -10),
                new Vector2( 5, -10),
                new Vector2( 0, -5),
                new Vector2( -5, -10),
                new Vector2( -10, -10)
            },
            new Vector2[] {
                new Vector2( -5, 0),
                new Vector2( 0, -5),
                new Vector2( 5, 0),
                new Vector2( 0, 5)
            }
        },
        // test 26
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -10, 10),
                new Vector2( -5, 10),
                new Vector2( 0, 5),
                new Vector2( 5, 10),
                new Vector2( 10, 10),
                new Vector2( 10, -10),
                new Vector2( 5, -10),
                new Vector2( 0, -5),
                new Vector2( -5, -10),
                new Vector2( -10, -10)
            },
            new Vector2[] {
                new Vector2( -5, 0),
                new Vector2( 0, -5),
                new Vector2( 5, 0),
                new Vector2( 0, 5)
            }
        },
        // test 27
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -10, 10),
                new Vector2( 10, 10),
                new Vector2( 0, 5),
                new Vector2( 5, 0),
                new Vector2( 10, 10),
                new Vector2( 10, -10),
                new Vector2( -10, -10)
            }
        },
        // test 28
        new Vector2[][] {
            new Vector2[] {
                new Vector2( 10, 10),
                new Vector2( 10, -10),
                new Vector2( 5, 0),
                new Vector2( 0, -5),
                new Vector2( 10, -10),
                new Vector2( -10, -10),
                new Vector2( -10, 10)
            }
        },
        // test 29
        new Vector2[][] {
            new Vector2[] {
                new Vector2( 10, 10),
                new Vector2( 10, -10),
                new Vector2( -10, -10),
                new Vector2( 0, -5),
                new Vector2( -5, 0),
                new Vector2( -10, -10),
                new Vector2( -10, 10)
            }
        },
        // test 30
        new Vector2[][] {
            new Vector2[] {
                new Vector2( -10, 10),
                new Vector2( -5, 0),
                new Vector2( 0, 5),
                new Vector2( -10, 10),
                new Vector2( 10, 10),
                new Vector2( 10, -10),
                new Vector2( -10, -10)
            }
        },
        // test 31
        new Vector2[][] {
            new Vector2[] {
                new Vector2(32,  0),                  // 0
                new Vector2(21.02803f, -4.182736f),
                new Vector2(29.56414f, -12.24587f),
                new Vector2(35.38735f, -23.64507f),
                new Vector2(22.62741f, -22.62741f),
                new Vector2(11.91142f, -17.82671f),    // 5
                new Vector2(12.24587f, -29.56414f),
                new Vector2(8.303045f, -41.74222f),
                new Vector2(0f, -32),
                new Vector2(-4.182734f, -21.02804f),
                new Vector2(-12.24586f, -29.56413f),   // 10
                new Vector2(-23.64507f, -35.38735f),
                new Vector2(-22.62742f, -22.62742f),
                new Vector2(-17.82671f, -11.91142f),
                new Vector2(-29.56416f, -12.24587f),
                new Vector2(-41.74223f, -8.303034f),   // 15
                new Vector2(-32f, 0f),
                new Vector2(-21.02803f, 4.182745f),    // 17
                new Vector2(-29.56418f, 12.2459f),
                new Vector2(-35.38733f, 23.64509f),
                new Vector2(-22.62736f, 22.62739f),    // 20
                new Vector2(-11.91141f, 17.82672f),    // 21
                new Vector2(-12.24587f, 29.56422f),
                new Vector2(-8.303008f, 41.74223f),
                new Vector2(0f, 32f),
                new Vector2(4.182758f, 21.02803f),     // 25
                new Vector2(12.24594f, 29.56422f),
                new Vector2(23.64511f, 35.38732f),
                new Vector2(22.62737f, 22.62731f),
                new Vector2(17.82672f, 11.9114f),
                new Vector2(29.56428f, 12.24587f),     // 30
                new Vector2(41.74223f, 8.30298f)
            },
            new Vector2[] {
                new Vector2(20.87112f, 4.15149f),
                new Vector2(14.78214f, 6.122937f),
                new Vector2(8.913362f, 5.9557f),
                new Vector2(11.31368f, 11.31366f),     // 35
                new Vector2(11.82256f, 17.69366f),
                new Vector2(6.12297f, 14.78211f),
                new Vector2(2.091379f, 10.51402f),
                new Vector2(0f, 16f),
                new Vector2(-4.151504f, 20.87111f),    // 40
                new Vector2(-6.122936f, 14.78211f),
                new Vector2(-5.955706f, 8.913358f),
                new Vector2(-11.31368f, 11.3137f),     // 43
                new Vector2(-17.69367f, 11.82255f),
                new Vector2(-14.78209f, 6.12295f),     // 45
                new Vector2(-10.51402f, 2.091372f),
                new Vector2(-16f, 0f),
                new Vector2(-20.87111f, -4.151517f),   // 48
                new Vector2(-14.78208f, -6.122935f),
                new Vector2(-8.913354f, -5.955712f),
                new Vector2(-11.31371f, -11.31371f),
                new Vector2(-11.82253f, -17.69367f),
                new Vector2(-6.12293f, -14.78207f),
                new Vector2(-2.091367f, -10.51402f),
                new Vector2(0f, -16f),
                new Vector2(4.151523f, -20.87111f),
                new Vector2(6.122935f, -14.78207f),
                new Vector2(5.955712f, -8.913354f),
                new Vector2(11.31371f, -11.31371f),
                new Vector2(17.69367f, -11.82254f),
                new Vector2(14.78207f, -6.122935f),
                new Vector2(10.51402f, -2.091368f),
                new Vector2(16f, 0f)
            }
        },
        // test 32
        new Vector2[][] {
            new Vector2[] {
                new Vector2(32f, 0),                  // 0
                new Vector2(16.63412f, -3.308732f),    // 1
                new Vector2(29.56414f, -12.24587f),    // 2
                new Vector2(39.11233f, -26.13403f),    // 3
                new Vector2(22.62741f, -22.62741f),    // 4
                new Vector2(9.42247f, -14.10172f),     // 5
                new Vector2(12.24587f, -29.56414f),    // 6
                new Vector2(9.177051f, -46.13614f),    // 7
                new Vector2(0f, -32f),                 // 8
                new Vector2(-3.30873f, -16.63412f),    // 9
                new Vector2(-12.24586f, -29.56413f),   // 10
                new Vector2(-26.13402f, -39.11234f),   // 11
                new Vector2(-22.62742f, -22.62742f),   // 12
                new Vector2(-14.10172f, -9.42247f),    // 13
                new Vector2(-29.56417f, -12.24587f),   // 14
                new Vector2(-46.13614f, -9.177038f),   // 15
                new Vector2(-32f, 0f),                 // 16
                new Vector2(-16.63412f, 3.308738f),    // 17
                new Vector2(-29.56419f, 12.24591f),    // 18
                new Vector2(-39.11232f, 26.13405f),    // 19
                new Vector2(-22.62735f, 22.62738f),    // 20
                new Vector2(-9.422461f, 14.10173f),    // 21
                new Vector2(-12.24588f, 29.56424f),    // 22
                new Vector2(-9.177009f, 46.13615f),    // 23
                new Vector2(0f, 32),                  // 24
                new Vector2(3.308749f, 16.63411f),     // 25
                new Vector2(12.24596f, 29.56426f),     // 26
                new Vector2(26.13407f, 39.1123f),      // 27
                new Vector2(22.62734f, 22.62728f),     // 28
                new Vector2(14.10174f, 9.422452f),     // 29
                new Vector2(29.56433f, 12.24589f),     // 30
                new Vector2(46.13615f, 9.176978f)      // 31
            },
            new Vector2[] {
                new Vector2(23.06808f, 4.588489f),     // 32
                new Vector2(14.78216f, 6.122947f),     // 33
                new Vector2(7.050869f, 4.711226f),     // 34
                new Vector2(11.31367f, 11.31364f),     // 35
                new Vector2(13.06704f, 19.55615f),     // 36
                new Vector2(6.122978f, 14.78213f),     // 37
                new Vector2(1.654375f, 8.317057f),     // 38
                new Vector2(0f, 16f),                  // 39
                new Vector2(-4.588504f, 23.06807f),    // 40
                new Vector2(-6.122941f, 14.78212f),    // 41
                new Vector2(-4.71123f, 7.050865f),     // 42
                new Vector2(-11.31367f, 11.31369f),    // 43
                new Vector2(-19.55616f, 13.06702f),    // 44
                new Vector2(-14.7821f, 6.122953f),     // 45
                new Vector2(-8.317058f, 1.654369f),    // 46
                new Vector2(-16f, 0f),                 // 47
                new Vector2(-23.06807f, -4.588519f),   // 48
                new Vector2(-14.78208f, -6.122936f),   // 49
                new Vector2(-7.050862f, -4.711235f),   // 50
                new Vector2(-11.31371f, -11.31371f),   // 51
                new Vector2(-13.06701f, -19.55617f),   // 52
                new Vector2(-6.122929f, -14.78206f),   // 53
                new Vector2(-1.654365f, -8.317059f),   // 54
                new Vector2(0f, -16f),                 // 55
                new Vector2(4.588525f, -23.06807f),    // 56
                new Vector2(6.122935f, -14.78207f),    // 57
                new Vector2(4.711235f, -7.050862f),    // 58
                new Vector2(11.31371f, -11.31371f),    // 59
                new Vector2(19.55617f, -13.06701f),    // 60
                new Vector2(14.78207f, -6.122935f),    // 61
                new Vector2(8.317059f, -1.654366f),    // 62
                new Vector2(16f, 0f)                   // 63
            }
        },
        // test 33
        new Vector2[][] {
            new Vector2[] {
                new Vector2( 10.0f,  10.0f),
                new Vector2( 10.0f,  -5.0f),
                new Vector2(  1.0f,   0.0f),
                new Vector2(  5.0f,  -5.0f),
                new Vector2(  3.0f,  -5.0f),
                new Vector2(  5.0f, -10.0f),
                new Vector2(-10.0f, -10.0f)
            }
        },
        // test 34
        new Vector2[][] {
            new Vector2[] {
                new Vector2(0.736572265625f, -0.095703125f),
                new Vector2(0.73583984375f, -0.0986328125f),
                new Vector2(0.740234375f, -0.1005859375f),
                new Vector2(0.739013671875f, -0.10400390625f),
                new Vector2(0.740234375f, -0.102783203125f),
                new Vector2(0.7412109375f, -0.105224609375f),
                new Vector2(0.732177734375f, -0.1015625f),
                new Vector2(0.736572265625f, -0.1044921875f),
                new Vector2(0.73388671875f, -0.10302734375f),
                new Vector2(0.734619140625f, -0.10595703125f),
                new Vector2(0.730224609375f, -0.105712890625f),
                new Vector2(0.730224609375f, -0.109130859375f),
                new Vector2(0.72509765625f, -0.109619140625f),
                new Vector2(0.725830078125f, -0.10791015625f),
                new Vector2(0.722412109375f, -0.108154296875f),
                new Vector2(0.723876953125f, -0.10546875f),
                new Vector2(0.720947265625f, -0.105712890625f),
                new Vector2(0.72314453125f, -0.104248046875f),
                new Vector2(0.722412109375f, -0.10205078125f),
                new Vector2(0.71533203125f, -0.099853515625f),
                new Vector2(0.714111328125f, -0.10302734375f),
                new Vector2(0.7119140625f, -0.10009765625f),
                new Vector2(0.714599609375f, -0.1005859375f),
                new Vector2(0.715087890625f, -0.097412109375f),
                new Vector2(0.7197265625f, -0.0966796875f),
                new Vector2(0.724853515625f, -0.100341796875f),
                new Vector2(0.734130859375f, -0.099853515625f)
            }
        },
        };
    }
}