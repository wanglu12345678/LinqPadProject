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
 	var result=GetValueAsync();
	
	// 这里没有做等待，所以实际上这里的输出会在异步线程执行完的时候输出，但是前后的内容会直接输出（1  2）
	Console.WriteLine(result);
	Console.WriteLine("Test End  2");
}


public async Task<string> GetValueAsync()
{
	// 这里使用await调用时才是1个异步的调用,当程序遇到await时就会立即返回，不阻塞当前线程
	var result=await Task.Run(() => 
	{
		for (int i = 0; i < 3; i++)
		{
			Thread.Sleep(1000);
			Console.WriteLine($"From Task：{i}");
		}
		
		return "123";
	});
	Console.WriteLine("Task End  3");
	
	return result;
}
