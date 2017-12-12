using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ToristAgency.Contracts;

namespace TouristAgency.Models
{
    public class TourViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name = "Название")]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }
        [Display(Name = "Начальная дата")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Конечная дата")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Стоимость")]
        public decimal Cost { get; set; }
        [Display(Name = "Скидка")]
        public decimal Discount { get; set; }
        [ScaffoldColumn(false)]
        public int HotelId { get; set; }
        [ScaffoldColumn(false)]
        public int DietId { get; set; }
        [ScaffoldColumn(false)]
        public int TourTypeId { get; set; }
        [Display(Name = "Отель")]
        public virtual Hotel Hotel { get; set; }
        public virtual IEnumerable<Hotel> Hotels { get; set; }
        public virtual IEnumerable<Diet> Diets { get; set; }
        public virtual IEnumerable<TourType> TourTypes { get; set; }
        [Display(Name = "Питание")]
        public virtual Diet Diet { get; set; }
        [Display(Name = "Тип тура")]
        public virtual TourType TourType { get; set; }
    }
}