<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

	Task.Run(() =>
	{
		Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
	});

	Parallel.For(0, 1,e=>
	{
		Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
	});
}

