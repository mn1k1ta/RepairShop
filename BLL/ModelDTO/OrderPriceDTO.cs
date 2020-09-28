using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelDTO
{
    public class OrderPriceDTO
    {
        public int OrderPriceId { get; set; }
        public Order Order { get; set; }
        public Price Price { get; set; }
    }
}
