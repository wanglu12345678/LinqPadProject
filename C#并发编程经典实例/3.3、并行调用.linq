<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Parallel.Invoke(() => { Thread.Sleep(1000); Console.WriteLine("123"); },
					() => { Thread.Sleep(1500); Console.WriteLine("456"); });
	
	
	
}

