<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	var queueList = new string[] { "P", "F", "P", "P", "J", "P", "F", "J", "J", "P", "F", "J", "F", "J", "C" };

	// 急诊的测试数据 QueueNameId 695   EmployeeId 700   RoomId 184   DoctorCode jz_2005
	var data = new GeneralPlusQueueInputDto
	{
		HisKey="202312221118001",
		CardNo="123123",
		Age="24",
		Phone="15923562547",
		Sex="男",
		blh="",
		patid="",
		hiskey="202312221118001",
		StartTime=DateTime.Now.AddMinutes(-5).ToString("yyyy-MM-dd HH:mm:ss"),
		EndTime = DateTime.Now.AddMinutes(5).ToString("yyyy-MM-dd HH:mm:ss"),
		DepartCode = "2005",
		DoctorCode = "1545",
		ISEMREGENCY="1",
		Name="水电费是的"
	};

	var url = "http://localhost:7098/api/services/kiaser/TriageTable/GeneralPlusQueue";
	using (var httpClient = new HttpClient())
	{
		var result = await httpClient.PostAsync(url,new System.Net.Http.StringContent(JsonConvert.SerializeObject(data),Encoding.UTF8,"application/json"));
		var str = await result.Content.ReadAsStringAsync();

		Console.WriteLine($"当前Hiskey{data.hiskey},当前入队结果为：{str}");
	}

	Console.WriteLine("结束");
}

public class GeneralPlusQueueInputDto
{
	public string HisKey { get; set; }
	public string CardNo { get; set; }
	public string Name { get; set; }
	public string Age { get; set; }
	/// <summary>
	/// 医生编码
	/// </summary>
	public string DoctorCode { get; set; }

	public string DepartCode { get; set; }

	/// <summary>
	/// 急诊标识   0 为非急诊   1为急诊
	/// </summary>
	public string ISEMREGENCY { get; set; }

	public string Phone { get; set; }
	public string Sex { get; set; }
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