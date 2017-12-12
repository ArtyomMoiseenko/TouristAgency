using System;
using System.Collections.Generic;
using System.Linq;
using ToristAgency.DAL;

namespace ToristAgency.DAL
{
    public class TravelAgencyInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TravelAgencyContext>
    {
        protected override void Seed(TravelAgencyContext context)
        {
            var roles = new List<ToristAgency.Contracts.Role>
            {
                new ToristAgency.Contracts.Role { Name = "admin" },
                new ToristAgency.Contracts.Role { Name = "manager" },
                new ToristAgency.Contracts.Role { Name = "user" }
            };
            roles.ForEach(r => context.Roles.Add(r));
            context.SaveChanges();

            var users = new List<ToristAgency.Contracts.User>
            {
                new ToristAgency.Contracts.User
                {
                    LastName = "Бардамид",
                    FirstName = "Влад",
                    Email = "burdrun@demo.com",
                    Password = "123456",
                    RoleId = 3,
                    Phone = "(099)-345-9595"
                }
            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var countries = new List<ToristAgency.Contracts.Country>
            {
                new ToristAgency.Contracts.Country { Name = "Украина" },
                new ToristAgency.Contracts.Country { Name = "США" },
                new ToristAgency.Contracts.Country { Name = "Великобритания" }
            };
            countries.ForEach(c => context.Countries.Add(c));
            context.SaveChanges();

            var cities = new List<ToristAgency.Contracts.City>
            {
                new ToristAgency.Contracts.City { Name = "Киев", CountryId = 1 },
                new ToristAgency.Contracts.City { Name = "Харьков", CountryId = 1 },
                new ToristAgency.Contracts.City { Name = "Нью Йорк", CountryId = 2 },
                new ToristAgency.Contracts.City { Name = "Лондон", CountryId = 3 }
            };
            cities.ForEach(c => context.Cities.Add(c));
            context.SaveChanges();

            var hotels = new List<ToristAgency.Contracts.Hotel>
            {
                new ToristAgency.Contracts.Hotel
                {
                    Name = "Kiev Palace",
                    CityId = 1,
                    HotelRating = 4,
                    Phone = "(066)-754-1345",
                    Address = "ул.Люботина, 5"
                },
                new ToristAgency.Contracts.Hotel
                {
                    Name = "New York Hotel",
                    CityId = 3,
                    HotelRating = 5,
                    Phone = "(066)-231-1345",
                    Address = "ул.Вашингтона, 12"
                }
            };
            hotels.ForEach(h => context.Hotels.Add(h));
            context.SaveChanges();

            var tourTypes = new List<ToristAgency.Contracts.TourType>
            {
                new ToristAgency.Contracts.TourType
                {
                    Name = "Для двоих",
                    AmountAdults = 2,
                    AmountChildren = 0
                },
                new ToristAgency.Contracts.TourType
                {
                    Name = "Семейный",
                    AmountAdults = 2,
                    AmountChildren = 1
                },
                new ToristAgency.Contracts.TourType
                {
                    Name = "Семейный (2+2)",
                    AmountAdults = 2,
                    AmountChildren = 2
                }
            };
            tourTypes.ForEach(t => context.TourTypes.Add(t));
            context.SaveChanges();

            var roomTypes = new List<ToristAgency.Contracts.RoomType>
            {
                new ToristAgency.Contracts.RoomType
                {
                    Name = "Двухместный",
                    AmountAdults = 2,
                    AmountChildren = 0
                },
                new ToristAgency.Contracts.RoomType
                {
                    Name = "Семейный",
                    AmountAdults = 2,
                    AmountChildren = 1
                },
                new ToristAgency.Contracts.RoomType
                {
                    Name = "Семейный (2+2)",
                    AmountAdults = 2,
                    AmountChildren = 2
                }
            };
            roomTypes.ForEach(t => context.RoomTypes.Add(t));
            context.SaveChanges();

            var diets = new List<ToristAgency.Contracts.Diet>
            {
                new ToristAgency.Contracts.Diet { Name = "Всё включено" },
                new ToristAgency.Contracts.Diet { Name = "Завтрак" },
                new ToristAgency.Contracts.Diet { Name = "Без питания" }
            };
            diets.ForEach(t => context.Diets.Add(t));
            context.SaveChanges();

            var rooms = new List<ToristAgency.Contracts.Room>();
            Random rand = new Random();
            for (int i = 1; i <= 20; i++)
            {
                rooms.Add(new ToristAgency.Contracts.Room
                {
                    Name = i,
                    HotelId = 1,
                    Cost = rand.Next(100, 1000),
                    IsBooked = false,
                    RoomTypeId = rand.Next(1, 3),
                    TourId = null
                });
            };
            rooms.ForEach(r => context.Rooms.Add(r));
            context.SaveChanges();

            var tours = new List<ToristAgency.Contracts.Tour>
            {
                new ToristAgency.Contracts.Tour
                {
                    Name = "Вперёд по истории!",
                    TourTypeId = 1,
                    HotelId = 1,
                    Cost = rand.Next(100, 1000),
                    DietId = 1,
                    StartDate = DateTime.Now.AddDays(-14),
                    EndDate = DateTime.Now,
                    Discount = 0
                }
            };
            tours.ForEach(t => context.Tours.Add(t));
            context.SaveChanges();

            var orders = new List<ToristAgency.Contracts.Order>
            {
                new ToristAgency.Contracts.Order
                {
                    TourId = 1,
                    UserId = 1,
                    DateOrder = DateTime.Now,
                    Cost = tours.FirstOrDefault(t => t.Id == 1).Cost
                }
            };
            orders.ForEach(t => context.Orders.Add(t));
            context.SaveChanges();
        }
    }
}