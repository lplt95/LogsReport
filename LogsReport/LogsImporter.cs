using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LogsReport
{
    class LogsImporter
    {
        public List<Logi> ImportLogs(string filePath)
        {
            List<Logi> logi = new List<Logi>();
            var logs = File.OpenText(filePath);
            while (!logs.EndOfStream)
            {
                var log = logs.ReadLine().Split(new char[] { ';' });
                logi.Add(new Logi()
                {
                    DataZdarzenia = log[0],
                    GodzinaZdarzenia = log[1] + ":" + log[2],
                    NumerRcpPracownika = Int32.Parse(log[3]),
                    TypZdarzenia = Int32.Parse(log[4]),
                    RodzajCzytnika = Int32.Parse(log[5]),
                });
            }
            return logi;
        }
    }
}
