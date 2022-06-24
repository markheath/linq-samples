<Query Kind="Program" />

void Main()
{
	"Dog,Cat,Rabbit,Dog,Dog,Lizard,Cat,Cat,Dog,Rabbit,Guinea Pig,Dog"
		.Split(',')
		.GroupBy(x => x switch { "Dog" or "Cat" => x, _ => "other" })
		.Select(g => new { Pet = g.Key, Count = g.Count() })
		.Dump();
}

static class MyLinqExtensions
{

}