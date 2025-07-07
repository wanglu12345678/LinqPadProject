<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

async Task Main()
{
	var names = new string[] { "德玛西亚","李四","王五","水电费","大哥发的","电饭锅","第三方","v我饿v我","支持支持","asda","萨达","xcvx","是不额外","胜多负少","rnrt","当前温度" };
	var index=1;
	foreach (var name in names)
	{
		if (index <10)
		{
			await ToCreateQueue(index+345435, name);
			Thread.Sleep(300);
		}
		index++;
	}
}

public async Task ToCreateQueue(int index, string name)
{
	// 急诊的测试数据 QueueNameId 695   EmployeeId 700   RoomId 184   DoctorCode jz_2005
	var dataObj = new CreateQueueByMedicalTechnologyInputDto
	{
		Cdkey = "eac85089-c129-433a-b581-89088e4df3c5",
		CardNo = "123",
		CardType = "1",
		HisKey = index.ToString(), //"6",
		Name = name, //"阿阿斯顿",
		Age = "20",
		BusinessType = "7",
		BusinessCategory = "MR检查",
		RoomHisCode = "",
		QueueType = "02",
		Sex = "1",
		TimeSpan = "13:30-14:30",
		Number=""
	};

	var url = "http://localhost:7098/api/services/kiaser/TriageTable/CreateQueueByMedicalTechnology";
	using (var httpClient = new HttpClient())
	{
		var data = new StringContent(JsonConvert.SerializeObject(dataObj), Encoding.UTF8, "application/json");
		var result = await httpClient.PostAsync(url, data);
		var str = await result.Content.ReadAsStringAsync();

		Console.WriteLine($"当前Hiskey{dataObj.HisKey},当前入队结果为：{str}");
	}

	Console.WriteLine("结束");
}

public class CreateQueueByMedicalTechnologyInputDto
{
	/// <summary>
	/// 渠道cdkey    会根据场景不同来分配
	/// </summary>
	public string Cdkey { get; set; }

	/// <summary>
	/// his医技预约信息的唯一键
	/// </summary>
	public string HisKey { get; set; }

	/// <summary>
	/// 卡号
	/// </summary>
	public string CardNo { get; set; }

	/// <summary>
	/// 1:卡号 2:身份证号码 3:门诊号
	/// </summary>
	public string CardType { get; set; }

	/// <summary>
	/// 姓名
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// 年龄
	/// </summary>
	public string Age { get; set; }

	/// <summary>
	/// 医技业务类型编码:CT DR 等
	/// </summary>
	public string BusinessType { get; set; }

	/// <summary>
	/// 医技业务下的细分类
	/// </summary>
	public string BusinessCategory { get; set; }


	/// <summary>
	/// 诊室唯一编码
	/// </summary>
	public string RoomHisCode { get; set; }

	/// <summary>
	/// 队列类型：（  01：急诊  02：普通  ）,后续有其他类型需求可以再加
	/// </summary>
	public string QueueType { get; set; }

	/// <summary>
	/// 性别 1男 2女
	/// </summary>
	public string Sex { get; set; }

	/// <summary>
	/// 预约的时间段，是否迟到根据这个字段的结束时间判断
	/// </summary>
	public string TimeSpan { get; set; }
	
	public string Number { get; set; }
}

