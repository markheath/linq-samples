<Query Kind="Statements" />

Func<List<string>> makeList = () => Enumerable.Range(1, 10000000).Select(n => $"Item {0}").ToList();
var itemsToRemove = new[] { "Item 0", "Item 1", "Item 50", "Item 1000", "Item 999999", "Item 9999999" };
var stopwatch = new Stopwatch();

var list = makeList();
stopwatch.Start();
foreach (var item in itemsToRemove)
{
	list.Remove(item);
}
stopwatch.Stop();
Console.WriteLine("Foreach took {0}ms", stopwatch.ElapsedMilliseconds);
list = makeList();
stopwatch.Restart();
var newList = list.Except(itemsToRemove).ToList();
stopwatch.Stop();
Console.WriteLine("Except took {0}ms", stopwatch.ElapsedMilliseconds);
