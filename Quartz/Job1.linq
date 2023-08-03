<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <NuGetReference Version="3.6.1">Quartz</NuGetReference>
  <NuGetReference>Topshelf</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Quartz</Namespace>
  <Namespace>Quartz.Impl</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Topshelf</Namespace>
</Query>

void Main()
{
//	// 创建入队服务
//	HostFactory.Run(x => 
//	{
//		x.RunAsLocalSystem();
//		x.SetServiceName("TestService");
//		x.SetDescription("测试服务");
//		x.StartAutomatically();
//		x.EnableShutdown();
//		
//		x.Service(t => new TestService());
//
//		x.EnableServiceRecovery(t => 
//		{
//			t.RestartService(0);
//			t.RestartService(0);
//			t.RestartService(0);
//			t.OnCrashOnly();
//		});
//	});
	
	SchedulerHelper.StartQuartz();
}

public class TestService : ServiceControl
{
	public bool Start(HostControl hostControl)
	{
		SchedulerHelper.StartQuartz();
		return true;
	}

	public bool Stop(HostControl hostControl)
	{
		SchedulerHelper.StopQuartz();
		return true;
	}
}


public class SchedulerHelper
{
	/// <summary>
	/// 
	/// </summary>
	public static IScheduler scheduler;

	public static void StartQuartz()
	{
		scheduler = StdSchedulerFactory.GetDefaultScheduler().Result;
		BuilderJob();
		scheduler.Start();
	}

	/// <summary>
	/// 
	/// </summary>
	public static void StopQuartz()
	{
		scheduler.Clear();
	}

	/// <summary>
	/// 
	/// </summary>
	private static void BuilderJob()
	{
		try
		{
			scheduler.ExecuteByCron<Job1>("0/20 * * * * ? ");
			
			scheduler.ExecuteByCron<Job2>("0/20 * * * * ? ");
			scheduler.ExecuteByCron<Job2>("0/20 * * * * ? ");
		}
		catch (Exception ex)
		{
			
		}
	}
}

public class Job1 : IJob
{
 	private string Url="http://localhost:7098/api/services/kiaser/DoctorWorkstationService/SignInByRegisterInfo";

	public async Task Execute(IJobExecutionContext context)
	{
		var data = new
		{
			hisKey = "20230407001",
			name = "测试人员",
			cardNo = "2023001",
			idNo = "",
			sex = "1",
			age = "21",
			tel = "13724217957",
			registDate = "2023-04-07T02:34:15.172Z",
			deptCode = "014024",
			deptName = "耳鼻咽喉科护理单元(番禺)",
			doctorCode = "9979",
			doctorName = "冯伟杰",
			createTime = "2023-04-07 10：40",
			dateSlot = "1",
			timeSpan = "",
			state = "0",
			number = "1",
			viewQueue = "1",
			lateFlag = 0,
			queueType = "",
			queueTypeNumber = "",
			queueName = "",
			queueNameCode = "",
			registerClass = 0,
			reportTime = "2023-04-07T02:34:15.172Z",
			returnVisit = 0,
			returnTime = "2023-04-07T02:34:15.172Z",
			referral = 0,
			queueLevelName = "string",
			prompt = "string"
		};
		using (var httpClient = new HttpClient())
		{
			var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
			var result = await httpClient.PostAsync(Url, content);
			Console.WriteLine(result);
		}
	}
}

public class Job2 : IJob
{
	private string Url = "http://localhost:7098/api/services/kiaser/DoctorWorkstationService/SignInByReproductionInfo";
	public async Task Execute(IJobExecutionContext context)
	{
		var data = new {
			hiskey= 261634,
            name= "刘燕",
            card_no= "2001613656",
            idno= "",
            sex= "",
            age= "",
            phone= "",
            registdate= "",
            doctorcode= "ZQZYH",
            doctorname= "周期专用号",
            departcode= "002",
            departname= "生殖科5楼",
            createtime= "2023-02-21 07:52:00",
            dateslot= "上午",
            timespan= "",
            state= "1",
            number= "6002",
            queuetype= "03",
            queuenamecode= 65,
            queuename= "周期专用号"
		};

		using (var httpClient = new HttpClient())
		{
			var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
			var result = await httpClient.PostAsync(Url, content);
			Console.WriteLine(result);
		}
	}
}

public static class ExtensionHelper
{
	/// <summary>
	/// 指定时间执行任务
	/// </summary>
	/// <typeparam name="T">任务类，必须实现IJob接口</typeparam>
	/// <param name="cronExpression">cron表达式，即指定时间点的表达式</param>
	public static void ExecuteByCron<T>(this IScheduler scheduler, string cronExpression) where T : IJob
	{
		//ISchedulerFactory factory = new StdSchedulerFactory();
		//IScheduler scheduler = factory.GetScheduler();

		IJobDetail job = JobBuilder.Create<T>().Build();

		ICronTrigger trigger = (ICronTrigger)TriggerBuilder.Create()
			//.StartAt(startTime).EndAt(endTime)
			.WithCronSchedule(cronExpression)
			.Build();

		scheduler.ScheduleJob(job, trigger);

		//scheduler.Start();
	}
}













