using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ToristAgency.Contracts;

namespace ToristAgency.DAL
{
    public class TravelAgencyContext : DbContext
    {
        public TravelAgencyContext()
            :base("TravelAgencyContext")
        {
            //Database.SetInitializer<TravelAgencyContext>(new TravelAgencyContextInitializer());
            //Database.Initialize(true);
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<TourType> TourTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
