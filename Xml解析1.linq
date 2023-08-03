<Query Kind="Program">
  <Namespace>System.Xml.Serialization</Namespace>
</Query>

void Main()
{
	var str = @"<Response><Code>0000</Code><Msg>成功</Msg><datas>
<data>
<queue_num>23</queue_num>
<patientstate>初诊</patientstate>
<waitCount>3</waitCount>
</data></datas></Response>";
var signResponse = XmlHelper.XmlDeserialize<RESP_SignIn>(str);
	Console.WriteLine(signResponse);
}

/// <summary>
/// 签到
/// </summary>
[XmlRoot("Response")]
public class RESP_SignIn 
{
	[XmlElement("Code")]
	public string Code { get; set; }

	[XmlElement("Msg")]
	public string Msg { get; set; }

	[XmlArray("datas")]
	[XmlArrayItem("data")]
	public List<QueueData> datas { get; set; }
}

[XmlRoot("data")]
public class QueueData
{
	[XmlElement("queue_num")]
	public string queue_num { get; set; }

	[XmlElement("patientstate")]
	public string patientstate { get; set; }

	[XmlElement("waitCount")]
	public string waitCount { get; set; }
}
