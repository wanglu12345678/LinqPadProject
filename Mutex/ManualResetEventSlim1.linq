<Query Kind="Program" />

void Main()
{
	var mres = new ManualResetEventSlim(false); // state is initially false
	var i=0;
	while (!mres.Wait(3000)) // loop until state is true, checking every 3s
	{
		Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
		// 每3秒会去连接1次，直到信号量为true
		try
		{
			i++;
			Console.WriteLine("正在连接"+i);
			// 这里总共会执行9秒才会停止重复运行
			if (i == 3) 
			{
				Console.WriteLine("已连接");
				mres.Set(); // 设置信号量为true
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error");
		}
	}
}

