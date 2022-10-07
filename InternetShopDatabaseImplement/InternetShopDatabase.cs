﻿using InternetShopDatabaseImplement.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetShopDatabaseImplement
{
    public class InternetShopDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=InternetShopDatabase;Username=postgres;Password=MADScorpion");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
    }
}
