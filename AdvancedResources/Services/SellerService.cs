using AdvancedResources.Data;
using AdvancedResources.Models;
using AdvancedResources.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedResources.Services
{
    public class SellerService
    {
        private readonly AdvancedResourcesContext _context;

        public SellerService(AdvancedResourcesContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
        
        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public void Update(Seller obj)
        {
            bool hasAny = _context.Seller.Any(seller => seller.Id == obj.Id);

            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException error) // Se ocorrer uma exceção de acesso a dados
            {
                throw new DbConcurrencyException(error.Message); // Será relançado em nível de serviço
            }
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(seller => seller.Id == obj.Id);

            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException error) // Se ocorrer uma exceção de acesso a dados
            {
                throw new DbConcurrencyException(error.Message); // Será relançado em nível de serviço
            }
        }
    }
}
