<Query Kind="FSharpProgram" />

let q,b,bq,bb = "\"","\\","\\\"","\\\\"

let unescape (s:string)  = 
    Regex.Replace(s.Substring(1, s.Length - 2)
                     .Replace(bq, q)
                     .Replace(bb, "?"),
                     @"\\x[0-9a-f]{2}", "?")
                     
let escape (s:string) = q + s.Replace(b, bb).Replace(q, bq) + q                    

let input = Path.GetDirectoryName(Util.CurrentQueryPath) + "\\day8.txt" |> File.ReadAllLines

let sumDiffLengths strings (f:string->string*string) =
    strings
    |> Seq.map f
    |> Seq.sumBy (fun (a,b) -> a.Length - b.Length)

sumDiffLengths input (fun s -> (s, unescape s))
    |> printfn "a: %d" // 1333
    
sumDiffLengths input (fun s -> (escape s, s))
    |> printfn "b: %d" // 2046
