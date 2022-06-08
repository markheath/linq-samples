<Query Kind="FSharpProgram" />

Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));
open System.IO
Directory.SetCurrentDirectory(@"C:\Users\Mark\OneDrive\Documents\LINQPad Queries\Advent of Code");

let replace (sq:string) (replacements:(string*string) list) = seq {
    for pos in [0 .. sq.Length - 1] do
        for (a,b) in replacements do
            // if sq.Substring(pos,a.Length) = a then
            if sq.Substring(pos).StartsWith(a) then
                yield sq.Substring(0,pos) + b + sq.Substring(pos+a.Length)            
}

let rec search (startingPoint:string) (target:string) replacements mutations =
    //printfn "m%d: %s" mutations startingPoint
    if startingPoint = target then mutations
    elif startingPoint.Length > target.Length then -1
    else
        let mutable foundAfter = -1
        for r in replace startingPoint replacements do
            if foundAfter = -1 then
                foundAfter <- search r target replacements (mutations + 1)
        foundAfter

let rec search2 (startingPoint:string) (target:string) replacements mutations = seq {
    //printfn "m%d: %s" mutations startingPoint
    if startingPoint = target then 
        printfn "found after %d" mutations
        yield mutations
    elif startingPoint.Length > target.Length then ()
    else
        for r in replace startingPoint replacements do
            yield! search2 r target replacements (mutations + 1)
    }

let rec revsearch (startingPoint:string) (target:string) replacements mutations = seq {
    //printfn "m%d: %s" mutations startingPoint
    if startingPoint = target then 
        printfn "found after %d" mutations
        yield mutations
    else
        for r in replace startingPoint replacements do
            yield! revsearch r target replacements (mutations + 1)
    }

//replace startSequence |> Dump
let testReplacements = [("H","OH");("H","HO");("O","HH")]
//replace "HOH" testReplacements |> Seq.distinct |> Seq.length |> printfn "a: %d" // 4
replace "HOHOHO" testReplacements |> Seq.distinct |> Seq.length |> printfn "a: %d" // 7
let problemData = "day19.txt" |> File.ReadAllLines

let replacements = 
    problemData
    |> Seq.map (fun s -> s.Split(' '))
    |> Seq.filter (fun a -> a.Length = 3)
    |> Seq.map (fun [|a;b;c|] -> (a,c))
    |> Seq.toList

let medicineMolecule = problemData.[problemData.Length - 1]

replace medicineMolecule replacements |> Seq.distinct |> Seq.length |> printfn "a: %d" // 509

let rand = new System.Random()

let swap (a: _[]) x y =
    let tmp = a.[x]
    a.[x] <- a.[y]
    a.[y] <- tmp

// shuffle an array (in-place)
let shuffle a =
    Array.iteri (fun i _ -> swap a i (rand.Next(i, Array.length a))) a


let wbAlgo mol (reps:(string*string)[]) = 
    let mutable target = mol
    let mutable part2 = 0

    while not (target = "e") do
        let mutable tmp = target
        for a, b in reps do
            let index = target.IndexOf(b)
            if index >= 0 then
                target <- target.Substring(0, index) + a + target.Substring(index + b.Length)
                part2 <- part2 + 1

        if tmp = target then
            target <- mol
            part2 <- 0
            shuffle reps

    part2


let testReplacements2 = [("e","H");("e","O");("H","OH");("H","HO");("O","HH")]            
//search "e" "HOHOHO" testReplacements2 0 |> printfn "part b test : %d"
//search2 "e" "HOHOHO" testReplacements2 0 |> Seq.min |> printfn "part b test: %d"
let revRep r = r |> List.map (fun (a,b) -> (b,a))
revsearch "HOHOHO" "e" (revRep testReplacements2) 0 |> Seq.min |> printfn "part b rev test: %d"
//search "e" medicineMolecule replacements 0 |> printfn "part b : %d"
//search2 "e" medicineMolecule replacements 0 |> Seq.min |> printfn "part b: %d"
//revsearch medicineMolecule "e" (revRep replacements) 0 |> Seq.min |> printfn "part b: %d"
wbAlgo medicineMolecule (replacements |> List.toArray) |> printfn "partb wbAlgo %d"