<Query Kind="Program" />

void Main()
{
	
}

/// <summary>自定义密封类</summary>
public sealed class MySealed
{ 
	public int i=0;

	public void MyMethod()
	{
		Console.WriteLine("密封类");
	}
}

/// <summary>密封类不能被继承</summary>
public class OtherClass : MySealed
{ 
	
	
}
