<Query Kind="Program" />

void Main()
{
	var ss=new MyPerson();
	ss.Id=123;
	ss.Name="张三";
	ss.Do();
	
}

// 结构无法被继承
struct MyPerson:IAge,ISex
{ 
	public int Id;
	//public int Id=123;  // 错误，结构中的字段无法赋初值
	public string Name;

	// 结构体的构造函数需要给所有的字段赋初值，不然会报错
	public MyPerson()
	{
		this.Id=123;
		this.Name="123";
	}

	public void Do()
	{
		Console.WriteLine($"Id:{Id},Name:{Name}");
	}
}

public interface IAge{ }

public interface ISex { }