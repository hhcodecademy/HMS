using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.DBModel
{
    public class Doctor : BaseEntity
    {
        public string Name { get; set; }
        public string Speciast { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        // Foreign Key
        [ForeignKey("HospitalId")]

        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

    }
}
