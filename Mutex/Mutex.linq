<Query Kind="Program">
  <Connection>
    <ID>70b773cb-1918-4303-a4bb-c7669363764f</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <ConvertUnderscoresToPascal>true</ConvertUnderscoresToPascal>
    <Server>127.0.0.1</Server>
    <UserName>root</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAnVl7zVfSiUeEtlsMNjDZIAAAAAACAAAAAAAQZgAAAAEAACAAAACh64ijpj/USaFqNxSonA5cg70uqfKGEm452HlDoufd9QAAAAAOgAAAAAIAACAAAADiEe2JUHHACLyic6w2pPrZ2uRM6em7bJV3Qfhr0phRXRAAAACyiCx9FqRNt++rPcxvba83QAAAAFRLmZgvbBIwkJDmJQhtdLrUVM9SPGDNGNBMlZTOahq+Ve64bgXruoi9a8DH9vCTrokyH2ZxdZbXDcpT0PLzqvA=</Password>
    <Database>gdfy</Database>
    <DriverData>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Pomelo.EntityFrameworkCore.MySql</EFProvider>
      <Port>3306</Port>
    </DriverData>
  </Connection>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

private static string name = "ABC";
private static Mutex mutex = new Mutex();
private static int count = 0;

void Main(string[] args)
{
	Console.WriteLine($"当前的线程id为{Thread.CurrentThread.ManagedThreadId}");
	Task.Run(() =>
	{
		GetName(1);
	});

	Task.Run(() =>
	{
		GetName(2);
	});

	Console.ReadLine();
}

/// <summary>
/// 
/// </summary>
public static void GetName(int i)
{
	Console.WriteLine($"当前GetName的线程id为{Thread.CurrentThread.ManagedThreadId}");
	Console.WriteLine($"GetName:{i}--Start,DateTime:{DateTime.Now}");

	//这里是使用了互斥锁，当前只有1个会进入，直到释放了互斥锁，下一个才会进入
	mutex.WaitOne();

	count += i;

	Console.WriteLine($"相加的值为:{count}");

	if (!name.Contains(i.ToString()))
	{
		name += i;
	}

	Console.WriteLine(name);

	//释放当前互斥锁
	mutex.ReleaseMutex();

	Console.WriteLine($"GetName:{i}--End,DateTime:{DateTime.Now}");
}

// You can define other methods, fields, classes and namespaces here