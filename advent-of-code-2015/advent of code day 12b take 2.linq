<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
</Query>

void Main()
{
	var json = File.ReadAllText(Path.GetDirectoryName(Util.CurrentQueryPath) + "\\day12.txt");
	var o = JObject.Parse(json);
	SumTokens(o).Dump(); // 65402
}

long SumTokens(JToken token)
{
	if (token is JObject)
	{	
		var jo = (JObject)token;
		if (jo.IsRed()) return 0;
		return jo.Properties().Select(p => p.Value).Sum(jt => SumTokens(jt));
	}
	else if (token is JArray)
	{
		var ja = (JArray)token;
		return ja.Sum(jt => SumTokens(jt));
	}
	else if (token is JValue)
	{
		var jv = (JValue)token;
		return (jv.Value is long) ? (long)jv.Value : 0;
	}
	token.Dump();
	throw new InvalidOperationException();
}

static class MyExtensions
{
	public static bool IsRed(this JObject jobject)
	{
		return jobject.Properties()
			.Select(p => p.Value).OfType<JValue>()
			.Select(j => j.Value).OfType<string>()
			.Any(j => j == "red");
	}
}