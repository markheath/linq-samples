<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>static MoreLinq.Extensions.BacksertExtension</Namespace>
  <Namespace>static MoreLinq.Extensions.InsertExtension</Namespace>
</Query>

// Append, Prepend, Concat, Insert, Backsert, 
var players1 = new[] { "Lacazette", "Guendouzi", "Bellerin", };
var players2 = new[] { "Cech", "Koscielny", "Monreal" };

// Append and Prepend are ambiguous in .NET 4.7.1 (https://msdn.microsoft.com/en-us/library/mt823360(v=vs.110).aspx)

players1
	.Append("Ramsey")
	.Prepend("Mkhitaryan")
	.Dump("Append, Prepend"); // LINQ built-in

players1
	.Concat(players2)
	.Dump("Concat"); // LINQ Built-in

// using static MoreLinq.Extensions.InsertExtension
players1
	.Insert(players2, 2)
	.Dump("Insert");


// using static MoreLinq.Extensions.BacksertExtension
players1
	.Backsert(players2, 2)
	.Dump("Backsert");