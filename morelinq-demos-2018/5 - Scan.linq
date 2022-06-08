<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

// [x] Scan, ScanRight, PreScan


(new int[] { 1,2,3,4,5 })
	.Scan(0, (acc, next) => acc + next)
	.Dump("Running Totals");

// https://markheath.net/post/running-totals-linq-scan
">>^^<v<v"
	.Scan((x:0, y:0), (acc, dir) =>
		 (dir == '>') ? (acc.x + 1, acc.y) :
		 (dir == '^') ? (acc.x, acc.y + 1) :
		 (dir == '<') ? (acc.x - 1, acc.y) :
						(acc.x, acc.y - 1))
	.Select(p => $"({p.x},{p.y})")
	.ToDelimitedString(",")
	.Dump("Positions");


(new int[] {1,2,3,4 })
	.ScanRight(0, (acc, next) => acc + next)
	.Dump("Running Totals From the Right");

// returns a 4 element sequence
(new int[] { 1,2,3,4 })
	.PreScan((acc, next) => acc + next, 0)
	.Dump("PreScan");