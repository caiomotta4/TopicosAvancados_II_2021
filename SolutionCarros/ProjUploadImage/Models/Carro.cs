using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjUploadImage.Models
{
    public class Carro
    {
        public int Id { get; set; }

        //[DisplayName("Descrição")]
        public string Nome { get; set; }

        public string Cor { get; set; }
        public string Ano { get; set; }

        public string Modelo { get; set; }
        public string Cidade { get; set; }
        public int Valor { get; set; }
        public string Potencia { get; set; }
        public string QtdPortas { get; set; }

        [DisplayName("Imagem do carro")]
        public string Image { get; set; }

        [NotMapped]
        [DisplayName("Imagem")]
        public IFormFile ImageFile { get; set; }
    }
}
