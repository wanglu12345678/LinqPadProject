<Query Kind="Program">
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	object data=null;
	using (var httpClient = new HttpClient())
	{
		using (var request = new HttpRequestMessage { RequestUri = new Uri("https://mongoliamedical.clearofservice.com/Query/MedicalProList"),Method=HttpMethod.Post})
		{
			HttpResponseMessage response = new HttpResponseMessage();
			//request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
			response = await httpClient.SendAsync(request);
			var result=await response.Content.ReadAsStringAsync();
			Console.WriteLine(result);
		}
	}
}

