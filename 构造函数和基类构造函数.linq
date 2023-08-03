<Query Kind="Program" />

void Main()
{
	new B();
}

public class A
{
	protected virtual string Title {get;set;}
	public A()
	{
		Console.WriteLine("初始化A");
		Console.WriteLine(Title);
	}
}

public class B : A
{
	protected override string Title =>"这是B";
	public B():base()
	{
		Console.WriteLine("初始化B");
	}
}

// You can define other methods, fields, classes and namespaces here