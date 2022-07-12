using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class ZooContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Species> Species { get; set; }

        // both in main and here, make default progres username is postgres 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;host=localhost;Port=5432;Database=ZooDB;Pooling=true;Password=aa12345678;");
        }

        public ZooContext (DbContextOptions<ZooContext> options) : base(options){}

    }


    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpeciesId { get; set; } // one
        //public Species Species { get; set; }
    }

    public class Species
    {
        public int Id { get; set; }
        public string SpeciesName { get; set; }
        public List<Animal> Animals { get; set; } // many

    }

}