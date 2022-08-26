using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackDigital.Data
{
    public abstract class BaseDeleted : BaseUpdated
    {
        [Column("deleted_at")]
        public DateTime? Deleted { get; set; }
    }
}
