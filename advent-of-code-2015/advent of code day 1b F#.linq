<Query Kind="FSharpExpression">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

File.ReadAllText(
    Path.GetDirectoryName(Util.CurrentQueryPath) +
    "\\day1.txt")
    |> Seq.map (fun d -> if d = '(' then 1 else -1)
    |> Seq.scan (+) 0 
    |> Seq.findIndex (fun f -> f = -1)