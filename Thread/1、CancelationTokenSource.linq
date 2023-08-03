<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main()
{
	
	//Console.WriteLine($"主线程的线程id为:"+Thread.CurrentThread.ManagedThreadId);
	//Parallel.For(1, 10, x =>
	//  {
	//  	Console.WriteLine($"当前线程的id为"+Thread.CurrentThread.ManagedThreadId);
	//  });

	CancellationTokenSource cancelTokenSource=new CancellationTokenSource();
	CancellationToken cancelToken=cancelTokenSource.Token;
	//cancelToken
	await Task.Run(async () => 
	{
		Console.WriteLine("开始任务-----------------------");
		int i=0;
		while(true)
		{
			Console.WriteLine("正在执行");
			if(cancelToken.IsCancellationRequested) break;
			i++;
			await Task.Delay(300);
			Console.WriteLine($"当前计数为{i}");
			if (i == 10)
			{
				Console.WriteLine("准备结束循环");
				cancelTokenSource?.Cancel();  //结束任务
				Console.WriteLine("意外执行");
			}
			
		}
		
		Console.WriteLine("结束任务-----------------------");
	},cancelToken);
	
	Console.WriteLine("最后显示~");
}

// You can define other methods, fields, classes and namespaces here