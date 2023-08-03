<Query Kind="Program" />

void Main()
{
	// Queue为先进先出队列
	Queue<string> list=new Queue<string>();
	list.Enqueue("张三");
	list.Enqueue("李四");
	list.Enqueue("王五");
	list.Enqueue("赵六");
	
	var first=list.Dequeue();
	Console.WriteLine(first);
	list.Dump();
	var second=list.Dequeue();
	Console.WriteLine(second);
	list.Dump();
}

