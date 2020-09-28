using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set;}
        public int Rating { get; set; }
        public BrandPhone BrandPhone { get; set; }
        public Customer Customer { get; set; }
    }
}
