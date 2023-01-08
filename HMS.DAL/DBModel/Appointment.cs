using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.DBModel
{
    public class Appointment : BaseEntity
    {
        public int Number { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        // Foreign Key
        [ForeignKey("DoctorId")]

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }


    }
}
