module GameOfLifeWithCellType

type Cell = { X : int; Y : int}

let cell x y =
    { X = x; Y = y}

let neigboursOfCell (cell : Cell) =
    [ 
      { X = cell.X - 1 ; Y = cell.Y - 1}; { X = cell.X; Y = cell.Y - 1}; { X = cell.X + 1; Y = cell.Y - 1};
      { X = cell.X - 1 ; Y = cell.Y};                                    { X = cell.X + 1; Y = cell.Y };
      { X = cell.X - 1 ; Y = cell.Y + 1}; { X = cell.X; Y = cell.Y + 1}; { X = cell.X + 1; Y = cell.Y + 1}
    ]

let neigboursOf (x, y) =
    [ 
      (x - 1, y - 1); (x, y - 1); (x + 1, y - 1);
      (x - 1, y    );             (x + 1, y    );
      (x - 1, y + 1); (x, y + 1); (x + 1, y + 1)
    ]

let allNeigbours (world : Cell list) =
    List.map neigboursOfCell world 
    |> Seq.distinct
    |> List.ofSeq
    |> List.collect id

let isAlive world cell =
   List.contains cell world

let livingNeigbours (cell : Cell) (world : Cell list) = 
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

let respawningCells world =
    allNeigbours world |> List.filter (respawns world)
    |> Seq.distinct
    |> List.ofSeq

let next world =
    List.except (dyingCells world) world @ remainingCells world @ respawningCells world
    |> Seq.distinct
    |> List.ofSeq



let render world =
    let maxX = (List.maxBy (fun c -> c.X) world).X
    let maxY = (List.maxBy (fun c -> c.Y) world).Y
    let mutable result = ""
    result <- maxX.ToString() + " " + maxY.ToString()
    for y in [0 .. maxY] do
        result <- result + "\r\n"
        for x in [0 .. maxX] do
            result <- result + (if isAlive world (cell x y) then "X" else ".")

    result

let glider : Cell list = [  
                     { X = 2; Y = 1} ;
                                      { X = 3; Y = 2 } ;
    { X = 1; Y = 3}; { X = 2; Y = 3}; { X = 3; Y = 3}  

]

let reversegGlider : Cell list = [  
                     { X = 2; Y = 1} ;
    { X = 1; Y = 2 } ;
    { X = 1; Y = 3}; { X = 2; Y = 3}; { X = 3; Y = 3}  

]

let blinker = [
    { X = 1; Y = 3}; { X = 2; Y = 3}; { X = 3; Y = 3} 
]
