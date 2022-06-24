<Query Kind="Statements" />

Enum.GetNames(typeof(Example))
	.Select(n => new { Name = n, Number = (int)Enum.Parse<Example>(n) })
	.GroupBy(n => n.Number)
	.Where(g => g.Count() > 1)
	.Dump("Duplicates");
	
Enum.GetNames(typeof(Example))
	.Except(Enum.GetNames(typeof(Example2)))
	.Dump("missing");
	

enum Example
{
	Apples = 1,
	Bananas = 2,
	Oranges = 3,
	Pears = 3
}

enum Example2
{
	Apples = 1,
	Bananas = 2,
	Oranges = 3,
}