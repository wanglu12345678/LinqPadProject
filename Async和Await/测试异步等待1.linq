<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Test();
}

void Test()
{
	Console.WriteLine("Test Start  1");
	// 如果在test方法上添加了async声明为异步方法又在此处使用了await，那么输出就会是 1=》task输出=》3=》2
 	GetValueAsync();
	Console.WriteLine("Test End  2");
}

public async Task GetValueAsync()
{
	// 这里会开启1个异步的线程去处理Task，
	// 如果这里不用await，那么输出内容就是  1==>3==>2，最后才是task的输出
	// 这里加了await的话，那么await后面的输出会等待await的执行，所以会输出1==》2 =》task的输出==》3
	
	// 这里使用await调用时才是1个异步的调用
	await Task.Run(() => 
	{
		Thread.Sleep(1000);
		for (int i = 0; i < 3; i++)
		{
			Console.WriteLine($"From Task：{i}");
		}
		
		return "123";
	});
	
	Console.WriteLine("Task End  3");
}
