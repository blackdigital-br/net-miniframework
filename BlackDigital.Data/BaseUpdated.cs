using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackDigital.Data
{
    public abstract class BaseUpdated : BaseCreated
    {
        public BaseUpdated()
        {
            Updated = DateTime.UtcNow;
        }

        [Column("updated_at")]
        public DateTime Updated { get; set; }
    }
}
