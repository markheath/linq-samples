<Query Kind="FSharpProgram" />

let succ (x:string) =
    let arr = x |> Seq.toArray
    let mutable carry = true
    for n in [(x.Length - 1) .. -1 .. 0] do
        match carry, arr.[n] with
        | false, _ -> ()
        | true, 'z' -> arr.[n] <- 'a'
        | _, c -> 
            arr.[n] <- char (int c + 1)
            carry <- false
    new string (arr)

let succseq = Seq.unfold (fun f -> Some (f, succ f)) >> Seq.skip 1


let next (c,str) ch = match c, ch with | false, n -> false,n+str | true, "z" -> true,"a"+str | true, n -> false, sprintf "%c%s"(char (int n.[0] + 1)) str
"hello" |> Seq.rev |> Seq.map string |> Seq.fold next (true,"") |> snd |> printfn "%s" 

// ch as string
let nextc (c,str) ch = match c, ch with | false, n -> false, sprintf "%c%s" n str | true, 'z' -> true,"a"+str | true, n -> false, sprintf "%c%s"(char (int n + 1)) str
"hello" |> Seq.rev |> Seq.fold nextc (true,"") |> snd |> printfn "%s" 

(*let rec succseq q = seq { 
    let s = succ q
    yield s
    yield! succseq s
}*)

(*
succ "aaaa" |> printfn "%s"
succ "aaab" |> printfn "%s"
succ "aaaz" |> printfn "%s"
succ "bzzz" |> printfn "%s"

succseq "bzzz" |> Seq.take 5 |> Dump // Seq.map (printfn "%s")
succseq2 "bzzy" |> Seq.take 5 |> Dump // Seq.map (printfn "%s")
*)
     


let isValidPassword (p:string) = 
    Regex.IsMatch(p, @"(\w)\1.*(\w)\2") && 
    not(Regex.IsMatch(p, @"[iol]")) && 
    //Regex.IsMatch(p, "abc|bcd|cde|def|efg|fgh|pqr|qrs|rst|stu|tuv|uvw|vwx|wxy|xyz")
    //p |> Seq.map int |> Seq.windowed 3 |> Seq.exists (fun q -> (q.[0] + 1 = q.[1]) && (q.[1] + 1) = q.[2])
    p |> Seq.map int |> Seq.windowed 3 |> Seq.exists (fun [|a;b;c|] -> (a + 1 = b) && (b + 1 = c))

let findNextPassword start = 
    succseq start 
    |> Seq.find isValidPassword
    
findNextPassword "abcdefgh" |> Dump
findNextPassword "ghijklmn" |> Dump
findNextPassword "vzbxkghb" |> Dump
findNextPassword "vzbxxyzz" |> Dump