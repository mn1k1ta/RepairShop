using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class OrderCrushRepository:BaseRepository<OrderCrush>,IOrderCrashRepository
    {
        public OrderCrushRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
