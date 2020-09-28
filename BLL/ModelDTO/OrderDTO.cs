using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelDTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public string Active { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string ModelName { get; set; }
        public int CrashId { get; set; }
        public List<int> Prices { get; set; }

    }
}
