using Microsoft.EntityFrameworkCore;

namespace models {

    public class Context : DbContext {
        
        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=exemplo_db;Integrated Security=True;");
        }
        
    }
}