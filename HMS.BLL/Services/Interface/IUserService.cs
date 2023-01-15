using HMS.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL.Services.Interface
{
    public interface IUserService
    {
        public Task<LocalUserDto> AddAsync(LocalUserDto item);
        public Task<LocalUserDto> GetByIdAsync(int id);
        public Task<List<LocalUserDto>> GetListAsync();
        public void Delete(int id);
        public LocalUserDto Update(LocalUserDto item);
        public Boolean IsUnique(string userName);
        public LocalUserResponseDto Login(SignInRequestDto requestDto);
    }
}
