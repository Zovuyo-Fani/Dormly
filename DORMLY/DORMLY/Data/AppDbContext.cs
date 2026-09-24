using Microsoft.EntityFrameworkCore;
using Dormly.Shared.Models;


namespace Dormly.Data;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }


    public DbSet<Listing> Listings { get; set; }
    public DbSet<User> Users { get; set; }
}