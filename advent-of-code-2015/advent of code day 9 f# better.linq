<Query Kind="FSharpProgram" />

type route = {
    path : string list
    distance : int
}

let testInput = ["London to Dublin = 464";"London to Belfast = 518";"Dublin to Belfast = 141"]

let path = Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath),"day9.txt")
//let path = @"C:\Users\mheath\OneDrive\Documents\LINQPad Queries\Advent of Code\day9.txt"
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
    
let getDistanceR currentRoute target =
    match currentRoute.path with
        | [] -> 0
        | h::tail -> getDistance (h,target)

let shortest test best = 
    match best with
    | None -> test
    | Some route -> if test.distance < route.distance then test else route

let isShortestCandidate distance bestRoute = 
    match bestRoute with
    | None -> true
    | Some route -> distance < route.distance

let rec findRoute currentRoute toVisit (bestRoute:route option) =
    let mutable br = bestRoute
    //printfn "%A" currentRoute
    for p in toVisit do
        let distanceToP = getDistanceR currentRoute p
        let stillToVisit = (toVisit |> List.filter (fun f-> f <> p))
        let testRoute = { path = p::currentRoute.path; distance = currentRoute.distance + distanceToP }
        if stillToVisit = [] then
            // a complete route
            br <- Some (shortest testRoute br)
        elif isShortestCandidate (distanceToP + currentRoute.distance) br then
            let bestChildRoute = findRoute testRoute stillToVisit br
            match bestChildRoute with
                | Some r -> br <- Some (shortest r br)
                | None -> ()
    br

findRoute { path = []; distance = 0 } places None
    |> printfn "ROUTE: %A"