<Query Kind="Program" />


public delegate void GetStringDelegate(int a,int b);

void Main()
{
	GetStringDelegate myDelegate = Test;
	GetStringDelegate myDelegate1 = Test1;
	GetStringDelegate c=myDelegate+myDelegate1;
	
	//c-=myDelegate1;
	
	
	c(1,2);
}

private void Test(int x, int y)
{
	Console.WriteLine($"自定义名称：{x}:{y}");
}

private void Test1(int x, int y)
{
	Console.WriteLine($"自定义名称1：{x}:{y}");
}

