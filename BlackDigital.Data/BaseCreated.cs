using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackDigital.Data
{
    public abstract class BaseCreated
    {
        public BaseCreated()
        {
            Created = DateTime.UtcNow;
        }

        [Column("created_at")]
        public DateTime Created { get; set; }
    }
}
