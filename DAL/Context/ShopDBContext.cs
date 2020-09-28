using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class ShopDBContext:DbContext
    {
        public static readonly ILoggerFactory _loggerfactory = new LoggerFactory();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerfactory).EnableSensitiveDataLogging();
        }
        public ShopDBContext(DbContextOptions<ShopDBContext> options):base(options)
        {
            
        }
        DbSet<BrandPhone> brandPhones { get; set; }
        DbSet<Comment> comments { get; set; }
        DbSet<Crash> crashes { get; set; }
        DbSet<Customer> customers { get; set; }
        DbSet<ModelPhone> modelPhones { get; set; }
        DbSet<Order> orders { get; set; }
        DbSet<OrderPrice> orderPrices { get; set; }
        DbSet<OrderCrush> orderCrushes { get; set; }
        DbSet<Price> prices { get; set; }
    

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderPrice>().HasKey(a => new { a.OrderId, a.PriceId });
            base.OnModelCreating(builder);
        }
    }
}
