using HMS.DAL.Data;
using HMS.DAL.DBModel;
using HMS.DAL.Dtos;
using HMS.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repositories
{
    public class UserRepository : GenericRepository<LocalUser>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        public  bool IsUnique(string userName)
        {
            LocalUser localUser = _entities.FirstOrDefault(x => x.UserName.ToLower() == userName.ToLower());
            if (localUser==null)
            {
                return true;
            }
            return false;
        }

        public LocalUser Login(SignInRequestDto requestDto)
        {
            LocalUser localUser = _entities.FirstOrDefault(x => x.UserName == requestDto.userName && x.Password == requestDto.password);
            return localUser;
        }
    }
}
