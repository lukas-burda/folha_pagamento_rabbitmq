using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISSDecontoB.Application.Models
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public Funcionario(string nome, string cpf)
        {
            this.Nome = nome;
            this.Cpf = cpf;
        }
    }
}
