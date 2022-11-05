module GameOfLife

let isAlive world cell =
   List.contains cell world

let neigboursOfCell (x, y) =
    [ 
      (x - 1, y - 1); (x, y - 1); (x + 1, y - 1);
      (x - 1, y    );             (x + 1, y    );
      (x - 1, y + 1); (x, y + 1); (x + 1, y + 1)
    ]

let livingNeigbours cell world= 
    neigboursOfCell cell 
    |> List.filter (isAlive world)

let diesDueToUnderpopulation world cell =
    livingNeigbours cell world |> List.length < 2

let diesDueToUOverpopulation world cell =
    livingNeigbours cell world |> List.length > 3 

let respawns world cell =
    livingNeigbours cell world |> List.length = 3

let staysAlive world cell =
    livingNeigbours cell world  |> List.length = 2 || livingNeigbours cell world |> List.length = 3


let dyingCells world =
    List.filter (diesDueToUnderpopulation world) world @ List.filter (diesDueToUOverpopulation world) world
    |> Seq.distinct
    |> List.ofSeq

let remainingCells world =
    List.filter (staysAlive world) world
    |> Seq.distinct
    |> List.ofSeq

let allNeigbours world =
    world 
    |> List.map neigboursOfCell
    |> List.collect id
    |> List.except world
    |> Seq.distinct
    |> List.ofSeq

let respawningCells world =
    allNeigbours world |> List.filter (respawns world)
    |> Seq.distinct
    |> List.ofSeq

let next world =
    List.except (dyingCells world) world @ remainingCells world @ respawningCells world
    |> Seq.distinct
    |> List.ofSeq



let render world =
    let maxX = world |> List.map (fun (x, y) -> x) |> List.max
    let maxY =  world |> List.map (fun (x, y) -> y) |> List.max
    let mutable result = ""
    result <- maxX.ToString() + " " + maxY.ToString()
    for y in [0 .. maxY] do
        result <- result + "\r\n"
        for x in [0 .. maxX] do
            result <- result + (if isAlive world (x, y) then "X" else ".")

    result

let glider = [  
            (2, 1) ;
                    (3, 2) ;
    (1, 3); (2,3);  (3,3)  

]

let blinker = [
    (1, 1); (2, 1); (3, 1)
]

