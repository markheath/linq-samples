<Query Kind="FSharpProgram" />

Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));

let mutate (sq:string) (replacements:(string*string) list) = seq {
    for pos in [0 .. sq.Length - 1] do
        for (a,b) in replacements do
            if sq.Substring(pos).StartsWith(a) then
                yield sq.Substring(0,pos) + b + sq.Substring(pos+a.Length)            
}

let problemData = "day19.txt" |> File.ReadAllLines

let replacements = 
    problemData
    |> Seq.map (fun s -> s.Split(' '))
    |> Seq.filter (fun a -> a.Length = 3)
    |> Seq.map (fun [|a;b;c|] -> (a,c))
    |> Seq.toList

let medicineMolecule = problemData.[problemData.Length - 1]

mutate medicineMolecule replacements |> Seq.distinct |> Seq.length |> printfn "a: %d" // 509

let rand = new System.Random()

let swap (a: _[]) x y =
    let tmp = a.[x]
    a.[x] <- a.[y]
    a.[y] <- tmp

// shuffle an array (in-place)
let shuffle a =
    Array.iteri (fun i _ -> swap a i (rand.Next(i, Array.length a))) a

// What-a-baller algorithm
// https://www.reddit.com/r/adventofcode/comments/3xflz8/day_19_solutions/cy4cu5b
let search mol (reps:(string*string)[]) = 
    let mutable target = mol
    let mutable mutations = 0

    while not (target = "e") do
        let mutable tmp = target
        for a, b in reps do
            let index = target.IndexOf(b)
            if index >= 0 then
                target <- target.Substring(0, index) + a + target.Substring(index + b.Length)
                mutations <- mutations + 1

        if tmp = target then
            target <- mol
            mutations <- 0
            shuffle reps

    mutations

search medicineMolecule (replacements |> List.toArray) |> printfn "b: %d" // 195

search "XXXX" ([("y","XX");("e","yy");("e","XXXX")] |> List.toArray) |> printfn "broken: %d" 
search "XXXX" ([("y","XX");("e","yy");("e","XXXX")] |> List.rev |> List.toArray) |> printfn "broken: %d" 

//XXXX -> yy -.
// notes A* algorithm