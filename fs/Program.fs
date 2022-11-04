open System
open GameOfLife

let mutable world = glider
while true do
    world <- next world
    Console.Clear()
    Console.Write (render world)
    Console.ReadLine();