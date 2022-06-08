<Query Kind="Program" />

IEnumerable<string> Mutate(string sq, IEnumerable<string[]> replacements)
{
	return from pos in Enumerable.Range(0, sq.Length)
	from rep in replacements
	let a = rep[0]
	let b = rep[1]
	where sq.Substring(pos).StartsWith(a)
	select sq.Substring(0,pos) + b + sq.Substring(pos+a.Length);
}

public static IEnumerable<T> Shuffle<T>(IEnumerable<T> source)
{
    Random rnd = new Random();
    return source.OrderBy<T, int>((item) => rnd.Next());
}

// What-a-baller algorithm
// https://www.reddit.com/r/adventofcode/comments/3xflz8/day_19_solutions/cy4cu5b
public int Search (string molecule, IEnumerable<string[]> replacements)
{
    var target = molecule;
    var mutations = 0;
	
    while (target != "e") 
	{
		var tmp = target;		
	    foreach (var rep in replacements) 
		{
			var a = rep[0]; 
			var b = rep[1];
            var index = target.IndexOf(b);
            if (index >= 0)
			{
                target = target.Substring(0, index) + a + target.Substring(index + b.Length);
                mutations++;
			}
		}

		if (tmp == target)
		{
			target = molecule;
            mutations = 0;
            replacements = Shuffle(replacements).ToList();
		}
	}	
	return mutations;
}

void Main()
{
	Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));
	var problemData = File.ReadAllLines("day19.txt");
	var replacements = problemData
						.Select(s => s.Split(' '))
						.Where(a => a.Length == 3)
						.Select(a => new[] { a[0], a[2] })
						.ToList();
	
	
	var medicineMolecule = problemData[problemData.Length - 1];
	
	Mutate(medicineMolecule,replacements)
		.Distinct()
		.Count()
		.Dump("a"); // 509
	
	
	Search(medicineMolecule, replacements)
		.Dump("b"); // 195
}

// Define other methods and classes here
