using AutoMapper;
using Laboratory.Services.TestParameterAPI.Models;
using Laboratory.Services.TestParameterAPI.Models.Dto;


namespace Laboratory.Services.TestParameterAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ParameterDto, Parameter>();
                config.CreateMap<Parameter, ParameterDto>();

            });
            return mappingConfig;



        }
    }
}
