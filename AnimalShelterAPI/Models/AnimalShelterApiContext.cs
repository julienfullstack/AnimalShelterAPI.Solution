using Microsoft.EntityFrameworkCore;

namespace AnimalShelterApi.Models
{
  public class AnimalShelterApiContext : DbContext
  {
    public DbSet<Animal> Animals { get; set; }

    public AnimalShelterApiContext(DbContextOptions<AnimalShelterApiContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Animal>()
        .HasData(
          new Animal { AnimalId = 1, Name = "Matilda", Species = "Cat", Age = 7 },
          new Animal { AnimalId = 2, Name = "Rexie", Species = "Dog", Age = 10 },
          new Animal { AnimalId = 3, Name = "Matilda", Species = "Dog", Age = 2 },
          new Animal { AnimalId = 4, Name = "Pip", Species = "Cat", Age = 4 },
          new Animal { AnimalId = 5, Name = "Bartholomew", Species = "Cat", Age = 3 }
        );
    }
  }
}