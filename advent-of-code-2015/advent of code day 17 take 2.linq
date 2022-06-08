<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

// using powersets
// "powerset" of abc is a, b, c, ab, bc, ac, abc
var containers = new int[] { 11, 30, 47, 31, 32, 36, 3, 1, 5, 3, 32, 36, 15, 11, 46, 26, 28, 1, 19, 3 };
var powerset = Enumerable.Range(1, (1 << containers.Length) - 1)
  .Select(n => containers.Where((_, bit) => ((1 << bit) & n) != 0).ToList());
var solutions = powerset.Where(c => c.Sum() == 150).ToArray();
solutions.Length.Dump("a");
var min = solutions.Min(s => s.Count);
solutions.Count(s => s.Count == min).Dump("b");
// concise but slow