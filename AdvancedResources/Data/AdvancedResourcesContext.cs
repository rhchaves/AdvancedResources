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
        public AdvancedResourcesContext (DbContextOptions<AdvancedResourcesContext> options)
            : base(options)
        {
        }

        public DbSet<AdvancedResources.Models.Department> Department { get; set; } = default!;

        public DbSet<AdvancedResources.Models.Seller> Seller { get; set; }
    }
}
