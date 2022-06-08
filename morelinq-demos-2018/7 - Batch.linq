<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

// [x] Batch

var data = new [] { "A", "B", "C", "D", "E", "F", "G", "H" };
data.Batch(3).Dump("Batch 3");

data.Batch(3, b => b.ToDelimitedString(",")).Dump("Batch with selector");