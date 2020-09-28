using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class CrashRepository : BaseRepository<Crash> , ICrashRepository
    {
        public CrashRepository(DbContext context) : base(context)
        {
        }
    }
}
