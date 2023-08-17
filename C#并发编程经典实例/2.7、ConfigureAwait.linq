<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	// 在默认情况下，1个async方法在被await调用后恢复运行时，会在原来的上下文中运行
	// 如果是UI上下午，并且有大量的async方法在UI上下文中恢复，就会引起性能上的问题
	// 为了避免在上下文中恢复运行，可让await调用ConfigureAwait方法的返回值，参数设为false
	
	// 如果线程中不需要上下文（处理UI元素或Asp.NET请求/响应），则可以使用ConfigureAwait(false)来阻止回到上下文
	// 如果线程中需要上下文则不需要处理
	// 如果线程中有的需要上下文有的不需要则可以考虑拆分成2个或更多方法
	
	await Test1();
	await Test2().ConfigureAwait(false);
}

async Task Test1()
{
	await Task.Delay(1000);
}

async Task Test2()
{
	await Task.Delay(2000).ConfigureAwait(false);
}






