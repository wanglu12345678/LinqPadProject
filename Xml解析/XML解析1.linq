<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>System.Xml.Serialization</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	var txt= System.IO.File.ReadAllText("D:/Mine/LinqPadProject/Xml解析/1.txt");
	
	txt=JsonConvert.DeserializeObject<string>(txt);
	
	var obj=GetHis<CommonWSResponse<RESP_WSPatientInfo>>(txt);
	
	Console.WriteLine(obj);
	
	Console.WriteLine(obj.result[0]);
}

private T GetHis<T>(string txt)  where T : class, new()
{
	return XmlHelper.XmlDeserialize<T>(txt);
}

[XmlRoot("response")]
public class CommonWSResponse<T>
{
	/// <summary>
	/// 
	/// </summary>
	[XmlElement("resultCode")]
	public string resultCode { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[XmlElement("resultMessage")]
	public string resultMessage { get; set; }

	[XmlArray("result")]
	[XmlArrayItem("item")]
	public List<T> result { get; set; }
}

public class RESP_WSPatientInfo
    {
        public string brzt { get; set; }
        public string patid { get; set; }
        public string cardno { get; set; }
        public string cardtype { get; set; }
        public string pzlx { get; set; }
        public string hzxm { get; set; }
        public string ybdm { get; set; }
        public string sex { get; set; }
        public string sfzh { get; set; }
        public string lxdz { get; set; }
        public string ghbz { get; set; }
        public string lxdh { get; set; }
        public string blh { get; set; }
        public string birth { get; set; }
        public string zhye { get; set; }
        public string ybsm { get; set; }
        public string zhbz { get; set; }
        public string lrrq { get; set; }
        public string gsbz { get; set; }
        public string djrq { get; set; }
        public string ispwd { get; set; }
	public string zjlx { get; set; }
}