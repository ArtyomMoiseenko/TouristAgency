using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToristAgency.Contracts
{
    public class TourType
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int AmountAdults { get; set; }
        public int AmountChildren { get; set; }
    }
}
