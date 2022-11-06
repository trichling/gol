module Tests

open System
open Xunit
open GameOfLife

[<Fact>]
let ``a cell in the world is alive`` () =
    Assert.True(isAlive [(1,1)] (1,1))

[<Fact>]
let ``a cell not in the world is not alivealive`` () =
    Assert.False(isAlive [(1,1)] (1,2))

[<Fact>]
let ``a cell has eight neigbours`` () =
    Assert.Equal(8, neigboursOfCell (1, 1) |> List.length)

[<Fact>]
let ``a single cell has no living neigbours`` () =
    Assert.Equal(0, livingNeigbours (1, 1) [(1,1)] |> List.length)

[<Fact>]
let ``two adjacent cells have one living neigbour each`` () =
    let world = [(1, 1); (1, 2)]
    let neigbourOf11 = livingNeigbours (1, 1) world
    Assert.Equal(1, neigbourOf11 |> List.length)
    Assert.Equal((1,2), List.head neigbourOf11)

    let neigbourOf12 = livingNeigbours (1, 2) world
    Assert.Equal(1, neigbourOf12 |> List.length)
    Assert.Equal((1,1), List.head neigbourOf12)

[<Fact>]
let ``a cell with no neigbour dies du to underpopulation`` () =
    let world = [(1,1)]
    Assert.Equal(0, livingNeigbours (1, 1) world |> List.length)
    Assert.True(diesDueToUnderpopulation world (1,1))

[<Fact>]
let ``a cell with one neigbour dies du to underpopulation`` () =
    let world = [(1,1); (1,2)]
    Assert.Equal(1, livingNeigbours (1, 1) world |> List.length)
    Assert.True(diesDueToUnderpopulation world (1,1))

[<Fact>]
let ``a cell with two neigbour stays alive`` () =
    let world = [(1,1); (1,2); (1,3)]
    Assert.Equal(2, livingNeigbours (1, 2) world |> List.length)
    Assert.True(staysAlive world (1,2))

[<Fact>]
let ``a cell with three neigbour stays alive`` () =
    let world = [(1,1); (1,2); (1,3); (2,2)] 
    Assert.Equal(3, livingNeigbours (1, 2) world |> List.length)
    Assert.True(staysAlive world (1,2))

[<Fact>]
let ``a cell with four neigbour does not stay alive`` () =
    let world = [(1,1); (1,2); (1,3); (2,2); (0,2)] 
    Assert.Equal(4, livingNeigbours (1, 2) world |> List.length)
    Assert.False(staysAlive world (1,2))

[<Fact>]
let ``a cell respawns if it has three neigbours`` () =
    let world = [(1,1); (1,3); (2,2)] 
    Assert.Equal(3, livingNeigbours (1, 2) world |> List.length)
    Assert.True(respawns world (1,2))

[<Fact>]
let ``a cell does not respawn with four neigbours`` () =
    let world = [(1,1); (1,3); (2,2); (0,2)] 
    Assert.Equal(4, livingNeigbours (1, 2) world |> List.length)
    Assert.False(respawns world (1,2))

[<Fact>]
let ``dying cells are a union of over and underpopulation`` () =
    let world = [(1,1); (1,2); (1,3); (2,2); (0,2); (5,5); (5,6)] 
    let dying = dyingCells world
    Assert.False(respawns world (1,2))

[<Fact>]
let ``two adjacent cells have 10 neigbours`` () =
    Assert.Equal(10, allNeigbours [(1, 1); (1,2)] |> List.length)

[<Fact>]
let ``neigbourhood does not contain the cells iself`` () =
    let all = allNeigbours [(1, 1); (1,2)]
    Assert.DoesNotContain((1, 1), all)
    Assert.DoesNotContain((1, 2), all)