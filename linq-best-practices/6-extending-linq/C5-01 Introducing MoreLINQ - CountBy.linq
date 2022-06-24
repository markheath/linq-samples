<Query Kind="Program">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

void Main()
{
	"Dog,Cat,Rabbit,Dog,Dog,Lizard,Cat,Cat,Dog,Rabbit,Guinea Pig,Dog"
		.Split(',')
		.CountBy(x => x switch { "Dog" or "Cat" => x, _ => "other" })
		.Dump();
}
