using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class BrandPhone
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandPhoneId { get; set; }
        public string BrandName { get; set; }
        public string Img { get; set; }
        public string Description { get; set; }
        public ICollection<ModelPhone> modelPhones { get; set; }
        public ICollection<Comment> comments { get; set; }
    }
}
