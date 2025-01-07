using AutoMapper;
using Laboratory.Services.OrderAPI.Models;
using Laboratory.Services.OrderAPI.Models.Dto;


namespace Laboratory.Services.OrdertAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<OrderHeaderDto, CartHeaderDto>()
                .ForMember(dest => dest.CartTotal, u => u.MapFrom(src => src.OrderTotal)).ReverseMap();

                config.CreateMap<CartDetailsDto, OrderDetailsDto>()
                .ForMember(dest => dest.TesttName, u => u.MapFrom(src => src.Test.Name))
                .ForMember(dest => dest.Price, u => u.MapFrom(src => src.Test.Price));

                config.CreateMap<OrderDetailsDto, CartDetailsDto>();

                config.CreateMap<OrderHeader, OrderHeaderDto>().ReverseMap();
                config.CreateMap<OrderDetailsDto, OrderDetalis>().ReverseMap();

            });
            return mappingConfig;
        }
    }

}
