<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main()
{
	Console.WriteLine("主线程id："+Thread.CurrentThread.ManagedThreadId);
	DoSomeThing2();
}

public async Task DoSomeThing()
{
	// 和主方法是在同一个进程
	Console.WriteLine("DoSomeThing，当前线程id为："+Thread.CurrentThread.ManagedThreadId);
	Thread.Sleep(2000);
	Console.WriteLine(nameof(DoSomeThing));
}

public async Task DoSomeThing1()
{
	await Task.Run(() =>
	{
		Console.WriteLine("DoSomeThing1，当前线程id为："+Thread.CurrentThread.ManagedThreadId);
		Thread.Sleep(2000);
		Console.WriteLine(nameof(DoSomeThing));
	});
}

public async Task DoSomeThing2()
{
	// Parallel.For会创建新的线程，但是也会有线程在主线程中运行
	Parallel.For(0, 5, i =>
	{
		Console.WriteLine("DoSomeThing2，当前线程id为："+Thread.CurrentThread.ManagedThreadId);
		Console.WriteLine(i);
	});
}

public async Task DoSomeThing3()
{
	await Task.Run(() =>
	{
		// Parallel.For会创建新的线程，但是也会有线程在主线程中运行,可以在外层包一层Task.Run，这样就不会在主线程运行
		Parallel.For(0, 5, i =>
		{
			Console.WriteLine("DoSomeThing3，当前线程id为：" + Thread.CurrentThread.ManagedThreadId);
			Console.WriteLine(i);
		});
	});
}
