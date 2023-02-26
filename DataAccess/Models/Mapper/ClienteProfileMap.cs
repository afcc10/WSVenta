using System;
using AutoMapper;
using DataAccess.Models;
using Models.Models;
using WSVenta.Models;

namespace DataAccess.Models.Mapper
{
    public class ClienteProfileMap : Profile
    {
        public ClienteProfileMap()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
        }
    }
}
