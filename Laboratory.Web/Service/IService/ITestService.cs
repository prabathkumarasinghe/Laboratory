using Laboratory.Web.Models;


namespace Laboratory.Web.Service.IService
{
    public interface ITestService
    {
        Task<ResponseDto?> GetTestAsync(string couponCode);
        Task<ResponseDto?> GetAllTestsAsync();
        Task<ResponseDto?> GetTestByIdAsync(int id);
        Task<ResponseDto?> CreateTestsAsync(TestDto Dto);
        Task<ResponseDto?> UpdateTestsAsync(TestDto testDto);
        Task<ResponseDto?> DeleteTestsAsync(int id);
    }
}
