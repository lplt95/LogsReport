using System;
using System.Collections.Generic;

namespace LogsReport
{
    public partial class Zdarzenia
    {
        public int IdZdarzenia { get; set; }
        public string NazwaZdarzenia { get; set; }

        public virtual Logi Logi { get; set; }
    }
}
