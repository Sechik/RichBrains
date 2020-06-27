using RichBrains.Data.Models;
using RichBrains.Logic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RichBrains.Logic.Interfaces
{
    public interface IUserService
    {
        IReadOnlyCollection<UserDto> Get(Func<UserDb, bool> predicate);
        Task<IReadOnlyCollection<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(Guid id);
        Task<UserDto> Create(UserDto user);
        void Remove(UserDto user);
        void Update(UserDto user);
    }
}