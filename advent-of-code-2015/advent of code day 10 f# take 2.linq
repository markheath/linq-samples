<Query Kind="FSharpProgram" />

let input = "1113122113" |> Seq.map (fun f -> int f - int '0') |> Seq.toArray

//input |> Dump

// fold state is a list of 2 element arrays [|count;number|] to make collect easy
let countAdjacent = 
    Seq.fold (fun s x -> 
        match s with
        | [|n;c|]::tail when c = x -> [|n+1;c|]::tail
        | l -> [|1;x|]::l) []
    >> List.rev

//countAdjacent input |> Dump


let lookAndSay = countAdjacent >> Seq.collect id >> Seq.toArray
    
//lookAndSay input |> Dump

let getLengthAfterRepetitions repetitions = 
    [1..repetitions]
    |> Seq.fold (fun acc _ -> lookAndSay acc) input 
    |> Seq.length

getLengthAfterRepetitions 40 |> printf "a: %d" // 360154
getLengthAfterRepetitions 50 |> printf "b: %d" // 5103798