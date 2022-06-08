<Query Kind="FSharpProgram" />

// F# port of Python solution by godarderik 
// https://www.reddit.com/r/adventofcode/comments/3y1s7f/day_24_solutions/cy9srkh

// combinations function from tomas petricek 
// http://stackoverflow.com/a/4495708/7532
let rec combinations acc size set = seq {
  match size, set with 
  | n, x::xs -> 
      if n > 0 then yield! combinations (x::acc) (n - 1) xs
      if n >= 0 then yield! combinations acc n xs 
  | 0, [] -> yield acc 
  | _, [] -> () }

let comb size set = combinations[] size set

let sum = Seq.sum
let list = Seq.toList

// n.b. gets minimum QE by virtue of starting looking for smallest groups,
// and assumes combinations come out in minimum order too?
let rec hasSum lst tot parts sub = 
    [1 .. (List.length lst) / sub]
    |> Seq.collect (fun y -> comb y lst)
    |> Seq.pick (fun x -> 
            if sum x = tot && sub = 2 then
                Some 1L
            elif sum x = tot && sub < parts then
                Some (hasSum (list (set lst - set x)) tot parts (sub - 1))
            elif sum x = tot && hasSum (list (set lst - set x)) tot parts (sub - 1) = 1L then
                Some (x |> Seq.map int64 |> Seq.reduce (*))
            else
                None
    )

let getMinQE lst parts =
    let tot = (sum lst) / parts
    hasSum lst tot parts parts

let nums = [1;2;3;5;7;13;17;19;23;29;31;37;41;43;53;59;61;67;71;73;79;83;89;97;101;103;107;109;113]
let parts = 4

getMinQE nums 3 |> printfn "a: %d" // 10723906903
getMinQE nums 4 |> printfn "b: %d" // 74850409