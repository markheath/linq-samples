<Query Kind="Program" />

void Main()
{
	var realInput = new[] { 
		"Frosting: capacity 4, durability -2, flavor 0, texture 0, calories 5",
		"Candy: capacity 0, durability 5, flavor -1, texture 0, calories 8",
		"Butterscotch: capacity -1, durability 0, flavor 5, texture 0, calories 6",
		"Sugar: capacity 0, durability 0, flavor -2, texture 2, calories 1"
	};
	var ingredients = realInput
		.Select(i => i.Replace(",", "").Replace(":", "").Split(' '))
	.Select(p =>
	new Ingredient
		{
			Capacity = int.Parse(p[2]),
		Durability = int.Parse(p[4]),
		Flavor = int.Parse(p[6]),
		Texture = int.Parse(p[8]),
		Calories = int.Parse(p[10])
	}
	)
	.ToArray();

	//ScoreCookie(new[] { 44, 56 }).Dump();
	//Distribute(new[] { 0, 0, 0, 0 }, 5, 0).Dump();

	var scores = Distribute4(100)   // Distribute(new int[ingredients.Length], 100, 0)
					.Select(r => ScoreCookie(ingredients, r))
					.ToArray();

	scores.Max(r => r.Item1).Dump("a"); //18965440

	scores.Where(r => r.Item2 == 500).Max(r => r.Item1).Dump("b"); //18965440
			 
}

// ways to add to 5
// 0,0,0,5
// 0,0,1,4
// 0,0,2,3
// 0,0,3,2
// 0,0,4,1
// 0,0,5,0
// 0,1,0,4
// 

Tuple<int,int> ScoreCookie(Ingredient[] ingredients, int[] amounts)
{
	var p = ingredients
				.Zip(amounts, (ing, amount) => ing * amount)
				.Aggregate((a, b) => a + b);
	return Tuple.Create(p.Score, p.Calories);
}

class Ingredient
{
	public int Capacity { get; set; }
	public int Durability { get; set; }
	public int Flavor { get; set; }
	public int Texture { get; set; }
	public int Calories { get; set; }
	public static Ingredient operator +(Ingredient x, Ingredient y)
	{
		return new Ingredient { 
			Capacity = x.Capacity + y.Capacity,
			Durability = x.Durability + y.Durability,
			Flavor = x.Flavor + y.Flavor,
			Texture = x.Texture + y.Texture,
			Calories = x.Calories + y.Calories
		};
	}
	public static Ingredient operator *(Ingredient x, int n)
	{
		return new Ingredient { 
			Capacity = x.Capacity * n,
			Durability = x.Durability * n,
			Flavor = x.Flavor * n,
			Texture = x.Texture * n,
			Calories = x.Calories * n
		};
	}
	public int Score
	{
		get { return Math.Max(0, Capacity) * Math.Max(0, Texture) * Math.Max(0, Flavor) * Math.Max(0, Durability); }
	}
}


IEnumerable<int[]> Distribute(int[] start, int target, int len)
{
	var remaining = target - start.Sum();
	if (len == start.Length - 1)
	{
		var x = start.ToArray();
		x[len] = remaining;
		yield return x;
	}
	else
	{
		for (int n = 0; n < remaining; n++)
		{
			var x = start.ToArray();
			x[len] = n;
			foreach (var d in Distribute(x, target, len + 1))
			{
				yield return d;
			}
		}
	}
}

IEnumerable<int[]> Distribute4(int max)
{
	for (int a = 0; a <= max; a++)
	for (int b = 0; b <= max - a; b++)
	for (int c = 0; c <= max - a - b; c++)
	yield return new[] { a, b, c, max - a - b - c};
}