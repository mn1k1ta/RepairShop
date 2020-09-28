using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Crash
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CrashId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Price> Prices { get; set; }

    }
}
