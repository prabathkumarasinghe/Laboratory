using Laboratory.Web.Models;


namespace Laboratory.Web.Service.IService
{
    public interface ITestParameterService
    {
        Task<ResponseDto?> GetTestParameterAsync(string couponCode);
        Task<ResponseDto?> GetAllTestParameterAsync();
        Task<ResponseDto?> GetTestParameterByIdAsync(int id);
        Task<ResponseDto?> CreateTestParameterAsync(ParameterDto Dto);
        Task<ResponseDto?> UpdateTestParameterAsync(ParameterDto testDto);
        Task<ResponseDto?> DeleteTestParameterAsync(int id);
    }
}
