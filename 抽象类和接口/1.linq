<Query Kind="Program" />

void Main()
{
	Order1 order1=new Order1();
	Order2 order2=new Order2();
	order1.Excute();
	order2.Excute();
	
}

public interface IAnimal
{ 
	public const string ss="123";

	void ccc();
}

public abstract class IOrder
{
	/// <summary>私有字段</summary>
	private string PrivateName {get;set;}
	
	/// <summary>公共字段</summary>
	public string OrderName;
	public decimal OrderAmount;

	/// <summary>属性</summary>
	public string MyName {get;set;}
	
	public abstract void Do();

	public void Excute()
	{
		Console.WriteLine("Excute-start");
		
		Do();
		
		Console.WriteLine("Excute-end");
	}
}

public class Order1 : IOrder
{
	public Order1()
	{
		this.OrderName="Order1";
		this.OrderAmount=100;
	}
	
	public override void Do()
	{
		Console.WriteLine("Order1-Do");
	}
}

public class Order2 : IOrder
{
	public Order2()
	{
		this.OrderName = "Order2";
		this.OrderAmount = 200;
	}
	
	public override void Do()
	{
		Console.WriteLine("Order2-Do");
	}
}
