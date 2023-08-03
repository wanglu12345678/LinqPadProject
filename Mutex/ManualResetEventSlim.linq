<Query Kind="Program" />

void Main()
{
	var mres = new ManualResetEventSlim(false);

	var i = 0;
	// 这里是等待3秒后执行，如果这里没有set，
	//那么它会一直执行，
	// 这里会等待3秒获取是否为阻塞的状态，这里初始化为阻塞状态，这里的wait获取到的就是false。！的操作就是true
	// 方法体里面使用set方法设置为非阻塞状态， 那么wait获取到的就是true，！的操作就是false就会结束循环
	while (!mres.Wait(3000))
	{
		i++;
		Console.WriteLine("正在执行" + "--" + i);
		if (i > 3) 
		{
			// 这里执行到4之后就会退出
			mres.Set();
		}
	}
	Console.WriteLine("执行结束");
}


