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

                config.CreateMap<CartHeaderDto, OrderHeaderDto>()
               .ForMember(dest => dest.OrderTotal, u => u.MapFrom(src => src.CartTotal)).ReverseMap();

                config.CreateMap<CartDetailsDto, OrderDetailsDto>()
                .ForMember(dest => dest.TesttName, u => u.MapFrom(src => src.Test.Name))
                .ForMember(dest => dest.Price, u => u.MapFrom(src => src.Test.Price));

                config.CreateMap<OrderDetailsDto, CartDetailsDto>();

                config.CreateMap<OrderHeader, OrderHeaderDto>().ReverseMap();
                config.CreateMap<OrderHeader, CartHeaderDto>().ReverseMap();
                config.CreateMap<OrderHeader, CartDto>().ReverseMap();
                config.CreateMap<OrderHeaderDto, CartDto>().ReverseMap();
                config.CreateMap<CartHeaderDto, CartDto>().ReverseMap();
                config.CreateMap<OrderDetailsDto, OrderDetalis>().ReverseMap();

            });
            return mappingConfig;
        }
    }

}
