using Microsoft.EntityFrameworkCore;

namespace models {

    public class Context : DbContext {
        
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Ficha> Fichas { get; set; }
        public DbSet<Professor> Professores { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=exemplo_db;Integrated Security=True;");
        }
        
    }
}