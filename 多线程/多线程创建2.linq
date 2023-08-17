<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Console.WriteLine("主线程id为："+Thread.CurrentThread.ManagedThreadId);
	var list = new List<int> { 1, 2, 3 };
	
	Console.WriteLine("Linq的AsParallel会开启新的线程但是不会在主线程中");
	list.AsParallel().ForAll(x =>
	{
		Console.WriteLine("当前线程id为："+Thread.CurrentThread.ManagedThreadId);
		x+=2;
	});
	
	Console.WriteLine("--------------------------------------------");
	
	Console.WriteLine("Parallel.ForEach会开启新的线程，但是还是会有线程在主线程中");
	Parallel.ForEach(list, x => 
	{
		Console.WriteLine("当前线程id为："+Thread.CurrentThread.ManagedThreadId);
	});
	
	Console.WriteLine("--------------------------------------------");

	Console.WriteLine("Parallel.For开启的线程也在主线程中,这里会循环执行4次");
	Parallel.For(1, 5, x => 
	{
		Console.WriteLine("当前线程id为："+Thread.CurrentThread.ManagedThreadId);
	});
	
	Console.WriteLine("--------------------------------------------");

	Console.WriteLine("Task.Run会开启新的线程，线程不会在主线程中");
	Task.Run(() =>
	{
		Console.WriteLine("当前线程id为："+Thread.CurrentThread.ManagedThreadId);
	});
}

