<Query Kind="Statements" />

Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));
var registers = new Dictionary<string,int>() { ["a"] = 0, ["b"] = 0 };
var instructions = File.ReadAllLines("day23.txt")
					.Select(i => i.Split(' ').Select(s => s.Trim(',')).ToArray())
					.ToArray();
int index = 0;
while (index < instructions.Length)
{
	var ins = instructions[index];
	switch (ins[0])
	{
		case "inc":
			registers[ins[1]]++;
			index++;
			break;
		case "tpl":
			registers[ins[1]] *= 3;
			index++;
			break;
		case "hlf":
			registers[ins[1]] /= 2;
			index++;
			break;
		case "jio":
			index += registers[ins[1]] == 1 ? int.Parse(ins[2]) : 1;
			break;
		case "jie":
			index += registers[ins[1]] % 2 == 0 ? int.Parse(ins[2]) : 1;
			break;
		case "jmp":
			index += int.Parse(ins[1]);
			break;
		default:
			throw new NotImplementedException(ins[0]);
	}
}
registers.Dump();
// part 1: 184
// part 2: 231