<Query Kind="FSharpExpression">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

File.ReadAllText(
    Path.GetDirectoryName(Util.CurrentQueryPath) +
    "\\day3.txt")
    |> Seq.map (fun c -> match c with | '>' -> (1,0) | '^' -> (0,1) | '<' -> (-1,0) | _ -> (0,-1))
    |> Seq.scan (fun (x1,y1) (x2,y2) -> (x1 + x2, y1 + y2)) (0,0)
    |> Seq.distinct //Seq.countBy id
    |> Seq.length