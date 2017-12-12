using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ToristAgency.Contracts;
namespace TouristAgency.Models
{
    public class HotelViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name = "Название")]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }
        [Display(Name = "Адрес")]
        [MinLength(2)]
        [MaxLength(20)]
        public string Address { get; set; }
        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Display(Name = "Количество звёзд")]
        public double HotelRating { get; set; }
        [ScaffoldColumn(false)]
        public int CityId { get; set; }
        [Display(Name = "Город")]
        [MinLength(2)]
        [MaxLength(20)]
        public string CityName { get; set; }
        [Display(Name = "Город")]
        public IEnumerable<City> Cities { get; set; }
        [ScaffoldColumn(false)]
        public City City { get; set; }
        [ScaffoldColumn(false)]
        public int CountryId { get; set; }
        [Display(Name = "Страна")]
        [MinLength(2)]
        [MaxLength(20)]
        public string CountryName { get; set; }
        [Display(Name = "Количество комнат в отеле")]
        public int RoomsCount { get; set; }
        [Display(Name = "Cвободных номеров")]
        public int FreeRooms { get; set; }
        [Display(Name = "Страна")]
        public IEnumerable<Country> Countries { get; set; }
    }
}