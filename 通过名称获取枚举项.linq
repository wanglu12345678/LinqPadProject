<Query Kind="Program" />

void Main()
{
	var a=Enum.GetNames(typeof(Key));
	
	var c=(Key)Enum.Parse(typeof(Key),"Down");
	
	Console.WriteLine(c);
}

public enum Key
{
	Up=1,
	Down=2,
	F2=3
}
