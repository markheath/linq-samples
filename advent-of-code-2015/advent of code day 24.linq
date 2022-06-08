<Query Kind="Program" />

void Main()
{
	//var presents = new int[] { 1,2,3,4,5,7,8,9,10,11 };
	var presents = new long[] { 1, 2, 3, 5, 7, 13, 17, 19, 23, 29, 31, 37, 41, 43, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113 };
	FindBestQE(presents, 3).Dump("a"); // 10723906903
	FindBestQE(presents, 4).Dump("b"); // 74850409	
}

long FindBestQE(long[] presents, int groups)
{
	var totalWeight = presents.Sum();
	var weightPerSet = totalWeight / groups;
	bestSoFar = 1 + presents.Length / groups;
	var bestSet = Distribute(new List<long>(), presents.ToList(), (int)weightPerSet)
		.Select(g => new { g.Count, QE = g.Aggregate((a, b) => a * b) })
		.OrderBy(g => g.Count)
		.ThenBy(g => g.QE)
		.First();
	bestSet.Dump();
	return bestSet.QE;
}

int bestSoFar = Int32.MaxValue;
IEnumerable<List<long>> Distribute(List<long> used, List<long> pool, int amount)
{
	if (used.Count >= bestSoFar) yield break;
	
    var remaining = amount - used.Sum();
    for (int n = 0; n < pool.Count; n++)
    {
        var s = pool[n];
        if (pool[n] > remaining) continue;		
        var x = used.ToList();
        x.Add(s);
        if (s == remaining)
        {
			if (x.Count < bestSoFar)
				bestSoFar = x.Count;
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

// notes: should also check if unused presents can be divided up
