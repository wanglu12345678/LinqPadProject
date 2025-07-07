<Query Kind="Program" />

void Main()
{
	var a=new TestClass();
	//a.msgid="123123";

	Console.WriteLine(a.msgid);
	Console.WriteLine(a.msgid);
	Console.WriteLine(a.msgid);

	Console.WriteLine(a.msgid1);
	Console.WriteLine(a.msgid1);
	Console.WriteLine(a.msgid1);

}


public class TestClass
{
	public TestClass()
	{
		if (string.IsNullOrEmpty(msgid))
		{
			msgid = this.fixmedins_code + DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(1000, 10000).ToString();
		}
	}

	public string? fixmedins_code { get; set; } = "H51138100006";
	public string? msgid { get; set; }
	public string? msgid1
	{
		get
		{
			return this.fixmedins_code + DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(1000, 10000).ToString();
		}
	}
}