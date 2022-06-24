<Query Kind="Program" />

void Main()
{
	var numbers = GetNumbers();
	numbers.Sum().Dump("Sum");
	numbers.Max().Dump("Max");
	numbers.Min().Dump("Min");
	numbers.Count().Dump("Count");	
}

IEnumerable<int> GetNumbers()
{
	return new[] { 3, 6, 2, 7, 2, 9, 5};
}

