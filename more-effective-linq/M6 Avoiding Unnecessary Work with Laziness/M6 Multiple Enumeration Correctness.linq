<Query Kind="Program" />

void Main()
{
	var numbers = GetNumbers2();
	numbers.Sum().Dump("Sum");
	numbers.Sum().Dump("Sum");

	numbers.Max().Dump("Max");
	numbers.Min().Dump("Min");
	numbers.Average(n => (double)n).Dump("Average");

	numbers.Count().Dump("Count");	
}

IEnumerable<int> GetNumbers()
{
	return new[] { 3, 6, 2, 7, 2, 9, 5};
}

IEnumerable<int> GetNumbers2()
{
	var count = rand.Next(0, 10);
	return Enumerable.Range(0, count).Select(n => rand.Next(0, 10));
}
Random rand = new Random();