using Microsoft.EntityFrameworkCore;
using RichBrains.Data.Context;
using RichBrains.Data.Interfaces;
using RichBrains.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RichBrains.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IReadOnlyCollection<UserDb>> GetAllAsync()
        {
            return await _appDbContext.Users.AsNoTracking().ToArrayAsync();
        }

        public IReadOnlyCollection<UserDb> Get(Func<UserDb, bool> predicate)
        {
            return _appDbContext.Users.AsNoTracking().Where(predicate).ToArray();
        }

        public async Task<UserDb> GetByIdAsync(Guid id)
        {
            return await _appDbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UserDb> Create(UserDb user)
        {
            _appDbContext.Users.Add(user);
            user.Id = Guid.NewGuid();
            await _appDbContext.SaveChangesAsync();
            return user;
        }

        public async void Update(UserDb user)
        {
            _appDbContext.Entry(user).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }

        public async void Remove(UserDb user)
        {
            _appDbContext.Users.Remove(user);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
