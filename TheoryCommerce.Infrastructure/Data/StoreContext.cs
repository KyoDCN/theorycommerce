﻿using Microsoft.EntityFrameworkCore;
using TheoryCommerce.Core.Entities;

namespace TheoryCommerce.Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options): base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}