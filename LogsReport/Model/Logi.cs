using System;
using System.Collections.Generic;

namespace LogsReport
{
    public partial class Logi
    {
        public int IdZdarzenia { get; set; }
        public string DataZdarzenia { get; set; }
        public string GodzinaZdarzenia { get; set; }
        public int NumerRcpPracownika { get; set; }
        public int TypZdarzenia { get; set; }
        public int RodzajCzytnika { get; set; }

        public virtual Zdarzenia IdZdarzeniaNavigation { get; set; }
        public virtual RodzajeCzytnikow RodzajCzytnikaNavigation { get; set; }
    }
}
