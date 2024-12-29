using Laboratory.Web.Models;
using Laboratory.Web.Service.IService;
using Laboratory.Web.Utility;

namespace Laboratory.Web.Service
{
    public class TestService : ITestService
    {
        private readonly IBaseService _baseService;
        public TestService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateTestsAsync(TestDto testDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = testDto,
                Url = SD.TestAPIBase + "/api/Test",
             //   ContentType = SD.ContentType.MultipartFormData
            });
        }

        public async Task<ResponseDto?> DeleteTestsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.TestAPIBase + "/api/Test/" + id
            });
        }

        public async Task<ResponseDto?> GetAllTestsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.TestAPIBase + "/api/Test"
            });
        }

        public async Task<ResponseDto?> GetTestAsync(string testCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.TestAPIBase + "/api/Test/GetByCode/" + testCode
            });
        }

        public async Task<ResponseDto?> GetTestByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.TestAPIBase + "/api/Test/" + id
            });
        }

        public async Task<ResponseDto?> UpdateTestsAsync(TestDto testDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = testDto,
                Url = SD.TestAPIBase + "/api/Test",
               // ContentType = SD.ContentType.MultipartFormData
            });
        }
    }
}
