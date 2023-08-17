<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	var task1=Test1();
	var task2=Test2();
	// 2个任务都会正常运行，只是其中1个任务的结果和异常会被忽略
	
	// Task.WhenAny返回的task对象永远不会以故障或已取消状态作为结束，该方法的运行结果总是以一个Task首先完成
	// !!!注意：这里只要有1个任务返回结果了，其他的任务也会继续执行直到完成，但是他们的结果会被忽略，抛出的异常也会忽略
	// 但如果像以下示例，第一个任务始终会是抛出错误的任务，所以下面的代码会抛出错误，同时也会输出Test1任务的123
	var completedTask=await Task.WhenAny(task1,task2);
	var data=await completedTask;
	Console.WriteLine(data);
}

async Task<int> Test1()
{
	await Task.Delay(2000);
	Console.WriteLine("123");
	return 123;
}

async Task<int> Test2()
{
	await Task.Delay(1500);
	throw new Exception("Test2发生了错误");
}