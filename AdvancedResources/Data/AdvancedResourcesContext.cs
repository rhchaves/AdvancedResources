using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdvancedResources.Models;

namespace AdvancedResources.Data
{
    public class AdvancedResourcesContext : DbContext
    {
        public AdvancedResourcesContext(DbContextOptions<AdvancedResourcesContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
    }
}
