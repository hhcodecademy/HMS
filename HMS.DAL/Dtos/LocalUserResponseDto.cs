using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Dtos
{
    public class LocalUserResponseDto
    {
        public LocalUserDto UserDto { get; set; }
        public string Token { get; set; }
    }
}
