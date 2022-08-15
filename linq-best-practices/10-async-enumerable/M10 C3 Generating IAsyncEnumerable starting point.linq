<Query Kind="Statements" />

GetMessages(10).Dump();

IEnumerable<string> GetMessages(int count)
{
	for (var n = 0; n < count; n++)
	{
		var message = GetMessage(n);
		yield return message;
	}
}

string GetMessage(int n)
{
	return $"Hello world {n+1}";
}