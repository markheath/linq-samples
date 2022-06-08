<Query Kind="FSharpProgram" />

Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath))
type Instruction = | Increment of string
                   | Triple of string
                   | Half of string
                   | Jump of int
                   | JumpIfEven of string * int
                   | JumpIfOne of string * int
let instructions = "day23.txt"
                   |> File.ReadAllLines
                   |> Seq.map (fun i -> i.Split(' ') 
                                        |>Array.map (fun p->p.Trim(',')))
                   |> Seq.map (function
                        | [|"inc";r|] -> Increment r
                        | [|"tpl";r|] -> Triple r
                        | [|"hlf";r|] -> Half r
                        | [|"jio";r;n|] -> JumpIfOne (r, int n)
                        | [|"jie";r;n|] -> JumpIfEven (r, int n)
                        | [|"jmp";n|] -> Jump (int n)
                        | x -> failwith "invalid instruction")
                    |> Seq.toArray

let rec run index state = 
    if index >= instructions.Length then state,index else
    let a,b = 
        match instructions.[index] with
        | Increment r -> state |> Map.add r (state.[r] + 1), 1
        | Half r -> state |> Map.add r (state.[r] / 2), 1
        | Triple r -> state |> Map.add r (state.[r] * 3), 1
        | JumpIfOne (r,n) -> state, if state.[r] = 1 then n else 1
        | JumpIfEven (r,n) -> state, if state.[r] % 2 = 0 then n else 1
        | Jump n -> state, n
    run (index+b) a 

run 0 ([("a",0);("b",0)] |> Map) |> (fun (s,n) -> s.["b"]) |> printfn "a: %d" 
run 0 ([("a",1);("b",0)] |> Map) |> (fun (s,n) -> s.["b"]) |> printfn "b: %d" 


