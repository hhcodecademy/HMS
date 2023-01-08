using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Dtos
{
    public class DoctorDto:BaseDto
    {
        
        public string Name { get; set; }
        public string Speciast { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int HospitalId { get; set; }
    }
}
