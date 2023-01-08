using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.DBModel
{
    public class Medicine : BaseEntity
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string Composition { get; set; }
        public string Cost { get; set; }
        public string Type { get; set; }
        public string Dose { get; set; }
        public string Description { get; set; }


    }

}
