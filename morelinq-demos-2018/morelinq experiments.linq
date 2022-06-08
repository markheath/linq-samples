<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

var players = new [] { "Kane", "Maguire", "Alli", "Pickford", "Young", "Sterling", "Trippier", "Henderson" };
var numbers = new [] { 10, 4, 3, 2 };

players.Assert(p => char.IsUpper(p[0])).Dump("First letter upper case");
players.CountBy(p => p.Length).Dump("Count by length");

players.Lead(3, "X", (a, b) => $"{a}-{b}").Dump("Lead");
players.Lag(3, "X", (a, b) => $"{a}-{b}").Dump("Lag");

players.Partition(p => p.Contains("e")).Dump("Partition");
players.Split(p => p.Contains("g")).Dump("Split");
// TODO:

// 26 Lead and Lag
// 27 Last, LastOrDefault
// 28 Partition, Split
// Rank, RankBy
// SortedMerge, OrderedMerge
// Fold
// Move
// Transpose

// probably not
// Acquire
// AggregateRight
// Choose
// CompareCount
// CountDown
// DistinctBy, ExceptBy
// EndsWith, StartsWith
// Evaluate
// Exclude (should have gone with Skip)
// From
// Index
// OrderBy
// PartialSort, PartialSortBy
// TagFirstLast
// ToDataTable, ToLookup