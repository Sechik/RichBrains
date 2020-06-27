using AutoMapper;
using RichBrains.Data.Interfaces;
using RichBrains.Data.Models;
using RichBrains.Logic.Interfaces;
using RichBrains.Logic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RichBrains.Logic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<UserDto>> GetAllAsync()
        {
            var usersDb = await _userRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<UserDto>>(usersDb);
        }

        public IReadOnlyCollection<UserDto> Get(Func<UserDb, bool> predicate)
        {
            var usersDb = _userRepository.Get(predicate);
            return _mapper.Map<IReadOnlyCollection<UserDto>>(usersDb);
        }

        public async Task<UserDto> GetByIdAsync(Guid id)
        {
            return _mapper.Map<UserDto>(await _userRepository.GetByIdAsync(id));
        }

        public async Task<UserDto> Create(UserDto user)
        {
            var userDb = _mapper.Map<UserDb>(user);
            var userDto = await _userRepository.Create(userDb);
            return _mapper.Map<UserDto>(userDto);
        }

        public void Update(UserDto user)
        {
            _userRepository.Update(_mapper.Map<UserDb>(user));
        }

        public void Remove(UserDto user)
        {
            _userRepository.Remove(_mapper.Map<UserDb>(user));
        }
    }
}
