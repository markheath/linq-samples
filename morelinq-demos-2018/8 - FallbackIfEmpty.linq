<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

// [x] FallbackIfEmpty
var data = new string[] { "Lily", "Annie", "Claire" };
data.Where(d => d.Length > 4).FallbackIfEmpty("Stephanie").Dump("Fallback");
data.Where(d => d.Length > 6).FallbackIfEmpty("Stephanie").Dump("Fallback 2");
data.Where(d => d.Length > 6).FallbackIfEmpty("Stephanie", "Hannah", "Caroline").Dump("Fallback 3");
data.Where(d => d.Length > 6).FallbackIfEmpty(new[] { "Stephanie", "Hannah" }).Dump("Fallback 4");

data.Where(d => d.Length > 6).FirstOrDefault().Dump();