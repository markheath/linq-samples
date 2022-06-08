<Query Kind="FSharpExpression" />

File.ReadAllText(
    Path.GetDirectoryName(Util.CurrentQueryPath) +
    "\\day1.txt")
    |> Seq.sumBy (fun c -> if c = '(' then 1 else -1)