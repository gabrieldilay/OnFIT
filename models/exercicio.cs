using System.Collections.Generic;

namespace Models {

public class Exercicio{
    public  int ExercicioId { get; set; }
    public  string  ExercicioNome { get; set; }
    public  int Series { get; set; }
    public  int Repeticoes { get; set; }
    public  int GrupoMuscular { get; set; }
    public Equipamento Equipamento { get; set; }
    }
}