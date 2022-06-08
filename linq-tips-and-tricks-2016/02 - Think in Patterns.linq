<Query Kind="Statements" />

// THINK IN PATTERNS

var people = new string[] { "Ben", "Lily", "Joel", "Sam", "Annie" };

string beginsWithJ = null;
foreach (var person in people)
{
	if (person.StartsWith("J"))
	{
		beginsWithJ = person;
		break;
	}
}

string beginsWithJ = people.FirstOrDefault(p => p.StartsWith("J"));

Console.WriteLine($"{beginsWithJ} begins with J");

int longest = people.Max(p => p.Length);
Console.WriteLine($"The longest name has {longest} letters");

// "declarative vs imperative"