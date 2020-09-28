using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Price
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PriceId { get; set; }
        public Crash Crash { get; set; }
        public int CrashId { get; set; }
        public int ModelPhoneId { get; set; }
        public ModelPhone ModelPhone { get; set; }
        public double TotalPrice { get; set; }
    }
}
