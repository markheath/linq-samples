<Query Kind="FSharpProgram" />

Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath))

let parseFacts s = 
    [for m in Regex.Matches(s, @"(\w+)\: (\d+)") -> 
        [for g in m.Groups -> g.Value] |> Seq.skip 1 |> Seq.toArray]
    |> Seq.map (fun [|a;b|] -> (a, int b)) 

let sues = "day16.txt" |> File.ReadAllLines |> Array.map parseFacts 
let clues = parseFacts "children: 3, cats: 7, samoyeds: 2, pomeranians: 3, akitas: 0, vizslas: 0, goldfish: 5, trees: 3, cars: 2, perfumes: 1" |> Map.ofSeq

let f1 (t, n) = clues.[t] = n

let f2 (t, n) = 
    match t with
    | "cats" | "trees" -> n > clues.[t]
    | "pomeranians" |"goldfish" -> n < clues.[t]
    | _ -> n = clues.[t]

let find f = sues |> Array.findIndex (fun traits -> traits |> Seq.forall f) |> (+) 1

find f1 |> printfn "a: %d"
find f2 |> printfn "b: %d"