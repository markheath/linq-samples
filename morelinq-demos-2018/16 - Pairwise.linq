<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>static MoreLinq.Extensions.PairwiseExtension</Namespace>
</Query>

// [x] Pairwise
var data = new [] { "A", "B", "C", "D", "E", "F", "G" };

data.Pairwise((x, y) => $"{x},{y}").Dump("Pairwise");

// LunchTime LINQ Challenge Swim Times https://markheath.net/post/lunchtime-linq-challenge
"00:45,01:32,02:18,03:01,03:44,04:31,05:19,06:01,06:47,07:35"
.Split(',')
.Select(x => TimeSpan.Parse("00:"+x))
.Prepend(TimeSpan.Zero)
.Pairwise ((x, y) => y - x)

// To resolve ambiguity
// using static MoreLinq.Extensions.PairwiseExtension
// Append and Prepend are ambiguous in .NET 4.7.1 (https://msdn.microsoft.com/en-us/library/mt823360(v=vs.110).aspx)
