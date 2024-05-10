using Microsoft.EntityFrameworkCore;

namespace API.Models;

public class AppDataContext : DbContext
{
   
     public DbSet<Pagamento> Pagamento { get; set; }
     public DbSet<Funcionario> Funcionario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Tagore_GabrielBraga.db");
    }
}