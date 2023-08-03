<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>System.Text.Json</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	// 这里的参数名称sdf对应类中声明的JsonProperty属性对应的值
	var jsonStr="{ sdf:\"100\",Message:\"这里是消息内容\" }";
	
	var obj=JsonConvert.DeserializeObject<Response>(jsonStr);
	
	obj.Dump();
}

public class Response
{
	[JsonProperty("sdf")]
	public int Code {get;set;}

	[JsonProperty("message")]
	public string Message {get;set;}
}
