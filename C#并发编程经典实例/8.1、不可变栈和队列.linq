<Query Kind="Program">
  <Namespace>System.Collections.Immutable</Namespace>
</Query>

void Main()
{
	// 需要一个不会经常修改、可以被多个线程安全访问的栈或队列
	// 1、后进先出队列ImmutableStack<T>
	var cc = ImmutableStack<int>.Empty;
	cc=cc.Push(13);
	cc=cc.Push(7);
	cc.Dump();
	
	int lastItem;
	cc=cc.Pop(out lastItem);
	cc.Dump();
	// 这里根据后进先出的规则，lastItem的值是7
	lastItem.Dump();
}

