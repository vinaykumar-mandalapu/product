using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using product_api;

namespace product_api.Data
{
    public class product_apiContext : DbContext
    {
        public product_apiContext (DbContextOptions<product_apiContext> options)
            : base(options)
        {
        }

        public DbSet<product_api.Product> Product { get; set; }
    }
}
