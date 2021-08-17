using Sulmar.EFCore.Models;
using System.Collections.Generic;

namespace Vavatech.EFCore.IRepositories
{
    public interface IEntityRepository<TEntity>
        where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Remove(int id);
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
    }
}
