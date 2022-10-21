using Microsoft.EntityFrameworkCore;
using SellerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models
{
    public class APICoreDBContext : DbContext
    {
        public APICoreDBContext(DbContextOptions<APICoreDBContext> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<SellerInfo> SellerInfo { get; set; }
    }
}
