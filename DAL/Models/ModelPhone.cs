using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class ModelPhone
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModelPhoneId { get; set; }
        public string ModelName { get; set; }
        public string Img { get; set; }
        public string Description { get; set; }
        public ICollection<Price> Prices { get; set; }
        public BrandPhone BrandPhone { get; set; }
    }
}
