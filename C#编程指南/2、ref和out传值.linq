<Query Kind="Program" />

void Main()
{
	int i=0;  //ref 的变量必须先赋值
	Test1(ref i);
	Console.WriteLine(i); // 输出123
	
	int b;  // out的变量可以不用先赋值
	Test2(out b);
	Console.WriteLine(b); // 输出456
	
	Test2(out int c);  // 也可以这样写
	Console.WriteLine(c); // 输出456
}

private void Test1(ref int i)
{
	i=123;
}

private void Test2(out int i)
{
	i=456;
}
