using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.DBModel
{
    public class Hospital : BaseEntity
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }


        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Nurse> Nurses { get; set; }

    }
}
