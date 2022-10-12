using AdvancedResources.Data;
using AdvancedResources.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedResources.Services
{
    public class DepartmentService
    {
        private readonly AdvancedResourcesContext _context;

        public DepartmentService(AdvancedResourcesContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
