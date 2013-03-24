using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Core.Models;

namespace Core
{
    public class CoffeeShopDBContext : DbContext
    {
        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<Flavor> Flavors { get; set; }
        public DbSet<CurrentOrder> CurrentOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}