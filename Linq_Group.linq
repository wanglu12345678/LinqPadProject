<Query Kind="Program" />

void Main()
{
	var list = new List<TestClass>
	{
		new TestClass{ UserName="aaa",Password="123" },
		new TestClass{ UserName="aaa",Password="1234" },
		new TestClass{ UserName="aaa",Password="123" },
		new TestClass{ UserName="bbb",Password="123" },
		new TestClass{ UserName="bbb",Password="1234" },
		new TestClass{ UserName="bb",Password="123" },
		new TestClass{ UserName="bb",Password="1234" },
		new TestClass{ UserName="cc",Password="123" },
		new TestClass{ UserName="cc",Password="123" },
		new TestClass{ UserName="cc",Password="123" },
		new TestClass{ UserName="cc",Password="1233" },
		new TestClass{ UserName="cc",Password="123" },
		new TestClass{ UserName="cc",Password="12345" }
	};

	var aa = list.GroupBy(x => new { x.UserName, x.Password}).Select(t=>t.Key).ToList();
	
	aa.Dump();
}

public class TestClass
{
	public string UserName { get; set; }
	public string Password { get; set; }
}