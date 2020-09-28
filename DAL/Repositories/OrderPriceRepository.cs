using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class OrderPriceRepository :  BaseRepository<OrderPrice>, IOrderPriceRepository
    {
        public OrderPriceRepository(DbContext context) : base(context)
        {
        }
    }
}
