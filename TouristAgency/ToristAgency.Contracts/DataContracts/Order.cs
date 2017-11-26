using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToristAgency.Contracts
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TourId { get; set; }
        public DateTime DateOrder { get; set; }
        public decimal Cost { get; set; }
    }
}
