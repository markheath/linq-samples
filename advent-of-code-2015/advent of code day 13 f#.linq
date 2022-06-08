<Query Kind="FSharpProgram" />

let testInput = @"Alice would gain 54 happiness units by sitting next to Bob.
Alice would lose 79 happiness units by sitting next to Carol.
Alice would lose 2 happiness units by sitting next to David.
Bob would gain 83 happiness units by sitting next to Alice.
Bob would lose 7 happiness units by sitting next to Carol.
Bob would lose 63 happiness units by sitting next to David.
Carol would lose 62 happiness units by sitting next to Alice.
Carol would gain 60 happiness units by sitting next to Bob.
Carol would gain 55 happiness units by sitting next to David.
David would gain 46 happiness units by sitting next to Alice.
David would lose 7 happiness units by sitting next to Bob.
David would gain 41 happiness units by sitting next to Carol.".Split('\n')
let path = Path.GetDirectoryName(Util.CurrentQueryPath) + "\\day13.txt"
let realInput = path |> File.ReadAllLines

let parseRule rule =
    let p = Regex.Match(rule, @"(\w+) would (lose|gain) (\d+) happiness units by sitting next to (\w+)\.")
                    .Groups
                    |> Seq.cast<Group>
                    |> Seq.skip 1
                    |> Seq.map (fun g -> g.Value)
                    |> Seq.toArray
    (p.[0],p.[3]), (int p.[2]) * (match p.[1] with | "lose" -> -1 | _ -> 1) 
    
let rules = realInput
            |> Seq.map parseRule
            |> Seq.toList

// Jon Harrop F# for Scientists ( http://stackoverflow.com/a/3129136/7532
let rec distribute e = function
  | [] -> [[e]]
  | x::xs' as xs -> (e::xs)::[for xs in distribute e xs' -> x::xs]

let rec permute = function
  | [] -> [[]]
  | e::xs -> List.collect (distribute e) (permute xs)

let findHappiestSeatingPlan rules = 

    let people = rules |> Seq.map (fun ((a,b),g) -> a) |> Seq.distinct |> Seq.toList 
    let lookup = rules |> dict
    let getPairHappiness (a,b) =
        if lookup.ContainsKey (a,b) then lookup.[(a,b)] + lookup.[(b,a)] else 0

    let first = people.Head
    people.Tail
    |> permute
    |> List.map (fun p -> (first::p, seq { yield first; yield! p; yield first } 
                            |> Seq.pairwise |> Seq.sumBy getPairHappiness))
    |> Seq.maxBy snd

findHappiestSeatingPlan rules |> Dump // 664

findHappiestSeatingPlan ((("Mark",""),0)::rules) |> Dump // 640
