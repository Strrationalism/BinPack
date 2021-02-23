module BinPack.Test.Tests
open NUnit.Framework
open BinPack.Test.Utils
open BinPack

[<Test>]
let testPut () =
    let result = tryPutRectIntoSpace { W = 100; H = 100; Tag = () } <| Space { X = 0; Y = 0; W = 150; H = 150 }
    printfn "%A" result

[<Test>]
let simple () =
    test "simple" [
        500, 200, 1
        250, 200, 1
        50, 50, 20
    ]

[<Test>]
let tall () =
    test "tall" [
        50, 400, 2
        50, 300, 5
        50, 200, 10
        50, 100, 20
        50, 50, 40
    ]

[<Test>]
let wide () =
    test "wide" [
        400, 50, 2
        300, 50, 5
        200, 50, 10
        100, 50, 20
        50, 50, 40
    ]

[<Test>]
let tallAndWide () =
    test "tallAndWide" [
        100, 400, 3
        400, 100, 3
    ]

[<Test>]
let powersOf2 () =
    test "powersOf2" [
        2, 2, 256
        4, 4, 128
        8, 8, 64
        16, 16, 32
        32, 32, 16
        64, 64, 8
        128, 128, 4
        256, 256, 2
    ]

[<Test>]
let oddAndEven () =
    test "oddAndEven" [
        50, 50, 20
        47, 31, 20
        23, 17, 20
        109, 42, 20
        42, 109, 20
        17, 33, 20
    ]

[<Test>]
let complex () =
    test "complex" [
        100, 100, 3
        60, 60, 3
        50, 20, 20
        20, 50, 20
        250, 250, 1
        250, 100, 1
        100, 250, 1
        400, 80, 1
        80, 400, 1
        10, 10, 100
        5, 5, 500
    ]