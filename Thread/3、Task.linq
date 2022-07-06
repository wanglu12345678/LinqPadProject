<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	//如果在异步方法中使用await，那最好是一直使用，不要使用Task.Wait方法或者Task.Result,不然可能会导致死锁
	
	//下面就是死锁的示例，错误用法
	
	//开始延迟
	Task task=WaitAsync();
	
	//同步程序块，正在等待异步方法完成
	task.Wait();
	
}

async Task WaitAsync()
{
	//这里await会捕获当前上下文....
	await Task.Delay(TimeSpan.FromSeconds(1));
	//....这里会试图用上面捕获的上下文继续执行
	Console.WriteLine("123");
}

// You can define other methods, fields, classes and namespaces here