using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinic.Domain
{
    public interface IBaseRepository<T> where T : class
    {
        #region Get
        IQueryable<T> GetAll();
        Task<List<T>> GetAllAsync();

        T Get(long id);
        Task<T> GetAsync(long id);
        #endregion

        #region Insert
        bool Insert(T entity);
        Task<bool> InsertAsync(T entity);
        #endregion

        #region Update
        bool Update(T entity);
        Task<bool> UpdateAsync(T entity);
        #endregion

        #region Delete
        bool Delete(T entity);
        Task<bool> DeleteAsync(T entity);
        #endregion

        #region SaveChange
        bool SaveChange();
        Task<bool> SaveChangeAsync();
        #endregion

    }
}
