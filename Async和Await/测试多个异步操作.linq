<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main()
{
	Test1();
	await Test2();  // 这里添加await等待，所以test3的执行肯定是要在test2执行结束之后执行
	Test3();
}

private async Task Test1()
{
	Console.WriteLine("当前进程id："+Thread.CurrentThread.ManagedThreadId);  // 开始调用时的进程和结束时的进程可能不一样
	Console.WriteLine("Test1-Start");
	await Task.Delay(2000);   // 执行到此处会立刻返回去执行其他的代码，
	Console.WriteLine("当前进程id："+Thread.CurrentThread.ManagedThreadId);
	Console.WriteLine("Test1-End");
}

private async Task Test2()
{
	Console.WriteLine("Test2-Start");
	await Task.Delay(1000);  
	Console.WriteLine("Test2-End");
}

private async Task Test3()
{
	Console.WriteLine("Test3-Start");
	await Task.Delay(1500);
	Console.WriteLine("Test3-End");
}