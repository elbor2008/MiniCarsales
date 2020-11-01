using AutoMapper;
using MiniCarsales.Api.Dto;
using MiniCarsales.Api.Models;
using MiniCarsales.Api.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCarsales.Api.Mppers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarReturnDto>()
                .ForMember(dto => dto.VehicleType, c => c.MapFrom(c => c.VehicleType.ToString()))
                .ForMember(dto => dto.BodyType, c => c.MapFrom(c => c.BodyType.ToString()));
        }
    }
}
