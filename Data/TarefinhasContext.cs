using Microsoft.EntityFrameworkCore;
using Tarefinhas.Models;

namespace Tarefinhas.Data;

public class TarefinhasContext : DbContext
{
    public DbSet<TarefinhasModel> Tarefinhas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=tarefinhas.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}