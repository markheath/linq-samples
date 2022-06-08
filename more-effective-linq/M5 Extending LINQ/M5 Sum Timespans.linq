<Query Kind="Program" />

void Main()
{
	"2:54,3:48,4:51,3:32,6:15,4:08,5:17,3:13,4:16,3:55,4:53,5:35,4:24"
		.Split(',')
		.Select(t => "0:" + t)
		.Select(t => TimeSpan.Parse(t))
		//.Aggregate((t1,t2) => t1 + t2)
		.Sum()
		.Dump("total duration");
}

static class MyLinqExtensions
{
	public static TimeSpan Sum(this IEnumerable<TimeSpan> times)
	{
		var total = TimeSpan.Zero;
		foreach (var time in times)
		{
			total += time;
		}
		return total;
	}
}
