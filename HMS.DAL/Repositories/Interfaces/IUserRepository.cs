using HMS.DAL.DBModel;
using HMS.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Boolean IsUnique(string userName);
        public LocalUser Login(SignInRequestDto requestDto);
    }
}
