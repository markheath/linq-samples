<Query Kind="FSharpProgram" />

Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath))

let parseFacts s = 
    [for m in Regex.Matches(s, @"(\w+)\: (\d+)") -> 
        [for g in m.Groups -> g.Value] |> Seq.skip 1 |> Seq.toArray]
    |> Seq.map (fun [|a;b|] -> (a, int b)) |> dict

let clues = parseFacts "children: 3, cats: 7, samoyeds: 2, pomeranians: 3, akitas: 0, vizslas: 0, goldfish: 5, trees: 3, cars: 2, perfumes: 1"
let sues = "day16.txt" |> File.ReadAllLines |> Array.map parseFacts 

//clues |> Dump

let isCandidateA (sue:IDictionary<string,int>) (kvp:KeyValuePair<string,int>) = 
    (not (sue.ContainsKey(kvp.Key))) || (sue.[kvp.Key] = kvp.Value)

let isCandidateB (sue:IDictionary<string,int>) (kvp:KeyValuePair<string,int>) = 
    (match kvp.Key, sue.TryGetValue(kvp.Key) with
    | _, (false, _) -> true
    | "cats", (_,n) | "trees", (_,n) -> n > kvp.Value
    | "pomeranians", (_,n) | "goldfish", (_,n) -> n < kvp.Value
    | _, (_,n) -> n = kvp.Value)

let findSue matcher = sues |> Seq.findIndex (fun s -> clues |> Seq.forall (matcher s)) |> (+) 1
         
findSue isCandidateA |> printfn "a: %d" // 213
findSue isCandidateB |> printfn "b: %d" // 323