using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ayudantia.src.Models;
using Microsoft.EntityFrameworkCore;

namespace ayudantia.src.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Product> Products { get; set; }
    }
}

