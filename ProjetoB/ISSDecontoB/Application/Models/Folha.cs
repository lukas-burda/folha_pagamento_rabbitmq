using ISSDecontoB.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISSDecontoB.Application
{
    public class Folha
    {
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int horas { get; set; }
        public int valor { get; set; }
        public Funcionario funcionario { get; set; }
        public double bruto { get; set; }
        public double irrf { get; set; }
        public double inss { get; set; }
        public double fgts { get; set; }
        public double liquido { get; set; }
    }
}
