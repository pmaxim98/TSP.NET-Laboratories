using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Asp_Maxim_Paul_Rp.Models;

namespace Asp_Maxim_Paul_Rp.Data
{
    public class Asp_Maxim_Paul_RpContext : DbContext
    {
        public Asp_Maxim_Paul_RpContext (DbContextOptions<Asp_Maxim_Paul_RpContext> options)
            : base(options)
        {
        }

        public DbSet<Asp_Maxim_Paul_Rp.Models.Movie> Movie { get; set; }
    }
}
