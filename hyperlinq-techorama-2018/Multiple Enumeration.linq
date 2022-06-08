<Query Kind="Program" />

void Main()
{
	var data = GetNumbers().Take(10);
	data.Dump();
	data.Min().Dump("Min");
	data.Max().Dump("Max");
	data.Sum().Dump("Sum");
		

}

Random r = new Random();
public IEnumerable<int> GetNumbers()
{
	// ?
	while(true)
		yield return r.Next(1000);
	
}

