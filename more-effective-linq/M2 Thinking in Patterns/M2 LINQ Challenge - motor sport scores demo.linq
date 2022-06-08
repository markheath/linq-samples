<Query Kind="Expression" />

"10,5,0,8,10,1,4,0,10,1"
	.Split(',')
	.Select(int.Parse)
	.OrderBy(n => n)
	.Skip(3)
	.Sum()


