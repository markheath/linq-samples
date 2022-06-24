<Query Kind="Program" />

void Main()
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

static class MyLinqExtensions
{
	public static string StringConcat<T>(this IEnumerable<T> strings, string separator)
	{
		return string.Join(separator,strings);
	}
}