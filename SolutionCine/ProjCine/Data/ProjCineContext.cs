using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjCine.Model;

namespace ProjCine.Data
{
    public class ProjCineContext : DbContext
    {
        public ProjCineContext (DbContextOptions<ProjCineContext> options)
            : base(options)
        {
        }

        public DbSet<ProjCine.Model.Funcionario> Funcionario { get; set; }
    }
}
