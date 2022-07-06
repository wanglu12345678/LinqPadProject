<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	//这里使用Paraller演示数据并行和任务并行2种方式
	
	/*
		1、数据并行处理有1个非常重要的规则就是每个任务快要尽可能的互相独立
		2、任务并行，任务和任务之间不使用独占锁
	*/
	
	Task.Run(() => 
	{
		new TestClass().DoSomething();
		
		Console.WriteLine();
		
		new TestClass().DoSomething1();
		
		Console.WriteLine();
		
		new TestClass().DoSomething2();
	});
}

public class TestClass
{
	private List<int> _numList=new List<int>();
	
	/// <summary>这里使用Paraller.ForEach使用数据并行计算数字的平方</summary>
	public void DoSomething()
	{
		Console.WriteLine("使用数据并行的方式计算，大概0.9秒");
		System.Collections.Generic.List<int> list = new List<int> { 1,2,3,4,5,6,7,8,9 };
		System.Collections.Generic.List<int> newList=new List<int>();

		Stopwatch watch = new Stopwatch();
		watch.Start();
		Parallel.ForEach(list, num => 
		{
			newList.Add(ToSquare(num));
		});
		watch.Stop();
		Console.WriteLine($"共耗时:{watch.Elapsed.TotalMilliseconds}毫秒");
		
		Console.WriteLine(newList);
		Console.WriteLine("结束");
	}
	
	/// <summary>使用数据并行的方式计算</summary>
	public void DoSomething1()
	{
		Console.WriteLine("使用同步的方式计算，大概4秒多");
		System.Collections.Generic.List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		System.Collections.Generic.List<int> newList = new List<int>();

		Stopwatch watch = new Stopwatch();
		watch.Start();
		foreach (var num in list)
		{
			newList.Add(ToSquare(num));
		}
		watch.Stop();
		Console.WriteLine($"共耗时:{watch.Elapsed.TotalMilliseconds}毫秒");

		Console.WriteLine(newList);
		Console.WriteLine("结束");
	}

	/// <summary>这里使用任务并行的方式计算</summary>
	public void DoSomething2()
	{
		try
		{
			Console.WriteLine("使用任务并行的方式，大概0.9秒");
			Stopwatch watch = new Stopwatch();
			watch.Start();
			Parallel.Invoke(
				() => ToSquare1(1),
				() => ToSquare1(2),
				() => ToSquare1(3),
				() => ToSquare1(4),
				() => ToSquare1(5),
				() => ToSquare1(6),
				() => ToSquare1(7),
				() => ToSquare1(8),
				() => ToSquare1(9)
			);
			watch.Stop();
			Console.WriteLine($"共耗时:{watch.Elapsed.TotalMilliseconds}毫秒");
			Console.WriteLine(_numList);
			Console.WriteLine("执行完成");
		}
		catch (AggregateException ex)
		{
			//这里的错误可以在catch中捕获AggregateException
			ex.Handle(exception =>
			{
				Trace.Write(exception);
				return true; //已经处理
			});
		}
	}

	private int ToSquare(int num)
	{
		Thread.Sleep(num*100);
		return num*num;
	}

	private void ToSquare1(int num)
	{
		Thread.Sleep(num * 100);
		var square= num * num;

		if (!_numList.Contains(square))
		{
			_numList.Add(square);
		}
	}
}