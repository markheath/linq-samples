<Query Kind="Program" />

void Main()
{
    var startState = new Dictionary<string, ushort>();
    Func<string, ushort> eval = x => 
    	Char.IsLetter(x[0]) ?  startState[x] : ushort.Parse(x);
    
    Func<string[], ushort> assign = x => eval(x[0]);
    Func<string[], ushort> and = x => (ushort) (eval(x[0]) & eval(x[2]));
    Func<string[], ushort> or = x => (ushort) (eval(x[0]) | eval(x[2]));
    Func<string[], ushort> lshift = x => (ushort) (eval(x[0]) << eval(x[2]));
    Func<string[], ushort> rshift = x => (ushort) (eval(x[0]) >> eval(x[2]));
    Func<string[], ushort> not = x => (ushort) (~eval(x[1]));
    
    Func<string[], Func<string[], ushort>> selector = x =>
    {
    	if (x[1] == "->") return assign;
    	else if (x[1] == "AND") return and;
    	else if (x[1] == "OR") return or;
    	else if (x[1] == "LSHIFT") return lshift;
    	else if (x[1] == "RSHIFT") return rshift;
		else if (x[0] == "NOT") return not;
		x.Dump();
		throw new InvalidDataException($"Unrecognised command {string.Join(" ", x)}");
    };
    var testInstructions = @"123 -> x
    456 -> y
    x AND y -> d
    x OR y -> e
    x LSHIFT 2 -> f
    y RSHIFT 2 -> g
    NOT x -> h
    NOT y -> i"
    		.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
			.Select(s => s.Trim())
    ;
    
    var path = Path.GetDirectoryName(Util.CurrentQueryPath);
    File.ReadAllLines(Path.Combine(path, "day7.txt"))
	//testInstructions
    	.Select(i => i.Split(' '))
    	.Select(i => new { Target = i.Last(), Action = selector(i), Params = i })
    	/*.Aggregate(startState, (acc, next) =>
    	{
    		acc[next.Target] = next.Action(next.Params);
    		return acc;
    	})*/
    	
        .RetryingAggregate(startState, (acc, next) =>
        {
            acc[next.Target] = next.Action(next.Params);
            return acc;
        })
        .OrderBy(d => d.Key)
        .Dump();

}
static class MyExtensions
{
    public static TAcc RetryingAggregate<TAcc, TSource>(this IEnumerable<TSource> source, TAcc seed, Func<TAcc, TSource, TAcc> selector)
    {
        var retries = new Queue<TSource>(source);
        while (retries.Count > 0)
        {
            TSource item = retries.Dequeue();
            bool success = false;
            try
            {
                seed = selector(seed, item);
                success = true;
            }
            catch (KeyNotFoundException)
            {
            }
            if (!success)
                retries.Enqueue(item);
        }
        return seed;
    }
}