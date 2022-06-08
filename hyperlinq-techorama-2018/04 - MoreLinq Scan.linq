<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

(new int[] { 2,3,5,1,5,6,8,4 })
	.Scan(0, (acc, next) => acc + next)
	.Dump("Running Totals");

// https://markheath.net/post/running-totals-linq-scan
">>^^>>^<v^^<v>>"
	.Scan((x:0, y:0), (acc, dir) =>
		 (dir == '>') ? (acc.x + 1, acc.y) :
		 (dir == '^') ? (acc.x, acc.y + 1) :
		 (dir == '<') ? (acc.x - 1, acc.y) :
						(acc.x, acc.y - 1))
	.Select(p => $"({p.x},{p.y})")
	.Dump("Positions");
