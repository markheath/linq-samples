<Query Kind="Statements">
  <NuGetReference>System.Linq.Async</NuGetReference>
  <Namespace>System.Runtime.CompilerServices</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var messages = GetMessages(10)
				.Where(m => m.EndsWith("3"))
				.Select(m => m.ToUpper());
await foreach (var message in messages)
{
	Console.WriteLine(message);
}

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