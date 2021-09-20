using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjCineWeb.Model
{
    public class Filme
    {
        public int Id { get; set; }
        public string NomeFilme { get; set; }
        public int FaixaEtaria { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        
    }
}
