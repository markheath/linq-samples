using System.Text.Json;

public static class ExtensionMethods
{
    // very simplistic recreation of LINQPad Dump
    // missing many features
    public static void Dump(this object data, string? name = null)
    {
        if (!string.IsNullOrEmpty(name))
        {
            Console.WriteLine(name);
        }
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions(){ WriteIndented = true } );
        Console.WriteLine(json);
    }
}