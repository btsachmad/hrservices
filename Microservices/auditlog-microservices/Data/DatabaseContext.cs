﻿using HRServicesAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRServicesAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Audit> Audits { get; set; }
    }
}
