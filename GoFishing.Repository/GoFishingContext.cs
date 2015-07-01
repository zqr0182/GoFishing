using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using GoFishing.Domain.Models;

namespace GoFishing.Repository
{
    public partial class GoFishingContext : DbContext
    {
        static GoFishingContext()
        {
            Database.SetInitializer<GoFishingContext>(null);
        }

        public GoFishingContext()
            : base("Name=GoFishingContext")
        {
            //Lazy loading and serialization don抰 mix well, and if you aren抰 careful you can end up querying for your entire database just because lazy loading is enabled. 
            //Most serializers work by accessing each property on an instance of a type. 
            //Property access triggers lazy loading, so more entities get serialized. 
            //On those entities properties are accessed, and even more entities are loaded. 
            //It抯 a good practice to turn lazy loading off before you serialize an entity. 
            //Loading of related entities can still be achieved using eager loading with .Include
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Trophy> Trophies { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
