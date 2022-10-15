<Query Kind="Statements" />

Enumerable.Range(1, 10000000)
					.Select(n => n * 2)
					.Select(n => Math.Sin((2 * Math.PI * n) / 1000))
					.Select(n => Math.Pow(n, 2))
					.Sum()
					.Dump("Sum LINQ");

double sum = 0;
for (int n = 1; n <= 10000000; n++)
{
	var a = n * 2;
	var b = Math.Sin((2 * Math.PI * a) / 1000);
	var c = Math.Pow(b, 2);
	sum += c;
}
sum.Dump("Sum for loop");