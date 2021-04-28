using Accident.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accident.BLL.Abstraction.Base
{
    public interface IManager<T>: IDisposable where T: class
    {
        Task<Result> Add(T entity);
        Task<Result> Update(T entity);
        Task<Result> Remove(long id);
        Task<IList<T>> GetAll();
        Task<T> GetById(long id);
        Task<T> GetFirstorDefault(int id);
    }
}
