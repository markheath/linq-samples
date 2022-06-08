<Query Kind="FSharpProgram" />

// uint16 suffix is us (https://msdn.microsoft.com/en-us/library/dd233193.aspx)
// bitwise operations: https://msdn.microsoft.com/en-us/library/dd469495.aspx
let path = Path.GetDirectoryName Util.CurrentQueryPath
let realInstructions = Path.Combine(path, "day7.txt") |> File.ReadAllLines

type arg =
    | Constant of uint16
    | Wire of string    

type action =
    | Assign of arg
    | LShift of arg * arg
    | RShift of arg * arg
    | And of arg * arg
    | Or of arg * arg
    | Not of arg
    
type command = action * string

let parseArg (a:string) =
    if Char.IsLetter (a.[0]) then Wire a else Constant (uint16 a)
    
let parseCommand (c:string) =
    let parts = c.Split(' ')
    let toArg n = parseArg parts.[n]
        
    let action = 
        match parts.[1] with
        | "->" -> Assign (toArg 0)
        | "AND" -> And (toArg 0, toArg 2)
        | "OR" -> Or (toArg 0, toArg 2)
        | "LSHIFT" -> LShift (toArg 0, toArg 2)
        | "RSHIFT" -> RShift (toArg 0, toArg 2)
        | _ -> Not (toArg 1)
    (action, parts |> Seq.last)


 
let evalCommand (state:Dictionary<string,uint16>) (action,target) =
    let canEvalArg a = match a with | Constant _ -> true | Wire w -> state.ContainsKey(w)
    let evalArg a = match a with | Constant n -> n | Wire w -> state.[w]

    let canEvalAction = 
        match action with
        | Assign a | Not a -> (canEvalArg a)
        | And (a,b) | Or (a,b) | LShift (a,b) | RShift (a,b) -> (canEvalArg a) && (canEvalArg b)
    
    if canEvalAction then
        let result =
            match action with
            | Assign a -> evalArg a
            | Not a -> ~~~ (evalArg a)
            | And (a,b) -> (evalArg a) &&& (evalArg b)
            | Or (a,b)  -> (evalArg a) ||| (evalArg b)
            | LShift (a,b) -> (evalArg a) <<< int (evalArg b)
            | RShift (a,b) -> (evalArg a) >>> int (evalArg b)
        Some result
    else
        None

let deferAggregate commands =
    let queue = new Queue<command>()
    commands |> Seq.iter (fun c -> queue.Enqueue (c))
    let state = new Dictionary<string,uint16>()
    while queue.Count > 0 do
        let c = queue.Dequeue()
        let r = evalCommand state c
        match r with | Some n -> state.[snd c] <- n | None -> queue.Enqueue(c)
    state
        
let endState = 
    realInstructions 
    |> Seq.map parseCommand
    |> deferAggregate

endState.["a"]    
    |> Dump
    
let endState2 = 
    realInstructions 
    |> Seq.map (fun i -> if i.TrimEnd().EndsWith("-> b") then "3176 -> b" else i)
    |> Seq.map parseCommand
    |> deferAggregate

endState2.["a"]    
    |> Dump
    