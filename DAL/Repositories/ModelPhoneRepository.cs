using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class ModelPhoneRepository : BaseRepository<ModelPhone>, IModelPhoneRepository
    {
        public ModelPhoneRepository(DbContext context) : base(context)
        {
        }
    }
}
