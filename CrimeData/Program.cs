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
            if (args.Length < 2)
            {
                Console.WriteLine("Invalid arguments, please specify a source file and a report file (in that order).");
                return;
            }
            string inFile = args[0];
            string outFile = args[1];

            List<CrimeStats> crimeStats = new List<CrimeStats>();

            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(inFile);
                //The first line of the file is column names so let's skip it
                streamReader.ReadLine();
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] parts = line.Split(",");
                    if (parts.Length < 11)
                    {
                        Console.WriteLine("Row found with invalid data, each row should have 11 elements");
                        continue;
                    }
                    int year = int.Parse(parts[0]);
                    int population = int.Parse(parts[1]);
                    int violentCrime = int.Parse(parts[2]);
                    int murder = int.Parse(parts[3]);
                    int rape = int.Parse(parts[4]);
                    int robbery = int.Parse(parts[5]);
                    int aggravatedAssault = int.Parse(parts[6]);
                    int propertyCrime = int.Parse(parts[7]);
                    int burglary = int.Parse(parts[8]);
                    int theft = int.Parse(parts[9]);
                    int motorTheft = int.Parse(parts[10]);
                    CrimeStats stat = new CrimeStats(year, population, violentCrime, murder, rape, robbery, aggravatedAssault, propertyCrime, burglary, theft, motorTheft);
                    crimeStats.Add(stat);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("An error occured converting the data, please check that all provided data is numerical.");
                return;
            }
            catch (Exception)
            {
                Console.WriteLine("An error occured opening the data file, are you sure it exists?");
                return;
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
            }
            if (crimeStats.Count > 0)
            {
                GenerateReport(crimeStats, outFile);
            }
        }

        public static void GenerateReport(List<CrimeStats> data, string reportFile)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(reportFile);

                writer.WriteLine("Crime Analyzer Report\n");

                var yearsQuery = from stats in data select stats.Year;
                int maxYear = yearsQuery.Max();
                int minYear = yearsQuery.Min();
                int numberOfYears = yearsQuery.Count();

                writer.WriteLine("Period: {0}-{1} ({2} years)\n", minYear, maxYear, numberOfYears);

                var murderQuery = from stats in data where stats.Murder < 15000 select stats.Year;

                var toWrite = "Years murders per year < 15000: ";
                foreach (var year in murderQuery)
                {
                    toWrite += string.Format("{0}, ", year);
                }
                writer.WriteLine(toWrite.Substring(0, toWrite.Length - 2));

                var robberyQuery = from stats in data where stats.Robbery > 500000 select new {stats.Year, stats.Robbery};
                toWrite = "Robberies per year > 500000: ";
                foreach (var year in robberyQuery)
                {
                    toWrite += string.Format("{0} = {1}, ", year.Year, year.Robbery);
                }
                writer.WriteLine(toWrite.Substring(0, toWrite.Length - 2));

                var violentPerCapitaQuery = from stats in data where stats.Year == 2010 select stats.ViolentCrimePerCapita;
                writer.WriteLine("Violent crime per capita rate (2010): {0}", violentPerCapitaQuery.First());

                var averageMurderQuery = from stats in data select stats.Murder;
                writer.WriteLine("Averate murder per year (all years): {0}", averageMurderQuery.Average());

                averageMurderQuery = from stats in data where stats.Year <= 1997 && stats.Year >= 1994 select stats.Murder;
                writer.WriteLine("Average murder per year (1994-1997): {0}", averageMurderQuery.Average());

                averageMurderQuery = from stats in data where stats.Year <= 2014 && stats.Year >= 2010 select stats.Murder;
                writer.WriteLine("Average murder per year (2010-2014): {0}", averageMurderQuery.Average());

                var theftsQuery = from stats in data where stats.Year <= 2004 && stats.Year >= 1999 select stats.Theft;
                writer.WriteLine("Minimum thefts per year (1999-2004): {0}", theftsQuery.Min());
                writer.WriteLine("Maximum thefts per year (1999-2004): {0}", theftsQuery.Max());

                var highestMotorThefts = from stats in data orderby stats.MotorTheft descending select new { stats.Year, stats.MotorTheft };
                writer.WriteLine("Year of highest number of motor vehicle thefts: {0}", highestMotorThefts.First().Year);

                Console.WriteLine("Crime report generated at {0}", reportFile);
            }
            catch (Exception e)
            {
                Console.WriteLine("There was an error writing to your report file, please make sure you have the necessary permissions and that the file path is valid: {0}", e.Message);
            }
            finally
            {
                writer.Close();
            }
        }
    }
}
