<Query Kind="FSharpProgram" />

let getCode start row col  =
    Seq.initInfinite id
    |> Seq.collect (fun d -> [1..d] |> Seq.map (fun c -> (d-c+1,c)))
    |> Seq.takeWhile (fun (r,c) -> not (r = row && c = col))
    |> Seq.fold (fun acc _ -> (acc * 252533L) % 33554393L) start
    //|> Seq.scan (fun acc _ -> (acc * 252533L) % 33554393L) start

getCode 20151125L 2978 3083
    |> printfn "Day 25: %i" // 2650453
