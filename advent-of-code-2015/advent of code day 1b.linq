<Query Kind="Expression">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

File.ReadAllText(
	Path.GetDirectoryName(Util.CurrentQueryPath) +
	"\\day1.txt")
	.Scan(0, (f, d) => d == '(' ? f + 1 : f - 1)
	.Select((floor, index) => new { floor, index })
    .First(f => f.floor == -1)
    .index