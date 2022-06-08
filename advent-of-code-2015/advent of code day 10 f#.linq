<Query Kind="FSharpProgram" />

let input = "1113122113" |> Seq.map (fun f -> int f - int '0') |> Seq.toArray

//input |> Dump

let countAdjacent numbers = seq {
    let mutable current = None
    let mutable count = 0
    for n in numbers do
        match current with
        | None -> 
            current <- Some n
            count <- 1
        | Some (x) when x = n -> count <- count + 1
        | Some (x) -> 
            yield (x,count)
            current <- Some n
            count <- 1
    if count > 0 then
        yield (current.Value,count)
    }

//countAdjacent input |> Dump


let lookAndSay numbers =
    numbers |> countAdjacent |> Seq.collect (fun (a,b) -> [b;a]) |> Seq.toArray
    
//lookAndSay input |> Dump

let getLengthAfterRepetitions repetitions = 
    [1..repetitions]
    |> Seq.fold (fun acc _ -> lookAndSay acc) input 
    |> Seq.length

getLengthAfterRepetitions 40 |> printf "a: %d" // 360154
getLengthAfterRepetitions 50 |> printf "b: %d" // 5103798

