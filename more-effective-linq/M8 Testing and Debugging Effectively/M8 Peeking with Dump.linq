<Query Kind="Expression" />

Enumerable.Range(1, 10)
	.Dump("Step 1")
	.Select(n => n * n)
	.Dump("Step 2")
	.Select(n => n / 2)
	.Dump("Step 3")
	.Select(n => n - 5)