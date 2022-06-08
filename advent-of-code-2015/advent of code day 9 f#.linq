<Query Kind="FSharpProgram" />

let testInput = ["London to Dublin = 464";"London to Belfast = 518";"Dublin to Belfast = 141"]

let path = Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath),"day9.txt")
let realInput = path |> File.ReadAllLines |> Seq.toList

let (=~) input pattern =
    Regex.Match(input, pattern).Groups.Cast<Group>()
        |> Seq.skip 1
        |> Seq.map (fun g -> g.Value)
        |> Seq.toArray
    
let parseInput (i:string) =
    seq { 
        let [| a; b; dist |] = i =~ @"^(\w+) to (\w+) = (\d+)"
        yield ((a,b),int dist)
        yield ((b,a),int dist) }
    
let distances = 
    realInput
    |> Seq.collect parseInput
    |> dict

let getDistance key =
    distances.[key]

let places =
    distances.Keys
    |> Seq.map (fun (a,b) -> a)
    |> Seq.distinct 
    |> Seq.toList
    
// Jon Harrop F# for Scientists ( http://stackoverflow.com/a/3129136/7532
let rec distribute e = function
  | [] -> [[e]]
  | x::xs' as xs -> (e::xs)::[for xs in distribute e xs' -> x::xs]

let rec permute = function
  | [] -> [[]]
  | e::xs -> List.collect (distribute e) (permute xs)
  

let getRouteLength route =
    route
    |> Seq.pairwise
    |> Seq.map getDistance //(fun (a,b) -> getDistance a b)
    |> Seq.sum

//places |> permute |> Dump
//getDistance ("London","Dublin") |> Dump
//getDistance ("London","Belfast") |> Dump
//getDistance ("Belfast","Dublin") |> Dump

let routeLengths =
    places
    |> permute
    |> List.map getRouteLength

routeLengths
    |> Seq.min
    |> printfn "a: %d" // 207

routeLengths
    |> Seq.max
    |> printfn "b: %d" // 804
    
// optimization ideas
// 1) distance lookup dictionary or 2d array
// 2) halve the permutations (a->b->c is same as c->b->a)
// 3) abandon long routes early
// 4) sort to try short routes first?

// notes:
// Travelling Salesman Problem