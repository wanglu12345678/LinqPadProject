<Query Kind="Program" />


private delegate int MyDelegate(int a,int b);

void Main()
{
	var a=new MyDelegate(Test);
	a+=Test1;  // 多播委托
	var c=a(1,5);
	Console.WriteLine(c);
}

public int Test(int a, int b)
{
	Console.WriteLine("Test");
	return a + b;
}

public int Test1(int a, int b)
{
	Console.WriteLine("Test1");
	return (a*b)*2;
}
