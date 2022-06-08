<Query Kind="Program" />

void Main()
{
	var duration = Time(() => LongRunningFunction());
	Console.WriteLine(duration);
}

void LongRunningFunction()
{
	Thread.Sleep(2000);
}

long Time(Action action)
{
	var s = new Stopwatch();
	s.Start();
	action();
	s.Stop();
	return s.ElapsedMilliseconds;
}
