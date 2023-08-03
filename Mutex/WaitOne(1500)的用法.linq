<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>


private Mutex _mux=new Mutex();
void Main()
{
	Task.Run(Do1);
	Task.Run(Do2);
}

public void Do1()
{
	_mux.WaitOne();
	
	Console.WriteLine("Do1获取了控制权");
	Console.WriteLine("2秒后释放控制后Do2才能获取控制权");
	
	Thread.Sleep(2000);
	
	_mux.ReleaseMutex();
}

public void Do2()
{
	// 这里等到3秒，如果超过3秒则不会去获取
	if (_mux.WaitOne(3000))
	{
		Console.WriteLine("Do2获取了控制权");
		_mux.ReleaseMutex();
	}
}