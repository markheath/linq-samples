<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

// [x] MaxBy, MinBy

var people = new[] { "Ben", "Lily", "Joel", "Sam", "Annie" };
people.Max(p => p.Length).Dump("LINQ Max");
people.MaxBy(p => p.Length).Dump("MaxBy"); // also supports a custom comparer
people.MinBy(p => p.Length).Dump("MinBy"); // returns more than one