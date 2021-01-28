using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class bazaContext : DbContext
    {
        public bazaContext(DbContextOptions<bazaContext> options) : base(options) { }
        public DbSet<Czesc> Czesc { get; set; }
        public DbSet<Klient> Klient { get; set; }
        public DbSet<Zamowienie> Zamowienie { get; set; }
    }
}
