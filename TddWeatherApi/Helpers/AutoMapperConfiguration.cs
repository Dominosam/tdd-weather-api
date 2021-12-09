using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TddWeatherApi.AppServices.Models;
using TddWeatherApi.AppServices.Models.DTOs;

namespace TddWeatherApi.Helpers
{
    public class AutoMapperConfiguration : Profile
    {
        public static IMapper Mapper { get; private set; }

        public static MapperConfiguration MapperConfiguration { get; private set; }

        public static void RegisterMappings()
        {
            var mapperConfiguration = new MapperConfigurationExpression();
            var xd = new ApiConnectionResponseModelDto();

            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApiConnectionResponseModelDto, GeneralWeatherData>()
                .ForMember(rsp => rsp.Temperature, opt => opt.MapFrom(dto => dto.main.temp))
                .ForMember(rsp => rsp.MinimalTemperature, opt => opt.MapFrom(dto => dto.main.temp_min))
                .ForMember(rsp => rsp.MaximalTemperature, opt => opt.MapFrom(dto => dto.main.temp_max))
                .ForMember(rsp => rsp.PerceivedTemperature, opt => opt.MapFrom(dto => dto.main.feels_like))
                .ForMember(rsp => rsp.Pressure, opt => opt.MapFrom(dto => dto.main.pressure))
                .ForMember(rsp => rsp.Humidity, opt => opt.MapFrom(dto => dto.main.humidity))
                .ReverseMap();

                cfg.CreateMap<ApiConnectionResponseModelDto, Coordinates>()
                .ForMember(rsp => rsp.Latitude, opt => opt.MapFrom(dto => dto.coord.lat))
                .ForMember(rsp => rsp.Longitude, opt => opt.MapFrom(dto => dto.coord.lon))
                .ReverseMap();

                cfg.CreateMap<ApiConnectionResponseModelDto, ApiConnectionResponseModel>()
                .ForMember(rsp => rsp.City, opt => opt.MapFrom(dto => dto.name))
                .ForMember(rsp => rsp.Country, opt => opt.MapFrom(dto => dto.sys.country))
                .ForMember(rsp => rsp.Coordinates, opt => opt.MapFrom(dto => Mapper.Map<ApiConnectionResponseModelDto, Coordinates>(dto)))
                .ForMember(rsp => rsp.GeneralWeatherData, opt => opt.MapFrom(dto => Mapper.Map<ApiConnectionResponseModelDto, GeneralWeatherData>(dto))).IncludeAllDerived();

            });
            Mapper = MapperConfiguration.CreateMapper();
        }
    }
}
