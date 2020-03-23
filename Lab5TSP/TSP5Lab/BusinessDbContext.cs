using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP5Lab
{
    public class BusinessDbContext : DbContext
    {
        public DbSet<Business> bussiness { get; set; }

        public BusinessDbContext() : base("name=BusinessDbContext")
        { }
    }
}
