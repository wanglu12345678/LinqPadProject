<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>System.Text.Json</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	var str="{\"code\":0,\"data\":{\"authNo\":\"ano3800446753421772801340000\",\"birthday\":null,\"chnlId\":null,\"ecIndexNo\":\"F9282B6916757627EECDADD5AC551091\",\"ecQrCode\":null,\"ecToken\":\"340000fecc71patvaifa9f420a00007b7247f3\",\"email\":null,\"gender\":null,\"idNo\":\"410182198612166072\",\"idType\":\"01\",\"insuOrg\":\"410199\",\"nationality\":null,\"userName\":\"郭瑞\"},\"message\":\"成功\",\"orgId\":\"H34127100198\"}";
	
	var obj=JsonConvert.DeserializeObject<CommonResponse<RESP_MedicalDecode>>(str);
	Console.WriteLine(obj);
}

public class CommonResponse<T>
{
	[JsonProperty("code")]
	public string Code { get; set; }

	[JsonProperty("message")]
	public string Message { get; set; }

	[JsonProperty("appKey")]
	public string AppKey { get; set; }

	[JsonProperty("data")]
	public T Data { get; set; }

	[JsonProperty("result")]
	public T Result { get; set; }
}

public class RESP_MedicalDecode
{
	public string authNo { get; set; }
	public string birthday { get; set; }
	public string chnlId { get; set; }
	public string ecIndexNo { get; set; }
	public string ecQrCode { get; set; }
	public string ecToken { get; set; }
	public string email { get; set; }
	public string gender { get; set; }
	public string idNo { get; set; }
	public string idType { get; set; }
	public string insuOrg { get; set; }
	public string nationality { get; set; }
	public string userName { get; set; }
}