<Query Kind="Expression">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

(new[] { "a", "b", "c", "d" }).Pairwise((first,second) => first + "," + second)