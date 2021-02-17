using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Videoteka.Models;

namespace Videoteka.Data
{
    public class KontekstBaze : DbContext
    {
        public KontekstBaze (DbContextOptions<KontekstBaze> options)
            : base(options)
        {
        }

        public DbSet<Videoteka.Models.Film> Film { get; set; }

        public DbSet<Videoteka.Models.Žanr> Žanr { get; set; }

        public DbSet<Videoteka.Models.Vani> Vani { get; set; }
    }
}
