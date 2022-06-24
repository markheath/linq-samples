<Query Kind="Program" />

void Main()
{
		Answer3();
}

int ProblemMethod(int input)
{
	throw new InvalidOperationException();
}

void Answer1()
{
	IEnumerable<int> numbers = null;
	try
	{
		numbers = Enumerable.Range(1, 10)
					.Select(n => ProblemMethod(n));
	}
	catch (Exception e)
	{
		Console.WriteLine($"Exception caught: {e.Message}");
	}
	
	foreach(var n in numbers)
	{
		Console.WriteLine(n);
	}
}

void Answer2()
{
	var numbers = Enumerable.Range(1, 10)
					.Select(n => ProblemMethod(n));
	
	foreach (var n in numbers)
	{
		try
		{
			Console.WriteLine(n);
		}
		catch (Exception e)
		{
			Console.WriteLine($"Exception caught: {e.Message}");
		}
	}
}

void Answer3()
{
	var numbers = Enumerable.Range(1, 10)
					.Select(n => ProblemMethod(n));

	try
	{
		foreach (var n in numbers)
		{
			Console.WriteLine(n);
		}
	}
    catch (Exception e)
	{
		Console.WriteLine($"Exception caught: {e.Message}");
	}
}
