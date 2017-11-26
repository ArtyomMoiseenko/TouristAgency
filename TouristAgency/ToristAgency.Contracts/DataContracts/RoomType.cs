using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToristAgency.Contracts
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AmountAdults { get; set; }
        public int AmountChildren { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
