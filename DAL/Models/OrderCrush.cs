using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class OrderCrush
    {  
        public int OrderCrushId { get; set; }
        public Order Order { get; set; }
        public Crash Crash { get; set; }
    }
}
