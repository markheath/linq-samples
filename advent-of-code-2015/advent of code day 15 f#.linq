<Query Kind="FSharpProgram" />

let input = [|"Frosting: capacity 4, durability -2, flavor 0, texture 0, calories 5";
    "Candy: capacity 0, durability 5, flavor -1, texture 0, calories 8";
    "Butterscotch: capacity -1, durability 0, flavor 5, texture 0, calories 6";
    "Sugar: capacity 0, durability 0, flavor -2, texture 2, calories 1"|]

let ingredients = input |> Array.map (fun f -> [| for m in Regex.Matches(f,"\-?\d+") -> int m.Value |]) 

let rec distribute state total maxlen = seq {
    let remaining = total - (Seq.sum state)
    
    match List.length state with
        | l when l = maxlen - 1 -> yield remaining::state
        | _ -> for n in 0..remaining do yield! distribute (n::state) total maxlen
}            

//let inline (++) a b = Array.map2 (+) a b
//let sumArrays a = a |> Seq.reduce (++) 

let scoreCookie amounts = 
    let p = ingredients 
            |> Seq.zip amounts 
            |> Seq.map (fun (amount, ing) -> ing |> Array.map ((*) amount))
            |> Seq.reduce (Array.map2 (+)) 
    let score = (max 0 p.[0]) * (max 0 p.[1]) * (max 0 p.[2]) * (max 0 p.[3])
    (score, p.[4])

let scores = 
    distribute [] 100 ingredients.Length
    |> Seq.map scoreCookie
    |> Seq.toArray
    
scores 
    |> Seq.map fst
    |> Seq.max
    |> printfn "a: %d" //18965440

scores 
    |> Seq.maxBy (fun (s,c) -> match c with | 500 -> s | _ -> 0)
    |> fst
    |> printfn "b: %d" // 15862900

// improvements:
let distribute4 m = 
    seq { for a in 0 .. m do 
          for b in 0 .. (m-a) do 
          for c in 0 .. (m-a-b) do 
          yield [|a;b;c;m-a-b-c|] }