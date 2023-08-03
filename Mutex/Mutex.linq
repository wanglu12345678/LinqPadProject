<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

private static string name = "ABC";
private static Mutex mutex = new Mutex();
private static int count = 0;

void Main(string[] args)
{
	Console.WriteLine($"当前的线程id为{Thread.CurrentThread.ManagedThreadId}");
	Task.Run(() =>
	{
		GetName(1);
	});

	Task.Run(() =>
	{
		GetName(2);
	});

	Task.Run(() =>
	{
		GetName(5);
	});

	Console.ReadLine();
}

/// <summary>
/// 
/// </summary>
public static void GetName(int i)
{
	Console.WriteLine($"当前GetName的线程id为{Thread.CurrentThread.ManagedThreadId}");
	Console.WriteLine($"GetName:{i}--Start,DateTime:{DateTime.Now}");

	//这里是使用了互斥锁，当前只有1个会进入，直到释放了互斥锁，下一个才会进入
	mutex.WaitOne();

	count += i;

	Console.WriteLine($"相加的值为:{count}");

	if (!name.Contains(i.ToString()))
	{
		name += i;
	}

	Console.WriteLine(name);

	//释放当前互斥锁
	mutex.ReleaseMutex();

	Console.WriteLine($"GetName:{i}--End,DateTime:{DateTime.Now}");
}

// You can define other methods, fields, classes and namespaces here