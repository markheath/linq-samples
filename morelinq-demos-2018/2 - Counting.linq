<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

// [x] AtLeast, AtMost, Exactly, CountBetween, AssertCount
var players = new [] { "Aubameyang", "Ozil", "Ramsey", "Xhaka", "Koscielny" };

players.AtLeast(3).Dump("At least 3");
players.AtMost(3).Dump("At most 3");
players.Exactly(5).Dump("Exactly 5");
players.CountBetween(10,20).Dump("Between 10 and 20");

players.AssertCount(5).Dump("Assert 5"); // returns the sequence
players.AssertCount(6).Dump("Assert 6"); // throws an exception