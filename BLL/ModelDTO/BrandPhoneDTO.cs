using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BLL.ModelDTO
{
    public class BrandPhoneDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandPhoneId { get; set; }
        public string BrandName { get; set; }
        public string Img { get; set; }
        public string Description { get; set; }
     
    }
}
