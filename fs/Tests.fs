module Tests

open System
open Xunit
open GameOfLife

[<Fact>]
let ``a cell has eight neigbours`` () =
    Assert.Equal(8, neigboursOfCell (1, 1) |> List.length)
    
[<Fact>]
let ``two adjacent cells have 10 neigbours`` () =
    Assert.Equal(10, allNeigbours [(1, 1); (1,2)] |> List.length)

[<Fact>]
let ``neigbourhood does not contain the cells iself`` () =
    let all = allNeigbours [(1, 1); (1,2)]
    Assert.DoesNotContain((1, 1), all)
    Assert.DoesNotContain((1, 2), all)

[<Fact>]
let ``a cell in the world is alive`` () =
    Assert.True(isAlive [(1,1)] (1,1))

[<Fact>]
let ``a cell not in the world is not alivealive`` () =
    Assert.False(isAlive [(1,1)] (1,2))

[<Fact>]
let ``a single cell has no living neigbours`` () =
    Assert.Equal(0, livingNeigbours (1, 1) [(1,1)] |> List.length)

[<Fact>]
let ``two adjacent cells have one neigbour each`` () =
    let world = [(1, 1); (1, 2)]
    let neigbourOf11 = livingNeigbours (1, 1) world
    Assert.Equal(1, neigbourOf11 |> List.length)
    Assert.Equal((1,2), List.head neigbourOf11)

    let neigbourOf12 = livingNeigbours (1, 2) world
    Assert.Equal(1, neigbourOf12 |> List.length)
    Assert.Equal((1,1), List.head neigbourOf12)