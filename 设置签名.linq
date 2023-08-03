<Query Kind="Program">
  <Namespace>System.Dynamic</Namespace>
</Query>

void Main()
{
	var userInfo = new CodeRequest{ username="admin", password="123456" };
	
	SetSignValue(userInfo);
	
	Console.WriteLine(userInfo);
	
}

private object SetSignValue(object scanCodePayRequest)
{
	var type = scanCodePayRequest.GetType();
	var propertyInfo = type.GetProperty("signValue");
	if (propertyInfo != null)
	{
		propertyInfo.SetValue(scanCodePayRequest, "这里是签名结果");
	}

	return scanCodePayRequest;
}

public class CodeRequest
{
	public string username {get;set;}
	public string password {get;set;}
	public string signValue {get;set;}
}
