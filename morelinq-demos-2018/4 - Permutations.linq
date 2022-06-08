<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

// [x] Cartesian, Permutations, Subsets (power set)
var data = new [] { "A", "B", "C", "D" };

data.Permutations().Dump("Permutations");
data.Permutations().Select(p => p.ToDelimitedString("")).Dump("Permutations readable");

// subsets are "power sets"
data.Subsets().Dump("All subsets");
data.Subsets(2).Dump("Subsets of size 2");

var data2 = new [] { "E", "F", "G" };
data.Cartesian(data2, (a,b) => a + b).Dump("Cartesian");
// options with extra sequences are available