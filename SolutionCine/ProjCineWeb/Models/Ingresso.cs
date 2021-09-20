using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjCineWeb.Model
{
    public class Ingresso
    {
        public int Id { get; set; }
        public virtual Filme Filme { get; set; }
        [NotMapped]
        public virtual List<SelectListItem> Filmes { get; set;}
        public virtual Cliente Cliente { get; set; }
        [NotMapped]
        public virtual List<SelectListItem> Clientes { get; set; }
        public int Valor { get; set; }
        public DateTime DataHora { get; set; }
    }
}
