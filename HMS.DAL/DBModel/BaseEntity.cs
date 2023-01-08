using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.DBModel
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime InsertedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
