using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToristAgency.Contracts;
using TouristAgency.Models;

namespace TouristAgency
{
    public static class MapperConfig
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserViewModel>()
                    .ForMember(uvm => uvm.RoleName, u => u.MapFrom(us => us.Role.Name))
                    .ForMember(uvm => uvm.RoleId, u => u.MapFrom(us => us.RoleId));
                cfg.CreateMap<UserViewModel, User>()
                    .ForMember(uvm => uvm.RoleId, u => u.MapFrom(us => us.RoleId));

                cfg.CreateMap<Hotel, HotelViewModel>()
                    .ForMember(hvm => hvm.CityId, h => h.MapFrom(ho => ho.CityId))
                    .ForMember(hvm => hvm.CityName, h => h.MapFrom(ho => ho.City.Name));
                cfg.CreateMap<HotelViewModel, Hotel>()
                    .ForMember(hvm => hvm.CityId, h => h.MapFrom(ho => ho.CityId));

                cfg.CreateMap<Tour, TourViewModel>();
                cfg.CreateMap<TourViewModel, Tour>();

                cfg.CreateMap<HotelViewModel, Hotel>();
                cfg.CreateMap<Order, OrderViewModel>();
                cfg.CreateMap<Room, RoomViewModel>();
            });
        }
    }
}