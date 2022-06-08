<Query Kind="FSharpProgram" />

Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath))
let instructions = "day23.txt"
                   |> File.ReadAllLines
                   |> Array.map (fun i -> i.Split(' ') 
                                        |>Array.map (fun p->p.Trim(',')))
                    
let rec run state index = 
    if index >= instructions.Length then state, index else
    let a,b =
        match instructions.[index] with
        | [|"inc";r|] -> state |> Map.add r (state.[r] + 1), 1
        | [|"tpl";r|] -> state |> Map.add r (state.[r] * 3), 1
        | [|"hlf";r|] -> state |> Map.add r (state.[r] / 2), 1
        | [|"jio";r;n|] -> state, if state.[r] = 1 then (int n) else 1
        | [|"jie";r;n|] -> state, if state.[r] % 2 = 0 then (int n) else 1
        | [|"jmp";n|] -> state, (int n)
        | x -> failwith "invalid instruction"
    run a (b+index)

run ([("a",0);("b",0)] |> Map) 0 |> (fun (s,n) -> s.["b"]) |> printfn "a: %d" // 184
run ([("a",1);("b",0)] |> Map) 0 |> (fun (s,n) -> s.["b"]) |> printfn "b: %d" // 231