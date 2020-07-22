using System;
using System.Collections.Generic;

namespace LogsReport
{
    public partial class RodzajeCzytnikow
    {
        public RodzajeCzytnikow()
        {
            Logi = new HashSet<Logi>();
        }

        public int IdRodzaju { get; set; }
        public string NazwaRodzaju { get; set; }

        public virtual ICollection<Logi> Logi { get; set; }
    }
}
