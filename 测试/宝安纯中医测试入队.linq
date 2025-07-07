<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

async Task Main()
{
	//var names = new string[] { "张三", "李四", "王五", "水电费", "大哥发的", "电饭锅", "第三方", "阿萨德", "支持支持", "南方姑", "萨达",
	//"北大法宝", "是不额外", "胜多负少", "地区五", "当前温度","而额头","德玛西亚","和规范化","金龟换" };

	var queues = new List<dynamic>
	{
		new { name="张三",number="1" },	
		new { name = "李四", number="1+" },
		new { name = "王五", number="2" },
		new { name = "水电费", number="复1" },
		new { name = "电饭锅", number="2+" }
	};

	var index = 0;
	foreach (var item in queues)
	{
		if (index <= 10)
		{
			await ToCreateQueue(index, item.name,item.number);
			Thread.Sleep(300);
		}
		index++;
	}
}

public async Task ToCreateQueue(int index, string name,string number)
{
	// 如果需要测急诊的，数据为 QueueNameId 695   EmployeeId 700   RoomId 184   DoctorCode jz_2005
	var data = new RESP_RegisterInfo
	{
		HisKey="2024"+index,
		Name=name,
		CardNo="10086",
		IdNo="425625354",
		Sex="男",
		Age="30",
		Phone="15623565478",
		RegistDate="2024-12-16 13:54:08",
		DeptCode="1",
		DeptName="中医科门诊",
		DoctorCode="338",
		DoctorName="ys01",
		CreateTime="2024-12-16 14:00",
		DateSlot="上午",
		TimeSpan="08:00-12:00",
		State="1",
		Number=number,
		QueueType="03",
		QueueTypeNumber="普通",
		QueueNameCode="338",
		IndexNumber=1000+index
	};

	var url = "http://localhost:7098/api/services/kiaser/DoctorWorkstation/SignInByRegisterInfo";
	using (var httpClient = new HttpClient())
	{
		var content = JsonConvert.SerializeObject(data);
		var result = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));
		var str = await result.Result.Content.ReadAsStringAsync();

		Console.WriteLine($"当前Hiskey{data.HisKey},当前入队结果为：{str}");
	}

	Console.WriteLine("结束");
}


public class RESP_RegisterInfo
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
    public string Phone { get; set; }
    /// <summary>
    /// 就诊时间，格式：2018-08-11 23:59:59
    /// </summary>
    public string RegistDate { get; set; }
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
	///  1:未就诊 2:已就诊 3:退号 4:作废
	/// </summary>
	public string State { get; set; }
	/// <summary>
	///  his提供排队序号 没有就传0
	/// </summary>
	public string Number { get; set; }
	/// <summary>
	/// 队列类型：（ 01：急诊 02：预约 03：普通 04：过号05：复诊）,后续有其他类型需求可以再加
	/// </summary>
	public string QueueType { get; set; }
	/// <summary>
	/// 队列类型名称
	/// </summary>
	public string QueueTypeNumber { get; set; }
	/// <summary>
	/// 号别名称
	/// </summary>
	public string QueueName { get; set; }
	/// <summary>
	/// 号别代码
	/// </summary>
	public string QueueNameCode { get; set; }

	/// <summary>
	/// 排序号
	/// </summary>
	public long IndexNumber { get; set; }
}