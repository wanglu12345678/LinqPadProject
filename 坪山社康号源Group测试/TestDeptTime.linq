<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>System.Text.Json</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	var doctorTimeInfo = File.ReadAllText(@"D:\Mine\LinqPadProject\坪山社康号源Group测试\2.txt");

	var obj = JsonConvert.DeserializeObject<CommonResponse<List<RESP_DoctorTimeInfo>>>(doctorTimeInfo);

	var mbDept = obj.Data.Where(x => x.ksdm == "3284" && x.gzrq == "2024-08-30").OrderBy(x => x.zblb.Split('-')[0]).ToList();

	//var ss = mbDept.GroupBy(x => new { x.ysdm });

	mbDept.Dump();

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
        /// 每天是当周第几天,周日为第1天
        /// </summary>
        public string ghrq { get; set; }
        /// <summary>
        /// 挂号限额,0为不限额
        /// </summary>
        public string ghxe { get; set; }
        /// <summary>
        /// 挂号日期
        /// </summary>
        public string gzrq { get; set; }
        /// <summary>
        /// 社康ID
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
        /// 诊室名称
        /// </summary>
        public string mzmc { get; set; }
        /// <summary>
        /// 停挂标志,0为不停止挂号
        /// </summary>
        public string tgbz { get; set; }
        /// <summary>
        /// 停止挂号文本
        /// </summary>
        public string tgbz_text { get; set; }
        /// <summary>
        /// 已挂人数
        /// </summary>
        public string ygrs { get; set; }
        /// <summary>
        /// 预约人数
        /// </summary>
        public string yyrs { get; set; }
        /// <summary>
        /// 预约限额,0为不限额
        /// </summary>
        public string yyxe { get; set; }
        /// <summary>
        /// 值班类别(1:上午,2:下午) ,(具体时间段)
        /// </summary>
        public string zblb { get; set; }
        /// <summary>
        /// 值班类别文本
        /// </summary>
        public string zblb_text { get; set; }
}

/// <summary>
/// 获取医生排班分时
/// </summary>
public class RESP_DoctorTimeInfoBase
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