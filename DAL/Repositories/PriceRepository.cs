using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class PriceRepository : BaseRepository<Price> , IPriceRepository
    {
        public PriceRepository(DbContext context) : base(context)
        {
        }
    }
}
