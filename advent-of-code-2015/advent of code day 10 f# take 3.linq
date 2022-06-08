<Query Kind="FSharpProgram" />

let input = "1113122113" 

//input |> Dump

// based on http://stackoverflow.com/a/21753716/7532
let countAdjacent (s:seq<_>) = seq {
    let en = s.GetEnumerator()
    let rec loop current count = seq {
        if en.MoveNext() then
            if current = en.Current then
                yield! loop current (count+1)
            else
                yield (current,count)
                yield! loop en.Current 1
        else 
            yield (current,count)
    }

    if en.MoveNext() then 
        yield! loop en.Current 1  
    }
    
//countAdjacent input |> Dump


let lookAndSay (x:seq<char>) = x 
                            |> countAdjacent 
                            |> Seq.collect (fun (a,b) -> [char (int '0' + b); a]) 
                            
    
//lookAndSay input |> Dump

let getLengthAfterRepetitions repetitions = 
    [1..repetitions]
    |> Seq.fold (fun acc _ -> lookAndSay acc) (input |> Seq.map id)
    |> Seq.length

getLengthAfterRepetitions 40 |> printf "a: %d" // 360154
getLengthAfterRepetitions 50 |> printf "b: %d" // 5103798
// 35 seconds - same as take 2