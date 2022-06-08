<Query Kind="Program" />

Dictionary<string, string[]> instructions = new Dictionary<string, string[]>();
void Main()
{

    var testInstructions = @"123 -> x
456 -> y
x AND y -> d
x OR y -> e
x LSHIFT 2 -> f
y RSHIFT 2 -> g
NOT x -> h
NOT y -> i"
    .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
    var path = Path.GetDirectoryName(Util.CurrentQueryPath);
    var realInstructions = File.ReadAllLines(Path.Combine(path, "day7.txt"));

    instructions = realInstructions
    	.Select(i => i.Split(' '))
        .ToDictionary(i => i.Last());
    EvalInput("a").Dump(); // 3176

	instructions = realInstructions
        .Select(i => i.Split(' '))
        .ToDictionary(i => i.Last());
    instructions["b"] = new string[] { "3176", "->", "b" }; 
    EvalInput("a").Dump(); // 14710
}


ushort EvalInput(string input)
{
    Func<string, ushort> eval = x =>
        Char.IsLetter(x[0]) ? EvalInput(x) : ushort.Parse(x);
    Func<string[], ushort> assign = x => eval(x[0]);
    Func<string[], ushort> and = x => (ushort)(eval(x[0]) & eval(x[2]));
    Func<string[], ushort> or = x => (ushort)(eval(x[0]) | eval(x[2]));
    Func<string[], ushort> lshift = x => (ushort)(eval(x[0]) << eval(x[2]));
    Func<string[], ushort> rshift = x => (ushort)(eval(x[0]) >> eval(x[2]));
    Func<string[], ushort> not = x => (ushort)(~eval(x[1]));

    var ins = instructions[input];
    //$"{input}:{String.Join(" ",ins)}".Dump();
    ushort value; 
    if (ins[1] == "->") value = assign(ins);
    else if (ins[1] == "AND") value = and(ins);
    else if (ins[1] == "OR") value = or(ins);
    else if (ins[1] == "LSHIFT") value = lshift(ins);
    else if (ins[1] == "RSHIFT") value = rshift(ins);
    else if (ins[0] == "NOT") value = not(ins);
    else throw new InvalidDataException("Unrecognised command");
    instructions[input] = new string[] { value.ToString(), "->", input };
    return value;
    
}