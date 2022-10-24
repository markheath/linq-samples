using static MoreLinq.Extensions.PairwiseExtension;
public static class Module6Demos
{
    // clip 2
    public static void SumTimespans()
    {
        "2:54,3:48,4:51,3:32,6:15,4:08,5:17,3:13,4:16,3:55,4:53,5:35,4:24"
            .Split(',')
            .Select(t => "0:" + t)
            .Select(t => TimeSpan.Parse(t))
            //.Aggregate((t1,t2) => t1 + t2)
            .Sum()
            .Dump("total duration");
    }

	public static TimeSpan Sum(this IEnumerable<TimeSpan> times)
	{
		var total = TimeSpan.Zero;
		foreach (var time in times)
		{
			total += time;
		}
		return total;
    }

    // clip 3
    public static void StringConcat()
    {
        "6,1-3,2-4"
            .Split(',')
            .Select(x => x.Split('-'))
            .Select(p => new { First = int.Parse(p[0]), Last = int.Parse(p.Last()) })
            .SelectMany(r => Enumerable.Range(r.First, r.Last - r.First + 1))
            .Distinct()
            .OrderBy (n => n)
            .Select(n => n.ToString())
            .StringConcatV1(",")
            .Dump();
    }

    // non-generic version
    public static string StringConcatV1(this IEnumerable<string> strings, string separator)
	{
		return string.Join(separator,strings);
	}

    public static void StringConcatGeneric()
    {
        	"6,1-3,2-4"
		.Split(',')
		.Select(x => x.Split('-'))
		.Select(p => new { First = int.Parse(p[0]), Last = int.Parse(p.Last()) })
		.SelectMany(r => Enumerable.Range(r.First, r.Last - r.First + 1))
		.Distinct()
		.OrderBy (n => n)
		.StringConcat(",")
		
		.Dump();
    }

    public static string StringConcat<T>(this IEnumerable<T> strings, string separator)
	{
		return string.Join(separator,strings);
	}

    // clip 4 counting pets
    public static void CountingPetsStage1()
    {
        "Dog,Cat,Rabbit,Dog,Dog,Lizard,Cat,Cat,Dog,Rabbit,Guinea Pig,Dog"
            .Split(',')
            .GroupBy(x => (x != "Dog" && x != "Cat") ? "Other" : x)
            .Select(g => new { Pet = g.Key, Count = g.Count() })
            .Dump();
    }

    
    public static void CountingPetsStageSwitchExpression()
    {
        "Dog,Cat,Rabbit,Dog,Dog,Lizard,Cat,Cat,Dog,Rabbit,Guinea Pig,Dog"
            .Split(',')
            .GroupBy(x => x switch { "Dog" or "Cat" => x, _ => "other" })
            .Select(g => new { Pet = g.Key, Count = g.Count() })
            .Dump();
    }

    public static void CountingPetsCountByExtension()
    {
        "Dog,Cat,Rabbit,Dog,Dog,Lizard,Cat,Cat,Dog,Rabbit,Guinea Pig,Dog"
            .Split(',')
            .CountBy(x => x switch { "Dog" or "Cat" => x, _ => "other" })
            .Dump();
    }

    static IEnumerable<KeyValuePair<TKey, int>> CountBy<TSource, TKey>(
        this IEnumerable<TSource> source, Func<TSource, TKey> selector)
	{
		var counts = new Dictionary<TKey, int>();
		foreach (var item in source)
		{
			var key = selector(item);
			if (!counts.ContainsKey(key))
			{
				counts[key] = 1;
			}
			else
			{
				counts[key]++;
			}
		}
		return counts;
	}

    // clip 6
    public static void SwimLengthTimesZip()
    {
        var splitTimes = "00:45,01:32,02:18,03:01,03:44,04:31,05:19,06:01,06:47,07:35";
        // Length 1: Start = 0:00 End = 0:45
        // Length 2: Start = 0:45 End = 1:32
        // ...
        // Length 10: Start = 6:47 End = 7:35

        ("00:00," + splitTimes)
            .Split(',')
            .Zip(splitTimes.Split(','),
                (s,f) => new 
                { 
                    Start = TimeSpan.Parse("00:" + s),
                    Finish = TimeSpan.Parse("00:" + f),
                })
        	.Select(q => q.Finish - q.Start)
            .Dump();
    }

    public static void SwimLengthTimesMoreLinqPairwise()
    {
        "00:45,01:32,02:18,03:01,03:44,04:31,05:19,06:01,06:47,07:35"
            .Split(',')
            .Select(x => TimeSpan.Parse("00:" + x))
            .Prepend(TimeSpan.Zero) // from regular .NET - note clashes with a MoreLINQ prepend method
            .Pairwise((a, b) => b - a) // from MoreLinq due to the using static MoreLinq.Extensions.PairwiseExtension statement
            .Dump();
    }

    // clip 7
    public static void ChunkFileExample()
    {
        // note - you will need to copy questions.txt into output folder for this to work
        File.ReadAllLines("questions.txt")
            .Chunk(7)
            .Select(b => new { 
                Key = b[0], 
                Question = b[1], 
                CorrectAnswer = b[2], 
                WrongAnswer1 = b[3], 
                WrongAnswer2 = b[4], 
                WrongAnswer3 = b[5] 
            })
            .Dump();
    }


    // clip 8
    public static void ConsecutiveSalesSolutionAggregate()
    {
        new[] { 0, 1, 3, 0, 0, 2, 1, 5, 4, 0, 0, 0, 3 }
            .Aggregate(new { Current = 0, Max = 0 }, (acc, next) =>
            {
                var c = (next > 0) ? acc.Current + 1 : 0;
                return new { Current = c, Max = Math.Max(acc.Max, c) };
            })
            .Dump();
    }  
}