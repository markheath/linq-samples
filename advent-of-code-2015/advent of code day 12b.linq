<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
</Query>

void Main()
{
	var json = File.ReadAllText(Path.GetDirectoryName(Util.CurrentQueryPath) +"\\day12.txt");
	var o = JObject.Parse(json);
	SumTokens(o).Dump(); // 65402
}

long SumTokens(JToken token)
{
	if (token is JObject)
	{
		var jo = (JObject)token;
		if (jo.IsRed()) return 0;
		return jo.GetValues().Sum(jt => SumTokens(jt));
	}
	else if (token is JArray)
	{
		var ja = (JArray)token;
		return ja.Sum(jt => SumTokens(jt));
    }
	else if (token is JValue)
	{
		return ((JValue)token).AsLong();
	}
	else if (token is JProperty)
	{
		return SumTokens(((JProperty)token).Value);
	}
	token.Dump();
	throw new InvalidOperationException();
}

static class MyExtensions
{
	public static long AsLong(this JValue jvalue)
	{		
		if (jvalue.Value is long) return (long)jvalue.Value;
		else if (jvalue.Value is string) return 0;
		else throw new InvalidOperationException("unexpected token");
	}

	public static IEnumerable<string> GetKeys(this JObject jobject)
	{
		return ((IDictionary<string, JToken>)jobject).Keys;
	}

	public static IEnumerable<JToken> GetValues(this JObject jobject)
	{
		return jobject.GetKeys().Select(k => jobject[k]);
	}


	public static bool IsRed(this JObject jobject)
	{
		return jobject.GetValues()
			.OfType<JValue>()
			.Select(j => j.Value)
			.OfType<string>()
			.Any(j => j == "red");
	}
}