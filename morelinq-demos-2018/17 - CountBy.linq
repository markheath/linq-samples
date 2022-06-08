<Query Kind="Expression">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

// CountBy
// LINQ Challenge 2 Problem 5 (counting pets) https://markheath.net/post/linq-challenge-2-solution-csharp
"Dog,Cat,Rabbit,Dog,Dog,Lizard,Cat,Cat,Dog,Rabbit,Guinea Pig,Dog"
	.Split(',')
	.CountBy(x => x)


"Dog,Cat,Rabbit,Dog,Dog,Lizard,Cat,Cat,Dog,Rabbit,Guinea Pig,Dog"
	.Split(',')
	.GroupBy(x => x)
	.Select(g => new { Pet = g.Key, Count = g.Count() })

"Dog,Cat,Rabbit,Dog,Dog,Lizard,Cat,Cat,Dog,Rabbit,Guinea Pig,Dog"
	.Split(',')
	.CountBy(x => (x != "Dog" && x != "Cat") ? "Other" : x)


"Dog,Cat,Rabbit,Dog,Dog,Lizard,Cat,Cat,Dog,Rabbit,Guinea Pig,Dog"
	.Split(',')
	.CountBy(x => x.Length)
