using Laboratory.Web.Models;


namespace Laboratory.Web.Service.IService
{
    public interface ITestParameterService
    {
        Task<ResponseDto?> GetTestParameterAsync(string couponCode);
        Task<ResponseDto?> GetAllTestParameterAsync();
        Task<ResponseDto?> GetTestParameterByIdAsync(int id);
        Task<ResponseDto?> CreateTestParameterAsync(TestDto Dto);
        Task<ResponseDto?> UpdateTestParameterAsync(TestDto testDto);
        Task<ResponseDto?> DeleteTestParameterAsync(int id);
    }
}
