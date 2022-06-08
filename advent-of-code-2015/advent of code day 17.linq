<Query Kind="Program" />

void Main()
{
	Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));
	//var sizes = new List<int>() { 20, 15, 10, 5, 5 };
	var sizes = File.ReadAllLines("day17.txt")
		.Select(int.Parse)
		.ToList();
	var combs = Distribute(new List<int>(), sizes, 150).ToList();
	//combs.Dump();
	combs.Count.Dump("a");
	var min = combs.Min(p => p.Count);
	combs.Count(p => p.Count == min).Dump("b");
}

IEnumerable<List<int>> Distribute(List<int> used, List<int> pool, int amount)
{
	var remaining = amount - used.Sum();
	for (int n = 0; n < pool.Count; n++)
	{
		var s = pool[n];
		if (pool[n] > remaining) continue;
		var x = used.ToList();
		x.Add(s);
		if (s == remaining)
		{
			yield return x;
		}
		else
		{
			var y = pool.Skip(n+1).ToList();
			foreach (var d in Distribute(x, y, amount))
			{
				yield return d;
			}
		}
	}
}