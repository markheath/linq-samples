<Query Kind="FSharpProgram" />

Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath))

let isOn (state:string[]) isStuckOn (x,y) =
    match x,y with
    | _,_ when x < 0 || y < 0 || x >= state.Length || y >= state.[x].Length -> false
    | _,_ when isStuckOn (x,y) -> true
    | _ -> state.[x].[y] = '#'

let getNeighbourSum (state:string[]) isStuckOn (x,y) =
    [(-1,-1);(0,-1);(1,-1);(-1,0);(1,0);(-1,1);(0,1);(1,1)]
    |> Seq.map (fun (a,b) -> (x+a,y+b))
    |> Seq.filter (isOn state isStuckOn)
    |> Seq.length
    
let getNextValue (state:string[]) isStuckOn (x,y) =
    if isStuckOn (x,y) then '#'
    else
        match getNeighbourSum state isStuckOn (x,y) with
        | 3 -> '#'
        | 2 -> if isOn state isStuckOn (x,y) then '#' else '.' 
        | _ -> '.'

let animate (state:string[]) isStuckOn =
    [|for x in 0..state.Length-1 -> 
        new System.String [|for y in 0..state.[x].Length-1 -> getNextValue state isStuckOn (x,y)|] |]

let countLights (state:string[]) =
    state |> Seq.map (fun r -> r .Replace(".","").Length) |> Seq.sum

let animated state n isStuckOn = [1..n] |> Seq.fold (fun s _ -> animate s isStuckOn) state

let startState = "day18.txt" |> File.ReadAllLines
let testState = [|".#.#.#";"...##.";"#....#";"..#...";"#.#..#";"####.."|]

let cornersOn (x,y) = List.exists ((=) (x,y)) [(0,0);(0,99);(99,0);(99,99)]

animated startState 100 (fun (x,y)->false) |> countLights |> printfn "a: %d" // a: 814    
animated startState 100 cornersOn |> countLights |> printfn "b: %d" // b: 924    

//animated testState 6 |> countLights |> printfn "%d" 
//isOn testState (5,0) |> Dump
//animate testState |> Dump
//animate startState |> printfn "%A"