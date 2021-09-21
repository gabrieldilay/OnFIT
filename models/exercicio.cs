using System.Collections.Generic;

namespace models {

public class Exercicio
{
    public  int Id {get; set; }
    public  int NomeExercicio {get; set; }
    public  string  GrupoMuscular {get; set; }
    public  int Series {get; set; }
    public  int Repeticoes {get; set; }
    public  int Carga {get; set; }
}
}