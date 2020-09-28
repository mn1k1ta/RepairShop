using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }      
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public string Active { get; set; }
        public Customer Customer { get; set; }
        public ModelPhone ModelPhone { get; set; }
    }
}
