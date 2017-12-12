using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ToristAgency.Contracts;

namespace TouristAgency.Models
{
    public class OrderViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [ScaffoldColumn(false)]
        public int UserId { get; set; }
        [ScaffoldColumn(false)]
        public int TourId { get; set; }
        [Display(Name = "Дата заказа")]
        public DateTime DateOrder { get; set; }
        [Display(Name = "Стоимость заказа")]
        public decimal Cost { get; set; }
        [Display(Name = "Статус")]
        public string Status { get; set; }
        [Display(Name = "Имя клиента")]
        public string ClientName { get; set; }
        [ScaffoldColumn(false)]
        public  User User { get; set; }
        [Display(Name = "Название тура")]
        public  Tour Tour { get; set; }
    }
}