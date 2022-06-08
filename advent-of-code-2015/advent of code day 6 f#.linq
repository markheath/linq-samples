<Query Kind="FSharpProgram" />

let instructions = File.ReadAllLines(
                    Path.GetDirectoryName(Util.CurrentQueryPath) +
                    "\\day6.txt")
let turnOn n = n + 1
let turnOff n = max (n - 1) 0
let toggle n = n + 2

let selectAction = function 
    | "turn on" -> turnOn 
    | "turn off" -> turnOff
    | "toggle" -> toggle

let parseInstruction actionSelector i =
    let pattern = @"(turn on|toggle|turn off)\ (\d+)\,(\d+)\ through\ (\d+)\,(\d+)"
    let groups = Regex.Match(i, pattern).Groups
    let action = actionSelector groups.[1].Value
    let fromPos = (int groups.[2].Value), (int groups.[3].Value)
    let toPos = (int groups.[4].Value), (int groups.[5].Value)
    (action, fromPos, toPos)
    
let expandPositions (x0,y0) (x1,y1) =
    seq { for x in x0 .. x1 do
          for y in y0 .. y1 do
          yield (x,y) }

let applyAction (acc:int[,]) (action,(x,y)) =
    acc.[x,y] <- action acc.[x,y]
    acc

let calculate actionSelector (input:string[]) =
    let startState = Array2D.create 1000 1000 0
    input
        |> Seq.map (parseInstruction actionSelector)
        |> Seq.collect (fun (action,fromPos,toPos) -> 
            seq { for pos in (expandPositions fromPos toPos) do
                    yield (action,pos) })
    	|> Seq.fold applyAction startState
        |> Seq.cast<int> // same trick works to flatten 2d array
        |> Seq.sum

calculate selectAction instructions |> Dump

let turnOnA n = 1
let turnOffA n = 0
let toggleA n = if n = 0 then 1 else 0

let selectActionA = function
    | "turn on" -> turnOnA
    | "turn off" -> turnOffA
    | "toggle" -> toggleA

calculate selectActionA instructions |> Dump

    
// (a) lights on 543903
// (b) Brightness is 14687245

(*        |> Seq.collect (fun (action,fromPos,toPos) -> 
            (expandPositions fromPos toPos) 
            |> Seq.map (fun pos -> (action, pos)))*)