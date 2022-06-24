<Query Kind="Statements" />

var listSize = 10000000;
var stopwatch = new Stopwatch();
stopwatch.Restart();
var s = Enumerable.Range(1, listSize)
	.Select(n => n * 2)
	.Select(n => Math.Sin((2 * Math.PI * n)/1000))
	.Select(n => Math.Pow(n,2))
	.Sum();
stopwatch.Stop();
Console.WriteLine($"LINQ {listSize} items in {stopwatch.ElapsedMilliseconds}ms");

stopwatch.Restart();
double sum = 0;
for (int n = 1; n <= listSize; n++)
{
	var a = n * 2;
	var b = Math.Sin((2 * Math.PI * a)/1000);
	var c = Math.Pow(b,2);
	sum += c;
}
stopwatch.Stop();
Console.WriteLine($"For loop {listSize} items in {stopwatch.ElapsedMilliseconds}ms");