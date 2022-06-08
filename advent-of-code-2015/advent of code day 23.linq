<Query Kind="Statements" />

Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));
var registers = new Dictionary<string,int>() { ["a"] =0, ["b"] = 0 };
var instructions = File.ReadAllLines("day23.txt")
					.Select(i => i.Split(' ')).ToArray();
int index = 0;
while (index < instructions.Length)
{
	var instruction = instructions[index];
	var command = instruction[0];
	if (command == "inc")
	{
		registers[instruction[1]]++;
		index++;
	}
	else if (command == "tpl")
	{
		registers[instruction[1]] *= 3;
		index++;
	}
	else if (command == "jio")
	{
	    //jio r, offset is like jmp, but only jumps if register r is 1 ("jump if one", not odd).
		var register = instruction[1].Trim(',');
		var amount = Int32.Parse(instruction[2]);
		if (registers[register] == 1)
		{
			index+= amount;
		}
		else
		{
			index++;
		}
	}
	else if (command == "jie")
	{
		var register = instruction[1].Trim(',');
		var amount = Int32.Parse(instruction[2]);
		if (registers[register] % 2 == 0)
		{
			index += amount;
		}
		else
		{
			index++;
		}
	}
	else if (command == "jmp")
	{
		//jmp offset is a jump; it continues with the instruction offset away relative to itself
		var amount = Int32.Parse(instruction[1]);
		index += amount;
	}
	else if (command == "hlf")
	{
		registers[instruction[1]] /= 2;
		index++;
	}
	else
	{
		throw new NotImplementedException(command);
	}
}
registers.Dump();
// part 1: 184
// part 2: 231