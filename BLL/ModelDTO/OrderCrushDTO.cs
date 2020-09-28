using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelDTO
{
    public class OrderCrushDTO
    {
        public int OrderCrushId { get; set; }
        public Order Order { get; set; }
        public Crash Crash { get; set; }
    }
}
