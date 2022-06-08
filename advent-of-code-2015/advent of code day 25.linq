<Query Kind="Expression">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System.Numerics</Namespace>
</Query>

Enumerable.Range(1, 10000)
.SelectMany(d => Enumerable.Range(1, d),
	(d,c) => new { row = d - c + 1, col = c })
	.Dump()
.TakeWhile(d => !(d.row == 2978 && d.col == 3083))
.Aggregate(20151125L, (acc, _) => (acc * 252533L) % 33554393L) // 2650453