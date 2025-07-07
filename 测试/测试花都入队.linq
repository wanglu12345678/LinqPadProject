<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	var names = new string[] { "张三", "李四", "王五", "水电费", "大哥发的", "电饭锅", "第三方", "阿萨德", "支持支持", "南方姑", "萨达",
	"北大法宝", "是不额外", "胜多负少", "地区五", "当前温度","而额头","德玛西亚","和规范化","金龟换" };
	
	var index = 0;
	foreach (var name in names)
	{
		if (index <1)
		{
			await ToCreateQueue(index, name);
			Thread.Sleep(300);
		}
		index++;
	}
}

public async Task ToCreateQueue(int index, string name)
{
	// 如果需要测急诊的，数据为 QueueNameId 695   EmployeeId 700   RoomId 184   DoctorCode jz_2005
	var data = new CreateQueueInputDto
	{
		PatientId = "123",
		Sex = "男",
		Age = 20,
		Phone = "15965425621",
		QueueNameId = 509,
		EmployeeId = 507, // 404,
		RoomId = 185,
		CurrentNo = 0,
		blh = "123123",
		patid = "123123",
		StartTime = DateTime.Now.AddMinutes(-10),
		EndTime = DateTime.Now.AddMinutes(5),
		DoctorCode = "0304",
		CheckProject = "123",
		Name = name,
		PriorityTypeId = 6,
		hiskey = DateTime.Now.ToString("yyyy-MM-dd")+ index.ToString(),
		IS_CONSULTATION="会诊",
		HisPolicyNumber=(index+1).ToString()
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


	var url = "http://localhost:7098/api/services/kiaser/TriageTable/CreateQueue" + newStr;
	using (var httpClient = new HttpClient())
	{
		var result = await httpClient.GetAsync(url);
		var str = await result.Content.ReadAsStringAsync();

		Console.WriteLine($"当前Hiskey{data.hiskey},当前入队结果为：{str}");
	}

	Console.WriteLine("结束");
}

private int GetPriorityTypeIdByPinYin(string pinYin)
{
	var priorityType=6;  // 默认为普通
	switch (pinYin)
	{
		case "P":
			priorityType=6;
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

	/// <summary>
	/// 就诊开始时间
	/// </summary>
	public DateTime? StartTime { get; set; }
	/// <summary>
	/// 就诊结束时间
	/// </summary>
	public DateTime? EndTime { get; set; }

	public string DoctorCode { get; set; }

	public string CheckProject { get; set; }
	
	public string IS_CONSULTATION { get; set; }

	public string HisPolicyNumber {get;set;}
}