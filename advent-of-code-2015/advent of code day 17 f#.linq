<Query Kind="FSharpProgram" />

Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath))
let containers = "day17.txt" |> File.ReadAllLines |> Seq.map int |> Seq.toList

let rec distribute used pool target runningTotal = seq {
    match pool with 
    | h::tail ->
        if h + runningTotal = target then 
            yield h::used |> List.toArray
        elif h + runningTotal < target then 
            yield! distribute (h::used) tail target (h + runningTotal)
        yield! distribute used tail target runningTotal
    | _ -> ()

    }

let perms = distribute [] containers 150 0 |> Seq.toArray

perms.Length |> printfn "a: %d"
let m = perms |> Seq.map (fun f -> f.Length) |> Seq.min
perms |> Seq.filter (fun a -> a.Length = m) |> Seq.length |> printfn "b: %d"