using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToristAgency.Contracts
{
    public class Tour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Cost { get; set; }
        public decimal Discount { get; set; }
        public int HotelId { get; set; }
        public int DietId { get; set; }
        public int TourTypeId { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual Diet Diet { get; set; }
        public virtual TourType TourType { get; set; }
    }
}
