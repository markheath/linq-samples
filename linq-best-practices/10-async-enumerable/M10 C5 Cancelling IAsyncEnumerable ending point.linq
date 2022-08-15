<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Runtime.CompilerServices</Namespace>
</Query>

var cts = new CancellationTokenSource();
cts.CancelAfter(TimeSpan.FromSeconds(3));
await foreach (var message in GetMessages(10).WithCancellation(cts.Token))
{
	Console.WriteLine(message);
}

async IAsyncEnumerable<string> GetMessages(int count, [EnumeratorCancellation] CancellationToken ct = default)
{
	for (var n = 0; n < count; n++)
	{
		var message = await GetMessageAsync(n, ct);
		yield return message;
	}
}

async Task<string> GetMessageAsync(int n, CancellationToken ct = default)
{
	await Task.Delay(500, ct); // simulate a network call
	return $"Hello world {n + 1}";
}