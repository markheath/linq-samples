<Query Kind="Statements" />

var testStart = @".#.#.#
...##.
#....#
..#...
#.#..#
####..".Split('\n');
Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));
var start = File.ReadAllLines("day18.txt");
var repetitions = 100;

var state = start.Select(s => s.Trim().Select(c => c == '#' ? 1 : 0).ToArray()).ToArray();
Func<int, int, int> getLight = (x, y) =>
{
	if (x < 0 || x >= state.Length) return 0;
	if (y < 0 || y >= state[x].Length) return 0;
	if (x == 0 && y == 0) return 1;
	if (x == state.Length - 1 && y == 0) return 1;
	if (x == 0 && y == state[x].Length - 1) return 1;
	if (x == state.Length - 1 && y == state[x].Length - 1) return 1;

	return state[x][y];
};
Func<int, int, int> getNeighbourSum = (x, y) => getLight(x - 1, y - 1) + getLight(x, y - 1) + getLight(x + 1, y - 1) +
												getLight(x - 1, y) + getLight(x + 1, y) +
												getLight(x - 1, y + 1) + getLight(x, y + 1) + getLight(x + 1, y + 1);
Func<int, int, int> getNextValue = (x, y) =>
{
	if (x == 0 && y == 0) return 1;
	if (x == state.Length - 1 && y == 0) return 1;
	if (x == 0 && y == state[x].Length - 1) return 1;
	if (x == state.Length - 1 && y == state[x].Length - 1) return 1;

	return getNeighbourSum(x, y) == 3 ? 1 :
   (getNeighbourSum(x, y) == 2 && getLight(x, y) == 1) ? 1 : 0;
};
for (int a = 0; a < repetitions; a++)
{
	var nextState = Enumerable.Range(0, state.Length)
		.Select(x => Enumerable.Range(0, state[x].Length)
					.Select(y => getNextValue(x, y)).ToArray()).ToArray();

	state = nextState;
}
state.Sum(row => row.Sum()).Dump(); // 924
									//state.Dump();