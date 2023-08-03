<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Console.WriteLine("主线程id:"+Thread.CurrentThread.ManagedThreadId);
	Console.WriteLine("开始");
	Task.Run(async() => 
	{
		await TestRequest();
	});
	Console.WriteLine("结束");
}

private async Task TestRequest()
{
	Console.WriteLine("异步线程id:"+Thread.CurrentThread.ManagedThreadId);
	await Task.Delay(3000);
	Console.WriteLine("请求完成");
}

// You can define other methods, fields, classes and namespaces here