<Query Kind="FSharpProgram">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

let getVector c = match c with | '>' -> (1,0) | '^' -> (0,1) | '<' -> (-1,0) | _ -> (0,-1)
let addVector (x1,y1) (x2,y2) = (x1 + x2, y1 + y2)
let directions = 
    File.ReadAllText(
        Path.GetDirectoryName(Util.CurrentQueryPath) +
        "\\day3.txt")
let startState = ((0,0),(0,0),0)
let update (santa,roboSanta,index) nextDir =
    if (index % 2) = 0 then
        ((addVector santa nextDir), roboSanta, index+1)
    else
        (santa, (addVector roboSanta nextDir), index+1)
    
directions
    |> Seq.map getVector
    |> Seq.scan update startState
    |> Seq.map (fun (santa,roboSanta,index) -> if index % 2 = 0 then santa else roboSanta)
    |> Seq.distinct //Seq.countBy id
    |> Seq.length
    |> Dump