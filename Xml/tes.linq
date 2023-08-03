<Query Kind="Program">
  <Namespace>System.Xml.Serialization</Namespace>
</Query>

void Main()
{
	var filePath=@"D:\Mine\LinqPadProject\Xml\1.xml";
	var txt=File.ReadAllText(filePath);
	Console.WriteLine(txt);
	
	
	var result = XmlHelper.XmlDeserialize<PayPreSettlementApiResponse>(txt).Dump();
	
	XmlHelper.XmlSerialize(result,Encoding.UTF8).Dump();
}

/// <summary>
/// 
/// </summary>
[XmlRoot("Response")]
public class PayPreSettlementApiResponse : CommonYbResponse
{
	/// <summary>
	/// 总金额 
	/// </summary>
	[XmlElement("MZJE")]
	public decimal MZJE { get; set; }

	/// <summary>
	/// 统筹金额（报销金额）
	/// </summary>
	[XmlElement("MTCZF")]
	public decimal MTCZF { get; set; }

	/// <summary>
	/// 医保账户支付金额
	/// </summary>
	[XmlElement("MZHZF")]
	public decimal MZHZF { get; set; }

	/// <summary>
	/// 自费金额
	/// </summary>
	[XmlElement("MXJZF")]
	public decimal MXJZF { get; set; }

	[XmlElement("MZHYE")]
	public decimal MZHYE { get; set; }

	[XmlElement("MYYCD")]
	public decimal MYYCD { get; set; }
}

public class CommonYbResponse
{
	/// <summary>
	/// 编码
	/// </summary>
	[XmlElement("ResultCode")]
	public int Code { get; set; }

	/// <summary>
	/// 提示信息
	/// </summary>
	[XmlElement("ResultMsg")]
	public string Message { get; set; }
}