using Laboratory.Web.Models;
using Laboratory.Web.Service.IService;
using Laboratory.Web.Utility;

namespace Laboratory.Web.Service
{
    public class TestParameterService : ITestParameterService
    {
        private readonly IBaseService _baseService;
        public TestParameterService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateTestParameterAsync(ParameterDto testDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = testDto,
                Url = SD.TestParameterAPIBase + "/api/parameter",
             //   ContentType = SD.ContentType.MultipartFormData
            });
        }
		public async Task<ResponseDto?> UpdateTestParameterAsync(ParameterDto testDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.PUT,
				Data = testDto,
				Url = SD.TestParameterAPIBase + "/api/parameter",
				// ContentType = SD.ContentType.MultipartFormData
			});
		}
		//public async Task<ResponseDto?> UpdateTestsAsync(TestDto testDto)
		//{
		//	return await _baseService.SendAsync(new RequestDto()
		//	{
		//		ApiType = SD.ApiType.PUT,
		//		Data = testDto,
		//		Url = SD.TestAPIBase + "/api/Test",
		//		// ContentType = SD.ContentType.MultipartFormData
		//	});
		//}

		public async Task<ResponseDto?> DeleteTestParameterAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.TestParameterAPIBase + "/api/parameter/" + id
            });
        }

        public async Task<ResponseDto?> GetAllTestParameterAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.TestParameterAPIBase + "/api/parameter"
            });
        }

        public async Task<ResponseDto?> GetTestParameterAsync(string testCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.TestParameterAPIBase + "/api/parameter/GetByCode/" + testCode
            });
        }

        public async Task<ResponseDto?> GetTestParameterByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.TestParameterAPIBase + "/api/parameter/" + id
            });
        }

       
    }
}
