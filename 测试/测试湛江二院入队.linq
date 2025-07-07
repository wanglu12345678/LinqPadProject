<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

async Task Main()
{
	//Parallel.For(0, 10, async (i) =>
	//{
	//	await StartAsync1();
	//});
	await StartAsync();
}

async Task StartAsync1()
{
	var dataObj = new
	{
		cdkey="80bbb171-f95f-4bbe-8ad7-61ed4b1e8d69",
		HisKey="2024001",
		CardNo="123",
		CardType="2",
		EmployeeId="0836"
	};
	var url = "http://192.168.24.124:7099/api/services/kiaser/TriageTable/CreateQueueByOther";
	using (var httpClient = new HttpClient())
	{
		var data=new StringContent(JsonConvert.SerializeObject(dataObj),Encoding.UTF8,"application/json");
		var result = await httpClient.PostAsync(url,data);
		var str = await result.Content.ReadAsStringAsync();

		Console.WriteLine($"当前Hiskey{dataObj.HisKey},当前入队结果为：{str}");
	}
}

async Task StartAsync()
{
	var queueList = new string[] { "P", "F", "P", "P", "J", "P", "F", "J", "J", "P", "F", "J", "F", "J", "C" };

	// 急诊的测试数据 QueueNameId 695   EmployeeId 700   RoomId 184   DoctorCode jz_2005
	var data = new CreateQueueInputDto
	{
		PatientId = "123",
		Sex = "男",
		Age = 70,
		Phone = "15965425621",
		QueueNameId = 193,
		EmployeeId = 192,
		RoomId = 71,
		CurrentNo = 0,
		blh = "123123",
		patid = "123123",
		StartTime = DateTime.Now.ToString("yyyy-MM-dd"),
		EndTime = DateTime.Now.ToString("yyyy-MM-dd"),
		Name = "结核杆菌",
		PriorityTypeId = 5,
		hiskey = "2024007"
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


	var url = "http://192.168.24.124:7099/api/services/kiaser/TriageTable/CreateQueue" + newStr;
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

	/// <summary>
	/// 就诊开始时间
	/// </summary>
	public string StartTime { get; set; }
	/// <summary>
	/// 就诊结束时间
	/// </summary>
	public string EndTime { get; set; }
}