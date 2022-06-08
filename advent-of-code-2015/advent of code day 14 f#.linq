<Query Kind="FSharpProgram" />

Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath))

let dist (speed,dur,rest) t = if t % (dur + rest) < dur then speed else 0

//let progress n x = [for t in 0..n-1 -> dist x t] |> Seq.scan (+) 0 |> Seq.skip 1 |> Seq.toArray
let progress n x = [0..n-1] |> Seq.map (dist x) |> Seq.scan (+) 0 |> Seq.skip 1 |> Seq.toArray

let lookup = "day14.txt" |> File.ReadAllLines |> Array.map (fun s -> s.Split(' '))
                |> Array.map (fun a -> (int a.[3], int a.[6], int a.[13]))
                |> Array.map (progress 2503) 
    
let smax f = Seq.map f >> Seq.max
lookup |> smax (fun v -> v.[v.Length - 1]) |> printfn "a: %d" // 2640

let getPoints = Seq.mapi (fun t n -> if n = (lookup |> smax (fun f->f.[t])) then 1 else 0) >> Seq.sum
lookup |> smax getPoints |> printfn "b: %d" // 1102