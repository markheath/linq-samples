<Query Kind="Expression">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

"00:45,01:32,02:18,03:01,03:44,04:31,05:19,06:01,06:47,07:35"
	.Split(',')
	.Select(x => TimeSpan.Parse("00:" + x))
	.Prepend(TimeSpan.Zero)
	.Pairwise((a, b) => b - a)