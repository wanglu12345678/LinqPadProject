<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main()
{
	while (true)
	{
		await DoSomeThing();
		
		Thread.Sleep(2000);
	}
}

Task DoSomeThing()
{
	return Task.Run(async () => {
		Console.WriteLine("准备执行"+DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
		await Task.Delay(2000);
		Console.WriteLine("正在执行"+DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
	});
}
