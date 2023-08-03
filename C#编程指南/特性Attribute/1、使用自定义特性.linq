<Query Kind="Program" />

void Main()
{
	var obj=typeof(SampleClass).GetCustomAttributes(true).Where(x=>x.GetType()==typeof(AuthorAttribute)).FirstOrDefault();
	obj.Dump();
}

// AllowMultiple表示同1个类上不允许声明多个，会直接编译失败
[System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct,AllowMultiple=false)]
public class AuthorAttribute : System.Attribute
{
	public string Name {get;private set;}
	public double Version;
	public AuthorAttribute(string name)
	{
		this.Name=name;
		this.Version=1.0;
	}
}

[Author("张三",Version=2.0)]
public class SampleClass
{ 
	
	
}