<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Console.WriteLine("主线程id为:" + Thread.CurrentThread.ManagedThreadId);

	Task.Run(() =>
	{
		//await Task.Delay执行时会立刻返回，执行主方法的其他步骤，直到Delay的时间达到之后才会执行Delay后续的操作
		Console.WriteLine("Task.Run--id为:" + Thread.CurrentThread.ManagedThreadId);

		Console.WriteLine("执行异步方法DelayJob时没有使用await，\r\n执行DelayJob方法时遇到了await Task.Delay,这里会立即返回，\r\n执行子方法和主方法的其他代码");
		new TestClass().DoSomething();

		Console.WriteLine("\r\n\r\n\r\n");

		Console.WriteLine("执行异步方法DelayJob时使用了await，这里会按顺序执行,输出Start=>Start=>End=>End");
		new TestClass1().DoSomething();
		
		Console.WriteLine("结束执行~~~~~~");
	});
	
	Console.WriteLine("最终执行~~~~~~");
}

public class TestClass
{
	public async Task DoSomething()
	{
		Console.WriteLine("DoSomething1---Start");
		
		DelayJob();
		
		Console.WriteLine("DoSomething1---End");
	}
	
	private async Task DelayJob()
	{
		Console.WriteLine("DelayJob1---Start");
		
		
		await Task.Delay(3000);
		
		Console.WriteLine("DelayJob1---End");
	}
}

public class TestClass1
{
	public async Task DoSomething()
	{
		Console.WriteLine("DoSomething2---Start");

		await DelayJob();

		Console.WriteLine("DoSomething2---End");
	}

	private async Task DelayJob()
	{
		Console.WriteLine("当前DelayJob2线程id为:"+Thread.CurrentThread.ManagedThreadId);
		Console.WriteLine("DelayJob2---Start");

		await Task.Delay(3000);

		Console.WriteLine("DelayJob2---End");
	}
}