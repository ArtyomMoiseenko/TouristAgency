using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToristAgency.Contracts
{
    public class Room
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public bool IsBooked { get; set; }
        public decimal Cost { get; set; }
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
        public int TourId { get; set; }

        public virtual RoomType RoomType { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual Tour Tour { get; set; }
    }
}
