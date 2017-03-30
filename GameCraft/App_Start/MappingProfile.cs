using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using GameCraft.Dtos;
using GameCraft.Models;

namespace GameCraft.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>().ForMember(m=>m.Id,opt=>opt.Ignore());
            CreateMap<Boardgame, BoardgameDto>();
            CreateMap<BoardgameDto, Boardgame>().ForMember(m => m.Id, opt => opt.Ignore());
            CreateMap<Boardgame, Boardgame>();
            CreateMap<MembershipType, MembershipTypeDto>();
            CreateMap<Genre, GenreDto>();

        }
    }
}