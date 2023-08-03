<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main()
{
	Stopwatch sw=new Stopwatch();
	sw.Start();
	
	Task<int> task1 = Task.FromResult(100);

	Task<int> task2 = Task.Run<int>(async () =>
	{
		await Task.Delay(1500);
		throw new Exception("task2发生了错误");
		//return 2000;
	});

	Task<int> task3 = Task.FromResult(300);

	Task<int> task4 = Task.Run<int>(async () =>
	  {
		 await Task.Delay(1000);
		 throw new Exception("task4发生了错误");
//	     return 10;
	  });
	  
	//int[] result = await Task.WhenAll(task1,task2,task3,task4);

	sw.Stop();

	Console.WriteLine($"总共耗时{sw.ElapsedMilliseconds}毫秒");


	//如果子任务抛出错误，如果需要获得所有任务的错误，则可以在catch方法中获取task的Exception
	Task<int[]> allTasks=Task.WhenAll(task2,task4);
	try
	{
		var result1=await allTasks;
		result1.Dump();
	}
	catch
	{
		Console.WriteLine("发生了错误");
		AggregateException allException=allTasks.Exception;
		foreach (var exception in allException.InnerExceptions)
		{
			//这里可以捕获每个任务的错误，在这里输出错误信息
			Console.WriteLine(exception.Message);
		}
	}
	

	//result.Dump();
}

