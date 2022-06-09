using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using Action = WebApplication1.Models.Action;

namespace WebApplication1.Contexts;

public class AppDbContext : DbContext
{
    private readonly string _connectionString;

    public AppDbContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public AppDbContext(IConfiguration configuration, DbContextOptions options) : base(options)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public DbSet<Action> Actions { get; set; }
    public DbSet<Firefighter> Firefighters { get; set; }
    public DbSet<Firefighter_Action> FirefighterActions { get; set; }
    public DbSet<FireTruck> FireTrucks { get; set; }
    public DbSet<FireTruck_Action> FireTruckActions { get; set; }


    private void SeedDb(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Action>(t =>
        {
            t.HasData(new Action
                {
                    IdAction = 1,
                    StartTime = DateTime.Parse("03/03/2022"),
                    EndTime = DateTime.Parse("03/04/2022"),
                    NeedSpecialEquipment = true
                },
                new Action
                {
                    IdAction = 2,
                    StartTime = DateTime.Parse("03/05/2022"),
                    EndTime = null,
                    NeedSpecialEquipment = true
                });
        });

        modelBuilder.Entity<Firefighter>(t =>
        {
            t.HasData(new Firefighter
            {
                IdFirefighter = 1,
                FirstName = "Tony",
                LastName = "Stark"
            });
        });

        modelBuilder.Entity<Firefighter>(t =>
        {
            t.HasData(new FireTruck
            {
                OperationalNumber = "A1",
                SpecialEquipment = false
            });
        });

        modelBuilder.Entity<Firefighter_Action>(t =>
        {
            t.HasData(new Firefighter_Action
            {
                IdAction = 1,
                IdFirefighter = 1
            });
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Firefighter_Action>().HasKey(l => new {l.IdFirefighter, l.IdAction});
        SeedDb(modelBuilder);
    }
}