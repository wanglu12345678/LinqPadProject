<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	
	Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmss"));

	var url="http://localhost:7098/api/services/kiaser/DoctorWorkstationService/SignInByRegisterInfo";
	var registerInfos = GetRegisterInfos();
	foreach (var item in registerInfos)
	{
		if (item.Referral == 1)
		{
			item.HisKey = $"zz{item.HisKey}";
		}

		if (item.ReturnVisit == 1)
		{
			var timeSpan = DateTime.Now.ToString("yyyyMMddHHmmss");
			if (item.ReturnTime != "0001/1/1")
			{
				timeSpan = DateTime.Parse(item.ReturnTime).ToString("yyyyMMddHHmmss");
			}
			item.HisKey = $"fz_{item.HisKey}_{timeSpan}";
		}
		using (var httpClient = new HttpClient())
		{
			var content = JsonConvert.SerializeObject(item);
			var res = httpClient.PostAsync(url, new StringContent(content,Encoding.UTF8,"application/json"));
			var result = res.Result.Content.ReadAsStringAsync().Result;
			Console.WriteLine($"入队结果为：{result}");
		}
	}
}

private List<V_RegistInfoNew> GetRegisterInfos()
{
	return new List<V_RegistInfoNew>
	{
		new V_RegistInfoNew
		{
			HisKey="2024001",
			Name="张三",
			CardNo="123",
			IdNo="451",
			Sex="男",
			Age="30",
			Tel="15978525412",
			RegistDate=DateTime.Now,
			DeptCode="013229",
			DeptName="出生缺陷防治与产前诊断科门诊(番禺)",
			DoctorCode="0324",
			DoctorName="吕莉娟",
			CreateTime=DateTime.Now.ToString("yyyy-MM-dd"),
			DateSlot="下午",
			TimeSpan="12",
			State="1",
			Number="0",
			ViewQueue="1",
			LateFlag=0,
			QueueType="03",
			RegisterClass=0,
			ReportTime=DateTime.Now,
			ReturnVisit=1,
			ReturnTime="2024-03-19 14:21",
			Referral=0
		}
	};
}

/// <summary>
/// 
/// </summary>
public class V_RegistInfoNew
{
	/// <summary>
	/// 唯一流水号
	/// </summary>
	public string HisKey { get; set; }
	/// <summary>
	/// 姓名
	/// </summary>
	public string Name { get; set; }
	/// <summary>
	/// 卡号
	/// </summary>
	public string CardNo { get; set; }
	/// <summary>
	/// 身份证号码
	/// </summary>
	public string IdNo { get; set; }
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
	public string Tel { get; set; }
	/// <summary>
	/// 挂号时间，格式：2018-08-11 23:59:59
	/// </summary>
	public DateTime RegistDate { get; set; }
	/// <summary>
	/// 挂号科室编码
	/// </summary>
	public string DeptCode { get; set; }
	/// <summary>
	/// 挂号科室名称
	/// </summary>
	public string DeptName { get; set; }
	/// <summary>
	/// 挂号医生工号
	/// </summary>
	public string DoctorCode { get; set; }
	/// <summary>
	/// 挂号医生姓名
	/// </summary>
	public string DoctorName { get; set; }
	/// <summary>
	/// 挂号时间
	/// </summary>
	public string CreateTime { get; set; }
	/// <summary>
	/// 挂号的午别
	/// </summary>
	public string DateSlot { get; set; }
	/// <summary>
	/// 挂号时间段
	/// </summary>
	public string TimeSpan { get; set; }
	/// <summary>
	/// 状态 1:未就诊 2:已就诊 3:退号 4:作废
	/// </summary>
	public string State { get; set; }
	/// <summary>
	/// 序号 his提供排队序号 没有就传0
	/// </summary>
	public string Number { get; set; }
	/// <summary>
	/// 就诊序号，一般和排队序号一致，迟到后会不一致
	/// </summary>
	public string ViewQueue { get; set; }
	/// <summary>
	/// 迟到标识，1为迟到，0为未迟到
	/// </summary>
	public int LateFlag { get; set; } = 0;
	/// <summary>
	/// 队列类型：（ 01：急诊 02：预约 03：普通 ）,后续有其他类型需求可以再加
	/// </summary>
	public string QueueType { get; set; }
	/// <summary>
	/// QueueType为急诊类型的时候, 序号：1，2，3，4
	/// </summary>
	public string QueueTypeNumber { get; set; }
	/// <summary>
	/// 号别名称  比如 急诊
	/// </summary>
	public string QueueName { get; set; }
	/// <summary>
	/// 号别代码  急诊的编码为5
	/// </summary>
	public string QueueNameCode { get; set; }
	/// <summary>
	/// 挂号类型 0现场挂号  1预约挂号
	/// </summary>
	public int RegisterClass { get; set; }
	/// <summary>
	/// 
	/// </summary>
	public DateTime? ReportTime { get; set; }

	/// <summary>
	/// 是否为回诊，1为回诊
	/// </summary>
	public int ReturnVisit { get; set; }

	/// <summary>
	/// 回诊时间
	/// </summary>
	public string ReturnTime { get; set; }

	/// <summary>
	/// 是否为转诊，0为否，1为是，
	/// </summary>
	public int Referral { get; set; }

	/// <summary>
	/// 展示给医生站显示的号别
	/// </summary>
	public string QueueLevelName { get; set; }

	/// <summary>
	/// 号序标识  (迟)   (过)
	/// </summary>
	public string Prompt { get; set; }
}