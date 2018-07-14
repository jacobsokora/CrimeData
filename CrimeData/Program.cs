using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CrimeData
{
    class Program
    {
        static void Main(string[] args)
        {
            var crimeStats = new List<CrimeStats>();

            using (var streamReader = new StreamReader("CrimeData.csv"))
            {
                //The first line of the file is column names so let's skip it
                streamReader.ReadLine();
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    var parts = line.Split(",");
                    var year = int.Parse(parts[0]);
                    var population = int.Parse(parts[1]);
                    var violentCrime = int.Parse(parts[2]);
                    var murder = int.Parse(parts[3]);
                    var rape = int.Parse(parts[4]);
                    var robbery = int.Parse(parts[5]);
                    var aggravatedAssault = int.Parse(parts[6]);
                    var propertyCrime = int.Parse(parts[7]);
                    var burglary = int.Parse(parts[8]);
                    var theft = int.Parse(parts[9]);
                    var motorTheft = int.Parse(parts[10]);
                    var stat = new CrimeStats(year, population, violentCrime, murder, rape, robbery, aggravatedAssault, propertyCrime, burglary, theft, motorTheft);
                    crimeStats.Add(stat);
                }
            }

            var query = from stat in crimeStats orderby stat.Burglary ascending select stat.Year;
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }
    }
}
