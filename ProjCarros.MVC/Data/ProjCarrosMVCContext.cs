using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjCarros.MVC.Models;

namespace ProjCarros.MVC.Data
{
    public class ProjCarrosMVCContext : DbContext
    {
        public ProjCarrosMVCContext (DbContextOptions<ProjCarrosMVCContext> options)
            : base(options)
        {
        }

        public DbSet<ProjCarros.MVC.Models.Carro> Carro { get; set; }

        public DbSet<ProjCarros.MVC.Models.Locacao> Locacao { get; set; }
    }
}
