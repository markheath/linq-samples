<Query Kind="Expression">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

new[] { 0, 1, 3, 0, 0, 2, 1, 5, 4, 0, 0, 0, 3 }
	.GroupAdjacent(n => n > 0)
	.Where(g => g.Key)
	.Max(g => g.Count())