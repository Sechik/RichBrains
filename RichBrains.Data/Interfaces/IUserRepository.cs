using RichBrains.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RichBrains.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<IReadOnlyCollection<UserDb>> GetAllAsync();
        IReadOnlyCollection<UserDb> Get(Func<UserDb, bool> predicate);
        Task<UserDb> GetByIdAsync(Guid id);
        Task<UserDb> Create(UserDb user);
        void Remove(UserDb user);
        void Update(UserDb user);
    }
}