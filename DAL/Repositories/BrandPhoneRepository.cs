using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class BrandPhoneRepository : BaseRepository<BrandPhone> , IBrandPhoneRepository
    {
        public BrandPhoneRepository(DbContext context) : base(context)
        {
        }
    }
}
