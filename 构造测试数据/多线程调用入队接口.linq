<Query Kind="Program">
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	for (int i = 0; i < 20000; i++)
	{
		var data = new CreateQueueInputDto
		{
			PatientId = "123",
			Name = "张三" + i,
			Sex = "男",
			Age = "20",
			Phone = "15965425621",
			QueueNameId = 8,
			EmployeeId = 6,
			RoomId = 6,
			PriorityTypeId = 6,
			checklimit = false,
			addPerson = false
		};
		Console.WriteLine(getUrlParams(data));
		var url = "http://192.168.101.66:10012/api/services/kiaser/TriageTable/CreateQueue" + getUrlParams(data);
		using (var httpClient = new HttpClient())
		{
			var result = httpClient.GetAsync(url).Result;
		}
	}

	Console.WriteLine("结束");
}

private string getUrlParams(CreateQueueInputDto data)
{
	var sb = new StringBuilder();
	sb.Append("?");
	var dataType = data.GetType();

	var properties = dataType.GetProperties();
	foreach (var propertiey in properties)
	{
		sb.Append($"{propertiey.Name}={propertiey.GetValue(data)}&");
	}
	var newStr = sb.ToString();
	newStr = newStr.Substring(0, newStr.Length - 1);

	return newStr;
}

private int GetPriorityTypeIdByPinYin(string pinYin)
{
	var priorityType = 6;  // 默认为普通
	switch (pinYin)
	{
		case "P":
			priorityType = 6;
			break;

		case "F":
			priorityType = 5;
			break;

		case "J":
			priorityType = 10;
			break;

		case "C":
			priorityType = 9;
			break;

		default:
			priorityType = 6;
			break;
	}

	return priorityType;
}

public class CreateQueueInputDto
{
	/// <summary>
	/// 就诊卡号
	/// </summary>
	public string PatientId { get; set; }
	/// <summary>
	/// 姓名
	/// </summary>
	public string Name { get; set; }
	/// <summary>
	/// 性别
	/// </summary>
	public string Sex { get; set; }
	/// <summary>
	/// 年龄
	/// </summary>
	public string Age { get; set; }
	/// <summary>
	/// 手机号
	/// </summary>
	public string Phone { get; set; }
	//public string CheckQueue { get; set; }
	/// <summary>
	/// 号别id
	/// </summary>
	public int QueueNameId { get; set; }
	//public string Key { get; set; }
	//public string Timeno { get; set; } = "";
	/// <summary>
	/// 医生id
	/// </summary>
	public int EmployeeId { get; set; }
	/// <summary>
	/// 诊室id
	/// </summary>
	public int RoomId { get; set; }
	/// <summary>
	/// 优先级别id
	/// </summary>
	public int PriorityTypeId { get; set; }
	///// <summary>
	///// 队列来源id
	///// </summary>
	//public int queueSourceId { get; set; }
	public bool checklimit { get; set; }
	/// <summary>
	/// 渠道id
	/// </summary>
	public int ChannelId { get; set; } = 1;
	public bool addPerson { get; set; }
}