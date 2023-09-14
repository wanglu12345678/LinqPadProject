<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var cts=new CancellationTokenSource();
	var task = new Task(() => 
	{
		Console.WriteLine(cts.IsCancellationRequested);
		while (!cts.IsCancellationRequested)
		{
			Thread.Sleep(1000);
			Console.WriteLine("正在执行");
		}
	},cts.Token);
	task.Start();
	
	//Thread.Sleep(3000);
	//Console.WriteLine("3秒后停止线程");
	//cts.Cancel();
	
	cts.CancelAfter(4000);
}

