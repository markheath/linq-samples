<Query Kind="Expression">
  <Namespace>System.Net</Namespace>
</Query>

File.ReadAllLines(
	Path.GetDirectoryName(Util.CurrentQueryPath) +
	"\\day2.txt")
.Select(s => s.Split('x'))
.Select(x => x.Select(Int32.Parse))
.Select(w => w.OrderBy(x => x).ToArray())
.Select(w => 2 * w[0] + 2 * w[1] + w[0] * w[1] * w[2])
.Sum()