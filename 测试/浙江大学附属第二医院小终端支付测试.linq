<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>System.Security.Cryptography</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	//	var dic = new Dictionary<string, string>();
	//	dic.Add("JiGouDM", "330105002000");
	//	dic.Add("JiuZhenKH", "361100D156000005727280839C5A1C10|3|727280832|362323197705052115|许信秧                        |1|||||339900905363|");
	//	dic.Add("BingRenXM", "许信秧");
	//	dic.Add("MenZhenZYBZ", "2");
	//	dic.Add("LaiYuan", "1");
	//	dic.Add("LiuShuiHao", "34609820240619073528");
	//	dic.Add("JinE", "5000");
	//	dic.Add("BiaoTi", "住院充值");
	//	dic.Add("MiaoShu", "我是描述");
	//	dic.Add("BeiZhu", "");
	//	dic.Add("HuiDiaoDZ", "");
	//	dic.Add("CaoZuoYH", "KLE098");
	//	dic.Add("TimeOut", "");
	//	dic.Add("JiaoYilX", "0");
	//	dic.Add("FuFeiQD", "1");
	//
	//	var str=AsciiDicToStr(dic);
	//	str+="&timestamp=2024-06-19 07:35:28&client_secret=38rue6wjd75klt732hq18i4j0w6xgd8w";

//var result=GetMD5Hash(str);
	//64dde68de8b71cb396a6d4daab400b30
	//64dde68de8b71cb396a6d4daab400b30

	var dataObj = new REQ_LZPreOrder 
	{
		JiGouDM="330105002000",
		JiuZhenKH="361100D156000005727280839C5A1C10|3|727280832|362323197705052115|许信秧                        |1|||||339900905363|",
		BingRenXM="许信秧",
		MenZhenZYBZ="2",
		LaiYuan="1",
		LiuShuiHao="34609820240619073528",
		JinE="5000",
		BiaoTi="住院充值",
		MiaoShu="我是描述",
		BeiZhu="",
		HuiDiaoDZ="",
		CaoZuoYH="KLE098",
		TimeOut="",
		JiaoYilX="0",
		FuFeiQD="1"
	};

	var dic = new Dictionary<string, string>();
	var type = dataObj.GetType();
	foreach (var property in type.GetProperties())
	{
		dic.Add(property.Name, property.GetValue(dataObj).ToString());
	}
	
	var str="BeiZhu=&BiaoTi=住院充值&BingRenXM=孙国冲&CaoZuoYH=KLE098&FuFeiQD=1&HuiDiaoDZ=&JiGouDM=330105002000&JiaoYilX=0&JinE=0.01&JiuZhenKH=330102196106041815&LaiYuan=1&LiuShuiHao=7PTest_2024062115423435&MenZhenZYBZ=2&MiaoShu=我是描述&TimeOut=&timestamp=2024-06-21 15:42:34&client_secret=38rue6wjd75klt732hq18i4j0w6xgd8w";


	GetMD5Hash(str).Dump();
}

public static string GetMD5Hash(string input)
{
	// 创建一个MD5对象
	using (MD5 md5 = MD5.Create())
	{
		// 将输入字符串转换为字节数组
		byte[] inputBytes = Encoding.UTF8.GetBytes(input);
		// 计算输入字节数组的哈希值
		byte[] hashBytes = md5.ComputeHash(inputBytes);
		// 将字节数组转换为字符串
		StringBuilder hashString = new StringBuilder();
		foreach (byte b in hashBytes)
		{
			hashString.AppendFormat("{0:x2}", b);
		}
		return hashString.ToString();
	}
}

/// <summary>
/// 联众预下单入参
/// </summary>
public class REQ_LZPreOrder
{
	/// <summary>
	/// 机构代码
	/// </summary>
	public string JiGouDM { get; set; }
	/// <summary>
	/// 就诊卡号
	/// </summary>
	public string JiuZhenKH { get; set; }
	/// <summary>
	/// 病人姓名
	/// </summary>
	public string BingRenXM { get; set; }
	/// <summary>
	/// 门诊住院标志 1门诊  2住院
	/// </summary>
	public string MenZhenZYBZ { get; set; }
	/// <summary>
	/// 支付渠道  1微信  2支付宝
	/// </summary>
	public string LaiYuan { get; set; }
	/// <summary>
	/// 流水号
	/// </summary>
	public string LiuShuiHao { get; set; }
	/// <summary>
	/// 金额（单位：元）
	/// </summary>
	public string JinE { get; set; }
	/// <summary>
	/// 商品名称
	/// </summary>
	public string BiaoTi { get; set; }
	/// <summary>
	/// 商品描述
	/// </summary>
	public string MiaoShu { get; set; }
	/// <summary>
	/// 备注
	/// </summary>
	public string BeiZhu { get; set; }
	/// <summary>
	/// 支付成功后的异步回调地址
	/// </summary>
	public string HuiDiaoDZ { get; set; }
	/// <summary>
	/// 操作员号
	/// </summary>
	public string CaoZuoYH { get; set; }
	/// <summary>
	/// 有效分钟数，默认5分钟。即5分钟内可以进行支付，超过5分钟订单自动关闭
	/// </summary>
	public string TimeOut { get; set; }
	/// <summary>
	/// 先固定传0
	/// </summary>
	public string JiaoYilX { get; set; }
	/// <summary>
	/// 1自助  2窗口
	/// </summary>
	public string FuFeiQD { get; set; }
}

