<Query Kind="Expression" />

Enumerable.Range(5, 10)
	.Dump("Step 1")
	.Select(n => n * n)
	.Dump("Step 2")
	.Select(n => n / 2)

