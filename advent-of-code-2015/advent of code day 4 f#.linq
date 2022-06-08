<Query Kind="FSharpProgram" />

let secretKey = "iwrupvqb" //"pqrstuv"; //"abcdef";
let prefix = "00000"
let md5 = System.Security.Cryptography.MD5.Create()
let q = seq {
    for n in 1 .. 10000000 do
    let inputString = sprintf "%s%d" secretKey n
    let inputBytes = System.Text.Encoding.ASCII.GetBytes(inputString)
    let hashBytes = md5.ComputeHash(inputBytes)
    let hashString = BitConverter.ToString(hashBytes).Replace("-","")
    if hashString.StartsWith(prefix) then yield (n,hashString)
}
q |> Seq.head |> Dump

// notes: can be made more concise relatively easily. The to string isn't strictly necessary