<Query Kind="Program" />

void Main()
{
	var userInfo=new UserInfo();
	Type classType=userInfo.GetType();
	//根据类型创建实例
	object classInstance=Activator.CreateInstance(classType);
	PropertyInfo name=classType.GetProperty("Name");
	name.SetValue(classInstance,"张三");
	Console.WriteLine(classInstance);
	
	//
	
}

public class UserInfo
{
	public string Name {get;set;}
}
