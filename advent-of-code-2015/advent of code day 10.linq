<Query Kind="Expression">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

Enumerable.Range(1, 40)
	.Aggregate("1113122113".Select(c => c - '0').ToArray(), (acc,_) =>
	acc
	.GroupAdjacent(n => n)
	.SelectMany(g => new int[] { g.Count(), g.First() })
	.ToArray())
	.Count() // a = 360154, b = 5103798
