<Query Kind="Program" />


public Mutex mutex=new Mutex(true);

void Main()
{
	Console.WriteLine("主线程占用mutex");
	var a=new Thread(new ThreadStart(ThreadMethod));
	a.Name="线程1";
	a.Start();


	var b = new Thread(new ThreadStart(ThreadMethod));
	b.Name = "线程2";
	b.Start();

	Thread.Sleep(2000);
	Console.WriteLine("主线程释放mutex锁资源");
	
	mutex.ReleaseMutex();
}


void ThreadMethod()
{
	Console.WriteLine($"{Thread.CurrentThread.Name}正在等待锁资源");
	
	mutex.WaitOne();
	
	Console.WriteLine($"{Thread.CurrentThread.Name}已获取到资源----");
	
	mutex.ReleaseMutex();
}

