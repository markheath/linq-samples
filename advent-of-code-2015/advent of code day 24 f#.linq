<Query Kind="FSharpProgram" />

let mutable bestSoFar = 0
let rec distribute used pool target runningTotal ulen = seq {
    if ulen >= bestSoFar then () else
    match pool with
    | h::tail ->
        if h + runningTotal = target then
            bestSoFar <- min bestSoFar (ulen + 1)
            yield h::used
        elif h + runningTotal < target then
            yield! distribute (h::used) tail target (h + runningTotal) (ulen+1)
        yield! distribute used tail target runningTotal ulen
    | _-> ()
}

let findBestQE presents groups =
    let totalWeight = presents |> List.sum
    let weightPerSet = totalWeight / groups
    bestSoFar <- ((List.length presents) / (int groups)) + 1
    let bestSet = 
        distribute [] presents weightPerSet 0L 0
        |> Seq.map (fun g -> (List.length g), (List.reduce (*) g))
        |> Seq.sortBy id
        |> Seq.head
    bestSet |> Dump
    snd bestSet

let presents = [1;2;3;5;7;13;17;19;23;29;31;37;41;43;53;59;61;67;71;73;79;83;89;97;101;103;107;109;113] |> List.map int64

findBestQE presents 3L |> printfn "a: %d" // 10723906903
findBestQE presents 4L |> printfn "b: %d" // 74850409