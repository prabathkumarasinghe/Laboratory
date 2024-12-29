using AutoMapper;
using Laboratory.Services.TestAPI.Models;
using Laboratory.Services.TestAPI.Models.Dto;

namespace Laboratory.Services.TestAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<TestDto, Test>();
                config.CreateMap<Test, TestDto>();

            });
            return mappingConfig;



        }
    }
}
