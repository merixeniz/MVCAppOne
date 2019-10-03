using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MVCAppOne.Models;

namespace MVCAppOne.DAL
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base ("StoreContext")
        {

        }

        static StoreContext() //statyczny konstruktor jest wykonywany tylko raz przy 1st użyciu klasy StoreContext
        {
           Database.SetInitializer<StoreContext>(new StoreInitializer());
        }

        public DbSet<Album> Albums {get; set;}

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
    }
}