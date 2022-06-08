<Query Kind="FSharpProgram">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
</Query>

let json = File.ReadAllText(Path.GetDirectoryName(Util.CurrentQueryPath) + "\\day12.txt")
let o = JObject.Parse(json)

let shouldAvoid avoid (jo:JObject) = 
    jo.Properties() |> Seq.exists (fun p -> match p.Value with | :? JValue as jv -> jv.Value = avoid | _ -> false)

let rec getSum avoid (token:JToken) =
    match token with
    | :? JObject as jo -> 
        if shouldAvoid avoid jo then 0L
        else jo.Properties() |> Seq.map (fun p -> p.Value) |> Seq.map (getSum avoid) |> Seq.sum 
    | :? JArray as ja -> ja |> Seq.cast<JToken> |> Seq.map (getSum avoid) |> Seq.sum 
    | :? JValue as jv -> if jv.Type = JTokenType.Integer then jv.Value :?> int64 else 0L
    | _ -> failwith (sprintf "unknown token %A" (token.GetType())  )


getSum null o |> printfn "a: %d" // 111754
getSum "red" o |> printfn "b: %d" // 65402
