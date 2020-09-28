using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelDTO
{
    public class CommentDTO
    {
        public string CommentId { get; set; }
        public string Text { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
       
    }
}
