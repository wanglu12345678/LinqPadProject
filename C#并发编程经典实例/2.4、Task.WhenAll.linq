<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	var task1 = Test1();
	var task2 = Test2();
	Task allTask = Task.WhenAll(task1, task2);
	try
	{
		await Task.WhenAll(allTask);
	}
	catch // 如果这里catch(Exception ex) 那么ex就是任务中任意1个任务的错误
	{
		AggregateException allExceptions=allTask.Exception;
		allExceptions.Dump();
	}
}

async Task Test1()
{
	throw new Exception("Test1发生了错误");
}


async Task Test2()
{
	throw new Exception("Test2发生了错误");
}