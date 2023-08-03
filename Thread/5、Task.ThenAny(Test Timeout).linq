<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main()
{
	//Task.WhenAny当任意1个任务响应时即返回这个任务
	
	var task=new TestClass().DoSomething();
	
	/*
		这里时判断哪个任务先响应，先响应的任务就会先返回
		注意，这里设置的值就算小于task的Delay数值，但是如果只小于1毫秒这种，依然可能会显示超时
	*/
	
	var timeoutTask =Task.Delay(2000);  
	var completedTask=await Task.WhenAny(task,timeoutTask);

	if (completedTask == timeoutTask) 
	{
		Console.WriteLine("任务超时~~~");
	}
	else
	{
		Console.WriteLine("任务正常执行~~~");
		Console.WriteLine(completedTask);		
	}
}

public class TestClass
{
	public async Task<int> DoSomething()
	{
		Console.WriteLine("开始DoSomething---");
		await Task.Delay(3000);
		return 10;
	}
}

// You can define other methods, fields, classes and namespaces here