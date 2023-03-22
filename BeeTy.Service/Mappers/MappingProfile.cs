using AutoMapper;
using BeeTy.Domain.Entities;
using BeeTy.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeTy.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserCDto, User>().ReverseMap();
        CreateMap<UserDto, User>().ReverseMap();
    }
}
