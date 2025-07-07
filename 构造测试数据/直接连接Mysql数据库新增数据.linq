<Query Kind="Program">
  <NuGetReference>SqlSugarCore</NuGetReference>
  <Namespace>SqlSugar</Namespace>
</Query>

public static object obj=new Object();
void Main()
{
	var db = new SqlSugarClient(new ConnectionConfig
	{
		ConnectionString = "Data Source=192.168.101.69;User ID=root;Initial Catalog=hiqs;Password=clear123;Convert Zero Datetime=True",
		DbType = SqlSugar.DbType.MySql,
		IsAutoCloseConnection = false,
		InitKeyType = InitKeyType.Attribute,
	});
	//db.Ado.GetScalar($"INSERT INTO `t_queue` VALUES (1, '张三1', '123', '15965425621', 8, '男', '20', 0, 6, 1, '2023-12-06 15:05:39', NULL, '0001-01-01 00:00:00', 6, NULL, 1, NULL, 0, NULL, 0, 0, 11000000, NULL, 6, 0, 0, '0001-01-01 00:00:00', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, 0, NULL);");

	for (int i = 0; i < 20000; i++)
	{
		db.Ado.GetScalar($"INSERT INTO `t_queue` VALUES ({i}, '张三{i}', '123', '15965425621', 8, '男', '20', 0, 6, 1, '2023-12-06 15:05:39', NULL, '0001-01-01 00:00:00', 6, NULL, 1, NULL, 0, NULL, 0, 0, 11000000, NULL, 6, 0, 0, '0001-01-01 00:00:00', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, 0, NULL);");
	}
}

