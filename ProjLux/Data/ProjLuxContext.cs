using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjLux.Model;

namespace ProjLux.Data
{
    public class ProjLuxContext : DbContext
    {
        public ProjLuxContext (DbContextOptions<ProjLuxContext> options)
            : base(options)
        {
        }

        public DbSet<ProjLux.Model.Jogador> Jogador { get; set; }

        public DbSet<ProjLux.Model.Time> Time { get; set; }
    }
}
