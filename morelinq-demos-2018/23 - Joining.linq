<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

// 23 RightJoin, LeftJoin, FullJoin, FullGroupJoin, Unions
"ABCD".Union("DEFAG").Dump("Union");

"ABCFG".RightJoin("abcde", c => Char.ToUpper(c), c => $"{c}", (a, b) => $"{a}{b}")
"ABCFG".LeftJoin("abcde", c => Char.ToUpper(c), c => $"{c}", (a, b) => $"{a}{b}")
"ABCFG".FullJoin("abcde", c => Char.ToUpper(c), c => $"L:{c}", c => $"R:{c}", (a, b) => $"{a}{b}")
"ABCFG".FullGroupJoin("abcde", c => Char.ToUpper(c), c => Char.ToUpper(c))