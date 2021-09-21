using System;
using models;

namespace OnFit
{
    class Program
    {
        static void Main(string[] args)
        {
            Context ctx = new Context();

            Aluno a = new Aluno();
            a.Nome = "João";
            
            ctx.Alunos.Add(a);
            ctx.SaveChanges();

            Console.WriteLine("Registro Incluido no banco de dados!");

            var alunos = ctx.Alunos;
            foreach (var aluno in alunos)
            {
                Console.WriteLine($"Auno: {aluno.Nome}");
            }
        }
    }
}
