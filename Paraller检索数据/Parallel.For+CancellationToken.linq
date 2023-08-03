<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

private CancellationTokenSource cacelTokenSource=new CancellationTokenSource();
private CancellationToken _token => cacelTokenSource.Token;
private int totalCount=0;

void Main()
{
	Console.WriteLine("主线程id："+Thread.CurrentThread.ManagedThreadId);
	Test();
}

private void Test()
{
	Task.Run(() =>
	{
		// 发现Paraller会开启多个线程执行，但是有的也会在主线程中调用，所以应该在外层包一层Task.Run不影响主线程
		Parallel.For(1, 10000000, new ParallelOptions { CancellationToken = _token }, (i) =>
		{
			totalCount+=1;
			if (i == 854511)
			{
				cacelTokenSource.Cancel();
				Console.WriteLine($"已获取到结果：{i}");
				Console.WriteLine($"总共检索：{totalCount}次");
			}
			Task.Delay(1000);
			//Console.WriteLine($"当前线程：{Thread.CurrentThread.ManagedThreadId},当前值：{i}");
		});
	});
}
