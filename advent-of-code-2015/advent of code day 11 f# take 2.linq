<Query Kind="FSharpProgram" />

let inc = "abcdefghjkmnpqrstuvwxyz" |> Seq.pairwise |> dict
let (&) c s = sprintf "%c%s" c s 
let nextc (c,str) ch = match c, ch with | 0, n -> 0, n & str | 1, 'z' -> 1, "a" + str | 1, n -> 0, inc.[n] & str
let succ = Seq.rev >> Seq.fold nextc (1,"") >> snd
let succseq = Seq.unfold (fun f -> Some (f, succ f)) >> Seq.skip 1

let (=~) s p = Regex.IsMatch(s,p)
let run = [|'a'..'z'|] |> Seq.windowed 3 |> Seq.map String |> String.concat "|"
let isValid (p:string) = p =~ @"(\w)\1.*(\w)\2" && p =~ run
let findNext = succseq >> Seq.find isValid

//let isValid (p:string) = p =~ @"(\w)\1.*(\w)\2" && not (p =~ "[iol]") && p =~ run
//let fixup (s:string) = match s.IndexOfAny([|'i';'l';'o'|]) with | -1 -> s | n -> sprintf "%s%c%s" (s.Substring(0, n)) (fix s.[n]) (new string('a',(s.Length - n - 1)))
//let findNext = fixup >> succseq >> Seq.find isValid
    
findNext "abcdefgh" |> (=) "abcdffaa" |> Dump
//findNext "ghijklmn" |> (=) "ghjaabcc" |> Dump
findNext "vzbxkghb" |> (=) "vzbxxyzz" |> Dump
findNext "vzbxxyzz" |> (=) "vzcaabcc" |> Dump