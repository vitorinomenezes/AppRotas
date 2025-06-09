using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.MappingProfiles
{
    public class RouteProfile : Profile
    {
        public RouteProfile()
        {
            CreateMap<Route, RouteDto>().ReverseMap();
            CreateMap<Users, UsersDto>().ReverseMap();
            //CreateMap<RouteDto, Route>();
            //CreateMap<RouteDto, Route>();
        }
    }
}
