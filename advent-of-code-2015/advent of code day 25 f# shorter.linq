<Query Kind="FSharpProgram" />

seq { for d in Seq.initInfinite id do for c in 1..d do yield d - c + 1, c }
|> Seq.takeWhile (((=) (2978,3083)) >> not)
|> Seq.fold(fun a _-> (a * 252533L) % 33554393L) 20151125L
|> printfn "Day 25: %i" // 2650453