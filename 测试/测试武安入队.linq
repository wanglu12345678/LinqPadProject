<Query Kind="Program">
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	var queueList = new string[] { "P", "F", "P", "P", "J", "P", "F", "J", "J", "P", "F", "J", "F", "J", "C" };

	// 急诊的测试数据 QueueNameId 695   EmployeeId 700   RoomId 184   DoctorCode jz_2005
	var data = new CreateQueueInputDto
	{
		PatientId = "123",
		Sex = "男",
		Age = 20,
		Phone = "15965425621",
		QueueNameId = 636,
		EmployeeId = 651,
		RoomId = 127,
		CurrentNo = 0,
		blh = "123123",
		patid = "123123",
		Name = "出去玩出去",
		PriorityTypeId = 6,
		hiskey = "34234",
		AppointTime = DateTime.Now
	};
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

	Console.WriteLine(newStr);


	var url = "http://localhost:7099/api/services/kiaser/TriageTable/CreateQueue" + newStr;
	using (var httpClient = new HttpClient())
	{
		var result = await httpClient.GetAsync(url);
		var str = await result.Content.ReadAsStringAsync();

		Console.WriteLine($"当前Hiskey{data.hiskey},当前入队结果为：{str}");
	}

	Console.WriteLine("结束");
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
	public int Age { get; set; }
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

	/// <summary>
	/// 当前号
	/// </summary>
	public int CurrentNo { get; set; }

	public string blh { get; set; }
	public string patid { get; set; }
	public string hiskey { get; set; }

	public string Key { get; set; }

	/// <summary>
	/// 就诊开始时间
	/// </summary>
	public string StartTime { get; set; }
	/// <summary>
	/// 就诊结束时间
	/// </summary>
	public string EndTime { get; set; }

	/// <summary>
	/// 挂号时间
	/// </summary>
	public DateTime? AppointTime { get; set; }
}