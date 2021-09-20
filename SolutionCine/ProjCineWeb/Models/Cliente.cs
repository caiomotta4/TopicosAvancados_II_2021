using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjCineWeb.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public string CPF { get; set; }
        public int Idade { get; set; }
    }
}
