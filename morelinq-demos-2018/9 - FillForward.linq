<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

// [x] FillBackward, FillForward
var data = new[] { "Mark", null, null, "Dave", null, "Claire", "Steph" };
data.FillForward().Dump("Forward");
data.FillBackward().Dump("Backward");

var data2 = new[] { "Mark", "x", "x", "Dave", "x", "Claire", "Steph" };
data2.FillForward(d => d == "x").Dump("Forward");