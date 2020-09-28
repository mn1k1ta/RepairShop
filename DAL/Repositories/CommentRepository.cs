using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class CommentRepository : BaseRepository<Comment> , ICommentRepository
    {
        public CommentRepository(DbContext context) : base(context)
        {
        }
    }
}
