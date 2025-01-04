



using Laboratory.Services.OrderAPI.Models.Dto;

namespace Laboratory.Services.OrderAPI.Service.IService
{
	public interface ITestService
	{
		Task<IEnumerable<TestDto>> GetTests();
	}
}
