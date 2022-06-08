<Query Kind="Expression">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

//ToDelimitedString (plus ToDictionary, ToHashSet, ToArrayByIndex)

// LINQ has ToList, ToArray

new[] { 4,5,6,7 }.ToDelimitedString(",")
new[] { "A", "B", "C" }.ToDelimitedString("")

new[] { 4,5,6,7}.ToArrayByIndex(x => x)
new[] { "Mark", "Steph", "Ben", "Lily", "Annie" }.ToArrayByIndex(x => x.Length)

new[] { new { Id = 1, Name = "Mark" }, new { Id = 2, Name = "Steph" }, new { Id = 3, Name = "Ben" } }.ToDictionary(me => me.Id)

// ToHashSet clashes with built-in LINQ method new to .NET 4.7.2
// https://docs.microsoft.com/en-gb/dotnet/api/system.linq.enumerable.tohashset?view=netframework-4.7.2
//new[] { "Mark", "Steph", "Ben", "Lily", "Joel", "Mark" }.ToHashSet()