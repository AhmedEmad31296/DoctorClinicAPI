using DoctorClinic.PostgresDb;

using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinic.Domain
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private DoctorClinicDbContext _context { get; }
        private readonly DbSet<T> _data;

        public BaseRepository(DoctorClinicDbContext context)
        {
            _context = context;
            _data = _context.Set<T>();
        }

        #region Get
        public virtual IQueryable<T> GetAll()
        {
            return _data.AsQueryable();
        }
        public virtual async Task<List<T>> GetAllAsync()
        {
            return  await _data.AsQueryable().ToListAsync();
        }

        public virtual T Get(long id) => _data.Find(id);

        public virtual async Task<T> GetAsync(long id) => await _data.FindAsync(id);
        #endregion

        #region Insert
        public virtual bool Insert(T entity)
        {
            _context.Add(entity);
            return SaveChange();
        }

        public virtual async Task<bool> InsertAsync(T entity)
        {
            await _context.AddAsync(entity);
            return await SaveChangeAsync();
        }
        #endregion

        #region Update
        public virtual bool Update(T entity)
        {
            _context.Update(entity);
            return SaveChange();
        }
        public virtual async Task<bool> UpdateAsync(T entity)
        {
            _data.Update(entity);
            return await SaveChangeAsync();

        }
        #endregion

        #region Delete
        public virtual bool Delete(T entity)
        {
            _data.Remove(entity);
            return SaveChange();
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            _data.Remove(entity);
            return await SaveChangeAsync();
        }
        #endregion

        #region SaveChange
        public virtual bool SaveChange()
        {
            return _context.SaveChanges() > 0;
        }

        public virtual async Task<bool> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        #endregion
    }
}
