using AutoMapper;
using Laboratory.Services.TestCartAPI.Models;
using Laboratory.Services.TestCartAPI.Models.Dto;


namespace Laboratory.Services.TestCartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() 
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
				config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
				config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();

			});
            return mappingConfig;
        }
    }
}
