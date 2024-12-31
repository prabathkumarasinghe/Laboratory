

using Laboratory.Services.TestCartAPI.Models.Dto;

namespace Laboratory.Services.TestCartAPI.Service.IService
{
	public interface ITestService
	{
		Task<IEnumerable<TestDto>> GetTests();
	}
}
