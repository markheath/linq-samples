<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

// [x] Interleave
var jobs = new [] { "Cut grass", "Empty dishwasher", "Fix door", };
var funStuff = new [] { "Eat icecream", "Play guitar", "Watch movie", };
jobs.Interleave(funStuff).Dump("interleaved");

var learning = new [] { "CQRS", "Cosmos DB", "EventGrid", "Kubernetes", "Helm" };
jobs.Interleave(funStuff, learning).Dump("interleaved");