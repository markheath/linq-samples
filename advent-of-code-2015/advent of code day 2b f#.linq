<Query Kind="FSharpExpression">
  <Namespace>System.Net</Namespace>
</Query>

File.ReadAllLines(
    Path.GetDirectoryName(Util.CurrentQueryPath) + 
    "\\day2.txt")
|> Seq.map(fun s->s.Split('x') |> Seq.map int |> Seq.sort |> Seq.toArray)
|> Seq.map(fun w-> 2 * w.[0] + 2 * w.[1] + w.[0] * w.[1] * w.[2])
|> Seq.sum