using Microsoft.EntityFrameworkCore;
using SampleAPI.Model;

namespace SampleAPI.Repository;

public class AppDbContext : DbContext
{

    public DbSet<Cliente> Clientes { get; set; }

    public AppDbContext()
    {
    }
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Lab365;User ID=sa;Password=kalleb09321@;Trusted_Connection=False; TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Cliente>()
            .HasMany(c => c.Contatos)
            .WithOne(co => co.Cliente)
            .HasForeignKey(co => co.ClienteId);

        modelBuilder.Entity<Cliente>()
            .HasOne(c => c.Endereco)
            .WithOne(e => e.Cliente)
            .HasForeignKey<Endereco>(e => e.ClienteId);

        modelBuilder.Entity<Cliente>().HasData(
                        new Cliente
                        {
                            Id = 1,
                            Nome = "Maria",
                            Sobrenome="Fernandes",
                            Email="maria@mail.com",
                            Status = true,
                        },
                        new Cliente
                        {
                            Id = 2,
                            Nome = "João",
                            Sobrenome="Paulo",
                            Email="jp@mail.com",
                            Status = true,
                        },
                        new Cliente
                        {
                            Id = 3,
                            Nome = "Martin",
                            Sobrenome="Fowler",
                            Email="mf@mail.com",
                            Status = false,
                        },
                        new Cliente
                        {
                            Id = 4,
                            Nome = "Uncle",
                            Sobrenome="Bob",
                            Email="martin.c.@mail.com",
                            Status = false,
                        },
                        new Cliente
                        {
                            Id = 5,
                            Nome = "Barbara",
                            Sobrenome="Liskov",
                            Email="lsp@mail.com",
                             Status = false,
                        }
           );
    }

}