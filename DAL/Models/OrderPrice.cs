using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class OrderPrice
    {
 
        public  Order Order { get; set; }
        public int OrderId { get; set; }
        public int PriceId { get; set; }
        public Price Price { get; set; }
    }
}
