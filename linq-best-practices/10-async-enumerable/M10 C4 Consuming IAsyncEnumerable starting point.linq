<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

GetMessages(10).Dump();

async IAsyncEnumerable<string> GetMessages(int count)
{
	for (var n = 0; n < count; n++)
	{
		var message = await GetMessageAsync(n);
		yield return message;
	}
}

async Task<string> GetMessageAsync(int n)
{
	await Task.Delay(500); // simulate a network call
	return $"Hello world {n + 1}";
}