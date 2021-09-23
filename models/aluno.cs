using System.Collections.Generic;

namespace Models {

public class Aluno : Usuario{
    public string Nome { get; set; }
    public Professor Professor { get; set;}
    public int Idade { get; set; }
    public double Altura { get; set; }
    public double Peso { get; set; }
    public string Objetivo { get; set; }
    }
}