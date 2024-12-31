

using Laboratory.Services.TestCartAPI.Models.Dto;
using Laboratory.Services.TestCartAPI.Service.IService;
using Newtonsoft.Json;

namespace Laboratory.Services.TestCartAPI.Service
{
	public class TestService : ITestService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public TestService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IEnumerable<TestDto>> GetTests()
		{
			var client = _httpClientFactory.CreateClient("Test");
			var response = await client.GetAsync($"/api/Test");
			var apiContet = await response.Content.ReadAsStringAsync();
			var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContet);
			if (resp.IsSuccess)
			{
				return JsonConvert.DeserializeObject<IEnumerable<TestDto>>(Convert.ToString(resp.Result));
			}
			return new List<TestDto>();
		}
	}
}
