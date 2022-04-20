using DomainLayer.Common;
using Microsoft.EntityFrameworkCore;
using RepoLayer.Data;
using RepoLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T:BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> entities;
        public Repository(AppDbContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException();
            await entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            List<T> entityList= await entities.ToListAsync();
            if (entityList is null) throw new NullReferenceException();
            return entityList;
        }
    }
}
