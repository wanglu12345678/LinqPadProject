<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	var doctorTimeInfo=File.ReadAllText(@"D:\Mine\LinqPadProject\坪山社康号源Group测试\1.txt");

	var obj=JsonConvert.DeserializeObject<CommonResponse<List<RESP_DoctorTimeInfo>>>(doctorTimeInfo);
	
	var mbDept=obj.Data.Where(x=>x.ksdm=="3284" && x.date=="2024-08-30").OrderBy(x=>x.zblb.Split('-')[0]).ToList();

	var ss = mbDept.GroupBy(x => new { x.ysdm });
	
	ss.Dump();

	//var qcx = obj.GroupBy(x => new { x.ksdm, x.gzrq, x.zblb, x.tgbz }).Select(d => d.FirstOrDefault()).ToList();
	//var CheckDeptTime = qcx.Where(x => x.ksdm == "3284" && x.gzrq == "2024-08-30").ToList();
	//
	//CheckDeptTime.Dump();
}

public class CommonResponse<T>
{
	[JsonProperty("code")]
	public string Code { get; set; }

	[JsonProperty("message")]
	public string Message { get; set; }

	[JsonProperty("data")]
	public T Data { get; set; }
}

public class RESP_DoctorTimeInfo : RESP_DoctorTimeInfoBase
{
	/// <summary>
	/// 开始时间
	/// </summary>
	public string start_Time { set; get; }
	/// <summary>
	/// 结束时间
	/// </summary>
	public string end_Time { set; get; }
	/// <summary>
	/// 机构ID
	/// </summary>
	public string jgid { get; set; }
	/// <summary>
	/// 科室ID
	/// </summary>
	public string ksdm { get; set; }
	/// <summary>
	/// 科室名称
	/// </summary>
	public string ksmc { get; set; }
	/// <summary>
	/// 医生ID
	/// </summary>
	public string ysdm { get; set; }
	/// <summary>
	/// 医生是否有排班
	/// </summary>
	public string yspb { get; set; }
	/// <summary>
	/// 值班类别(1:上午,2:下午) ,(具体时间段)
	/// </summary>
	public string zblb { get; set; }
}

/// <summary>
/// 获取医生排班分时
/// </summary>
public  class RESP_DoctorTimeInfoBase
    {
        /// <summary>
        /// 日期 yyyy-MM-dd
        /// </summary>
        public string date { get; set; }
        public string dateInt { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string start_time { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string end_time { get; set; }
        /// <summary>
        /// 排班标识号
        /// </summary>
        public string pb_flag { get; set; }
        /// <summary>
        /// 余号
        /// </summary>
        public string surplus { get; set; }
        /// <summary>
        /// 医师名称
        /// </summary>
        public string doc_name { get; set; }
        /// <summary>
        /// 号源编号
        /// </summary>
        public string reg_id { get; set; }
	/// <summary>
	/// 性别
	/// </summary>
	public string sex_code { get; set; }
	/// <summary>
	/// 扩展
	/// </summary>
	public string ext { get; set; }

}