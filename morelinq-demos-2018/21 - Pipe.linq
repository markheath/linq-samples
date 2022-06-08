<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

// 21 Pipe, Trace, Consume, ForEach
new [] { "Lacazette", "Guendouzi", "Bellerin", "Cech", "Koscielny", "Monreal" }
	.Pipe(p => Console.WriteLine($"Before Filter {p}"))
	.Where(n => n.Length < 5)
	.Pipe(p => Console.WriteLine($"After filter {p}"))
	.Select(p => p.ToUpper())
	.Dump();

new [] { "Lacazette", "Guendouzi", "Bellerin", "Cech", "Koscielny", "Monreal" }
	.Trace()
	.Where(n => n.Length < 5)
	.Trace(p => $"TRACE After filter {p}")
	.Select(p => p.ToUpper())
	.Dump();

new [] { "Lacazette", "Guendouzi", "Bellerin", "Cech", "Koscielny", "Monreal" }
	.Where(n => n.Length < 5)
	.Select(p => p.ToUpper())
	.Pipe(p => Console.WriteLine($"CONSUME {p}"))
	.Consume();

new [] { "Lacazette", "Guendouzi", "Bellerin", "Cech", "Koscielny", "Monreal" }
	.ForEach(p => Console.WriteLine($"FOREACH {p}"));