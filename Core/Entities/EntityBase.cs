using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class EntityBase:IEntity
    {
        public DateTime CreatedDate { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set;}
    }
}
