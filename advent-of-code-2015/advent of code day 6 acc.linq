<Query Kind="Expression" />

File.ReadAllLines(
	Path.GetDirectoryName(Util.CurrentQueryPath) +
	"\\day6.txt")
	.Select(i => Regex.Match(i,
		@"(turn on|toggle|turn off)\ (\d+)\,(\d+)\ through\ (\d+)\,(\d+)").Groups)
	.Select(g => new
	{
		Action = g[1].Value,
		From = new { X = int.Parse(g[2].Value), Y = int.Parse(g[3].Value) },
		To = new { X = int.Parse(g[4].Value), Y = int.Parse(g[5].Value) }
	})
	.SelectMany(i =>
		from x in Enumerable.Range(i.From.X, 1 + i.To.X - i.From.X)
		from y in Enumerable.Range(i.From.Y, 1 + i.To.Y - i.From.Y)
		select new { i.Action, x, y })
	.Aggregate(new int[1000,1000], (acc, next) => {
		var brightness = acc[next.x,next.y];
		if (next.Action == "turn on") 
			brightness+=1;
		else if (next.Action == "turn off") 
			brightness = Math.Max(0, brightness - 1);
		else if (next.Action == "toggle") 
			brightness += 2;
		acc[next.x, next.y] = brightness;
		return acc;
		})
	.Cast<int>() // flattens a multi-dimensional array
	.Sum()
// brightness is 14687245