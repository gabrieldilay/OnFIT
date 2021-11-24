using Microsoft.EntityFrameworkCore;
using Models;

namespace Data {

public class Context : DbContext {
        
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Equipamento> Equipamentos { get; set; }
    public DbSet<Exercicio> Exercicios { get; set; }
    public DbSet<Ficha> Fichas { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<Professor> Professores { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=OnFit;Integrated Security=True;");

    }
}