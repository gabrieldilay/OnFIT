using System.Collections.Generic;

namespace Models {

public class Exercicio{
    public  int Id { get; set; }
    public  string  Nome { get; set; }
    public  int Series { get; set; }
    public  int Repeticoes { get; set; }
    public  int GrupoMuscular { get; set; }
    public Equipamento Equipamento { get; set; }
    }
}