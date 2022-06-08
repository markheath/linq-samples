<Query Kind="Statements" />

var numbers = Enumerable.Range(1,10);
var squared = numbers.Select(n => n * n);
var halved = squared.Select(n => n / 2);
var minusFive = halved.Select(n => n - 5);
foreach (var n in minusFive)
{
	Console.WriteLine(n);
}

var numbers2 =Enumerable.Range(1, 10)
				.Select(n => n * n)
				.Select(n => n / 20)
				.Select(n => n - 5);
foreach (var n in numbers2)
{
	Console.WriteLine(n);
}