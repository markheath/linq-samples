<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>MoreLinq</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
</Query>

// Flatten

var sequences = new[] {
		new [] { "Hello", "World" },
		new [] { "Happy", "Birthday" },
		new [] { "I'll", "Be", "Back" }		
		};
sequences.Flatten().Dump("Flatten"); // not strongly typed // can do arbitrary nesting

sequences.SelectMany(s => s).Dump("LINQ SelectMany"); // one level deep only

var sequences2 = new object[] {
		new [] { "Hello", "World" },
		new [] { "Happy", "Birthday" },
		new object [] { "To", new [] { "be", "or", "not" }, new [] { "to", "be"}, "that", new object[] { "is", new[] { "the", "question" }}}}
		;
sequences2.Flatten().Dump("Flatten 2");