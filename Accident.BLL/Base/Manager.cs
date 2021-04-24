using Accident.BLL.Abstraction.Base;
using Accident.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Accident.Repo.Abstraction.Base;

namespace Accident.BLL.Base
{
        public abstract class Manager<T> : IManager<T> where T : class
        {
            private readonly IRepo<T> _repository;
            public Manager(IRepo<T> repository)
            {
                _repository = repository;
            }

            public void Dispose()
            {

            }

            public virtual async Task<Result> Add(T entity)
            {
                bool isAdded = await _repository.Add(entity);

                if (isAdded)
                {
                    return Result.Success();
                }
                return Result.Failure(new[] { "Unable to save data!" });
            }

            public virtual async Task<Result> Update(T entity)
            {
                bool isUpdate = await _repository.Update(entity);

                if (isUpdate)
                {
                    return Result.Success();
                }
                return Result.Failure(new[] { "Unable to update data!" });
            }

            public virtual async Task<Result> Remove(long id)
            {
                var data = await _repository.GetById(id);

                if (data != null)
                {
                    bool isRemove = await _repository.Remove(data);
                    if (isRemove)
                    {
                        return Result.Success();
                    }
                }
                return Result.Failure(new[] { "Unable to remove" });
            }

            public async virtual Task<ICollection<T>> GetAll()
            {
                return await _repository.GetAll();
            }

            public async Task<T> GetById(long id)
            {
                return await _repository.GetById(id);
            }

            public Task<T> GetFirstorDefault(int id)
            {
                throw new NotImplementedException();
            }
        }
}
