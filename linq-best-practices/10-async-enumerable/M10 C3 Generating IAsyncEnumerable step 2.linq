<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

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
	return $"Hello world {n + 1}";
}

async Task<string> GetMessageAsync(int n)
{
	await Task.Delay(500); // simulate a network call
	return $"Hello world {n+1}";
}