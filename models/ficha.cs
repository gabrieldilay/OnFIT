using System;
using System.Collections.Generic;

namespace Models {

    public class Ficha {

        public Aluno Aluno { get; set; }
        public Professor Professor { get; set; }
        public List<Exercicio> itens { get; set; }

    }

}