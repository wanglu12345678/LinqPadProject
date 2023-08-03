<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>System.Text.Json</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	//var txt=File.ReadAllText(@"D:\Mine\LinqPadProject\Json\1.txt");
	//Console.WriteLine(txt);
	//
	//var obj=JsonConvert.DeserializeObject<CommonResponse<List<RESP_Reproduction>>>(txt);
	//
	//obj.Dump();
	
	var str1="12312312312312";
	Console.WriteLine(str1.Substring(0,6));
	str1.Dump();
	
}

public class CommonResponse<T> where T : class, new()
{
	/// <summary>
	/// 状态码，200-成功 500-错误
	/// </summary>
	[JsonProperty("code")]
	public string Code { get; set; }

	/// <summary>
	/// 描述信息
	/// </summary>
	[JsonProperty("message")]
	public string Message { get; set; }

	/// <summary>
	/// 返回内容
	/// </summary>
	[JsonProperty("content")]
	public T Data { get; set; }
}

/// <summary>
/// 生殖科接口出参
/// </summary>
public class RESP_Reproduction
{
	/// <summary>
	/// 流水号
	/// </summary>
	public string hiskey { get; set; }
	/// <summary>
	/// 姓名
	/// </summary>
	public string name { get; set; }
	/// <summary>
	/// 门诊卡号
	/// </summary>
	public string card_no { get; set; }
	/// <summary>
	/// 身份证号
	/// </summary>
	public string idno { get; set; }
	/// <summary>
	/// 性别
	/// </summary>
	public string sex { get; set; }
	/// <summary>
	/// 年龄
	/// </summary>
	public string age { get; set; }
	/// <summary>
	/// 手机号
	/// </summary>
	public string phone { get; set; }
	/// <summary>
	/// 就诊时间
	/// </summary>
	public DateTime? registdate { get; set; }
	/// <summary>
	/// 挂号医生工号
	/// </summary>
	public string doctorcode { get; set; }
	/// <summary>
	/// 挂号医生姓名
	/// </summary>
	public string doctorname { get; set; }
	/// <summary>
	/// 挂号科室编码
	/// </summary>
	public string departcode { get; set; }
	/// <summary>
	/// 挂号科室名称
	/// </summary>
	public string departname { get; set; }
	/// <summary>
	/// 挂号时间
	/// </summary>
	public DateTime? createtime { get; set; }
	/// <summary>
	/// 午别
	/// </summary>
	public string dateslot { get; set; }
	/// <summary>
	/// 时间段
	/// </summary>
	public string timespan { get; set; }
	/// <summary>
	/// 就诊状态
	/// </summary>
	public string state { get; set; }
	/// <summary>
	/// 序号
	/// </summary>
	public string number { get; set; }
	/// <summary>
	/// 队列类型
	/// </summary>
	public string queuetype { get; set; }
	/// <summary>
	/// 队列号
	/// </summary>
	public string queuenamecode { get; set; }
	/// <summary>
	/// 队列名称
	/// </summary>
	public string queuename { get; set; }
}