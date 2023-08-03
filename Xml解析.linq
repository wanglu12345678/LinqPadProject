<Query Kind="Program">
  <Namespace>System.Xml.Serialization</Namespace>
  <Namespace>System.Web</Namespace>
</Query>

void Main()
{
	var str = "<?xml version=\"1.0\" encoding=\"utf-8\"?><string xmlns=\"http://tempuri.org/\" >";

	var str1 = @"<pdjh><result>0</result><errmsg>签到成功</errmsg><records><custno>0014624673</custno><brxm>李久森</brxm><ksmc>眼科门诊</ksmc><cliniccode>五楼东区</cliniccode><groupname>吴旭昇</groupname><ghxh>5</ghxh></records></pdjh></string>";
		

	XmlDocument xml = new XmlDocument();
	xml.LoadXml(str + str1);
	xml.DocumentElement.RemoveAllAttributes();
	var xmlStr = xml.DocumentElement.InnerXml;

	Console.WriteLine(DeSerializer<GHXXRegistInfoResponse>(xmlStr));
}

/// <summary>
/// 将xml字符串序列化为实体类
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="strXML"></param>
/// <returns></returns>
public T DeSerializer<T>(string strXML) where T : CommonResponse
{
	try
	{
		using (StringReader sr = new StringReader(strXML))
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			return serializer.Deserialize(sr) as T;
		}
	}
	catch (Exception ex)
	{
		throw new Exception("将XML转换成实体对象异常", ex);
	}
}

[XmlRoot(Namespace = "http://tempuri.org/", IsNullable = true, ElementName = "pdjh")]
public class CommonSignResponse
{
	/// <summary>
	/// 编码
	/// </summary>
	[XmlElement("result")]
	public int code { get; set; }

	/// <summary>
	/// 提示信息
	/// </summary>
	[XmlElement("errmsg")]
	public string message { get; set; }
}

[XmlRoot(Namespace = "http://tempuri.org/", IsNullable = true, ElementName = "pdjh")]
public class RES_SignIn : CommonSignResponse
{
	//        [XmlArray("list")]
	//        [XmlArrayItem("item")]
	//        public List<GHXXRegistInfoResponseItem> Datas { get; set; }
	//
	//        public GHXXRegistInfoResponse()
	//        {
	//            Datas = new List<GHXXRegistInfoResponseItem>();
	//        }
	/// <summary>
	/// 挂号信息
	/// </summary>
	[XmlElement("records")]
	public SignInResponse data { get; set; }
}

/// <summary>
/// 签到消息
/// </summary>
public class SignInResponse
{
	/// <summary>
	/// 诊疗号
	/// </summary>
	[XmlElement("custno")]
	public string custno { get; set; }

	/// <summary>
	/// 患者姓名
	/// </summary>
	[XmlElement("brxm")]
	public string brxm { get; set; }

	/// <summary>
	/// 科室名称
	/// </summary>
	[XmlElement("ksmc")]
	public string ksmc { get; set; }

	/// <summary>
	/// 科室位置
	/// </summary>
	[XmlElement("cliniccode")]
	public string cliniccode { get; set; }

	/// <summary>
	/// 队列名称
	/// </summary>
	[XmlElement("groupname")]
	public string groupname { get; set; }

	/// <summary>
	/// 预约序号
	/// </summary>
	[XmlElement("ghxh")]
	public string ghxh { get; set; }
}

[XmlRoot(Namespace = "http://tempuri.org/", IsNullable = true, ElementName = "pdjh")]
public class CommonResponse
{
	/// <summary>
	/// 编码
	/// </summary>
	[XmlElement("result")]
	public int Code { get; set; }

	/// <summary>
	/// 提示信息
	/// </summary>
	[XmlElement("errmsg")]
	public string Message { get; set; }
}

[XmlRoot(Namespace = "http://tempuri.org/", IsNullable = true, ElementName = "pdjh")]
    public class GHXXRegistInfoResponse : CommonResponse
    {
//        [XmlArray("list")]
//        [XmlArrayItem("item")]
//        public List<GHXXRegistInfoResponseItem> Datas { get; set; }
//
//        public GHXXRegistInfoResponse()
//        {
//            Datas = new List<GHXXRegistInfoResponseItem>();
//        }
		[XmlElement("records")]
		public GHXXRegistInfoResponseItem records{get;set;}
    }

/// <summary>
/// 
/// </summary>
public class GHXXRegistInfoResponseItem
{
	/// <summary>
	/// 唯一流水号 门诊号
	/// </summary>
	[XmlElement("ksdm")]
	public string ksdm { get; set; }

	/// <summary>
	/// 患者卡号
	/// </summary>
	[XmlElement("ksmc")]
	public string ksmc { get; set; }

	/// <summary>
	/// 姓名
	/// </summary>
	[XmlElement("ysgh")]
	public string ysgh { get; set; }
}

///// <summary>
///// 
///// </summary>
//[XmlRoot("item")]
//public class GHXXRegistInfoResponseItem
//{
//	/// <summary>
//	/// 唯一流水号 门诊号
//	/// </summary>
//        [XmlElement("regiNumber")]
//        public string HisKey { get; set; }
//
//		/// <summary>
//		/// 患者卡号
//		/// </summary>
//		[XmlElement("patiID")]
//		public string PatiID { get; set; }
//
//		/// <summary>
//		/// 姓名
//		/// </summary>
//		[XmlElement("patiName")]
//		public string Name { get; set; }
//
//		/// <summary>
//		/// 条码号
//		/// </summary>
//		[XmlElement("barCode")]
//		public string BarCode { get; set; }
//
//		/// <summary>
//		///     身份证号码
//		/// </summary>
//		[XmlElement("idCard")]
//		public string IdNo { get; set; }
//
//		/// <summary>
//		///     性别
//		/// </summary>
//		[XmlElement("sex")]
//		public string Sex { get; set; }
//
//		/// <summary>
//		///     年龄
//		/// </summary>
//		[XmlElement("age")]
//		public string Age { get; set; }
//
//		/// <summary>
//		///     手机号
//		/// </summary>
//		[XmlElement("tel")]
//		public string Phone { get; set; }
//
//		/// <summary>
//		/// 挂号的科室ID
//		/// </summary>
//		[XmlElement("deptID")]
//		public int DeptID { get; set; }
//
//		/// <summary>
//		/// 挂号科室
//		/// </summary>
//		[XmlElement("deptName")]
//		public string DeptName { get; set; }
//
//		/// <summary>
//		/// 挂号医生标识
//		/// </summary>
//		[XmlElement("doctorID")]
//		public int EmployeeId { get; set; }
//
//		/// <summary>
//		/// 挂号医生
//		/// </summary>
//		[XmlElement("doctorName")]
//		public string EmployeeName { get; set; }
//
//		/// <summary>
//		/// 排队时间
//		/// </summary>
//		[XmlElement("createTime")]
//		public string CreateTime { get; set; }
//
//		/// <summary>
//		/// 
//		/// </summary>
//		[XmlElement("ampm")]
//		public string Ampm { get; set; }
//
//		/// <summary>
//		/// 
//		/// </summary>
//		[XmlElement("timeSpan")]
//		public string TimeSpan { get; set; }
//
//		/// <summary>
//		/// 状态
//		/// </summary>
//		[XmlElement("state")]
//		public string State { get; set; }
//
//		/// <summary>
//		/// 类别
//		/// </summary>
//		[XmlElement("type")]
//		public string Type { get; set; }
//
//		/// <summary>
//		/// 排队序号
//		/// </summary>
//		[XmlElement("queueCode")]
//		public string QueueCode { get; set; }
//
//		/// <summary>
//		/// 队列类型
//		/// </summary>
//		[XmlElement("queueType")]
//		public string QueueType { get; set; }
//
//		/// <summary>
//		/// 序号
//		/// </summary>
//		[XmlElement("queueNum")]
//		public string QueueNum { get; set; }
//
//		/// <summary>
//		/// 时段的开始时间
//		/// </summary>
//		[XmlElement("startTime")]
//		public string StartTime { get; set; }
//
//		/// <summary>
//		/// 时段的结束时间
//		/// </summary>
//		[XmlElement("endTime")]
//		public string EndTime { get; set; }
//
//		/// <summary>
//		/// 号别类型
//		/// </summary>
//		[XmlElement("regiTypeCode")]
//		public string RegiTypeCode { get; set; }
//
//		/// <summary>
//		/// his号别名称
//		/// </summary>
//		[XmlElement("regiTypeName")]
//		public string RegiTypeName { get; set; }
//
//		/// <summary>
//		/// 是否为加号 1是  0否
//		/// </summary>
//		[XmlElement("isAdd")]
//		public int IsAdd { get; set; }
//
//		/// <summary>
//		/// 时间段  3上午   4下午
//		/// </summary>
//		[XmlElement("regTime")]
//		public int RegTime { get; set; }
//	}