<Query Kind="Program" />

void Main()
{
	var numbers = GetNumbers().ToList();
	numbers.Sum().Dump("Sum");
	numbers.Sum().Dump("Sum");
	numbers.Sum().Dump("Sum");
	numbers.Sum().Dump("Sum");

}

IEnumerable<int> GetNumbers()
{
	var count = rand.Next(5, 10);
	return Enumerable.Range(0, count).Select(n => rand.Next(0, 10));
}
Random rand = new Random();