<Query Kind="Program" />

void Main()
{
	var s=new Test();
	s.Do();
	
	Console.WriteLine(Test.kk);  // const字段默认就是静态的
}


public class Test
{
	public const string kk="111";  // const修饰的字段默认就是静态static的
	//private static const string kk1 = "111";  // const声明的字段不能用static修饰
	private readonly string ss = "123";
	private static readonly string ss1 = "123";

	public Test()
	{
		ss="789";
		//kk="222";  // 这里不能给常量赋值，会直接报错
	}

	public void Do()
	{
		Console.WriteLine(ss);
	}
}