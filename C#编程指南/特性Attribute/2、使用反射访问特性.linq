<Query Kind="Program" />

void Main()
{
	SampleClass s=new SampleClass();
	List<Attribute> attrs=s.GetType().GetCustomAttributes().ToList();
	foreach (var attr in attrs)
	{
		if (attr is AuthorAttribute author)
		{
			Console.WriteLine($"Name:{author.Name},Version:{author.Version}");
		}
	}
	
}

// AllowMultiple表示同1个类上不允许声明多个，会直接编译失败
[System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
public class AuthorAttribute : System.Attribute
{
	public string Name { get; private set; }
	public double Version;
	public AuthorAttribute(string name)
	{
		this.Name = name;
		this.Version = 1.0;
	}
}

[Author("张三", Version = 2.0)]
[Author("李四", Version = 3.0)]
[Author("王五", Version = 4.0)]
public class SampleClass
{


}