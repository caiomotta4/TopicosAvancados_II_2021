using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjCineWeb.Model;

namespace ProjCineWeb.Data
{
    public class ProjCineWebContext : DbContext
    {
        public ProjCineWebContext (DbContextOptions<ProjCineWebContext> options)
            : base(options)
        {
        }

        public DbSet<ProjCineWeb.Model.Cliente> Cliente { get; set; }

        public DbSet<ProjCineWeb.Model.Filme> Filme { get; set; }

        public DbSet<ProjCineWeb.Model.Funcionario> Funcionario { get; set; }

        public DbSet<ProjCineWeb.Model.Ingresso> Ingresso { get; set; }
    }
}
