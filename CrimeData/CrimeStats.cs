using System;
namespace CrimeData
{
    public class CrimeStats
    {
        public CrimeStats(int year, int population, int violentCrime, int murder, int rape, int robbery, int aggravatedAssault, int propertyCrime, int burglary, int theft, int motorTheft)
        {
            Year = year;
            Population = population;
            ViolentCrime = violentCrime;
            Murder = murder;
            Rape = rape;
            Robbery = robbery;
            AggravatedAssault = aggravatedAssault;
            PropertyCrime = propertyCrime;
            Burglary = burglary;
            Theft = theft;
            MotorTheft = motorTheft;
        }

        public int Year
        {
            get;
        }

        public int Population
        {
            get;
        }

        public int ViolentCrime
        {
            get;
        }

        public double ViolentCrimePerCapita
        {
            get 
            {
                return ViolentCrime / (Population / 100000);
            }
        }

        public int Murder
        {
            get;
        }

        public double MurderPerCapita
        {
            get
            {
                return Murder / (Population / 100000);
            }
        }

        public int Rape
        {
            get;
        }

        public double RapePerCapita
        {
            get 
            {
                return Rape / (Population / 100000);
            }
        }

        public int Robbery
        {
            get;
        }

        public double RobberyPerCapita
        {
            get
            {
                return Robbery / (Population / 100000);
            }
        }

        public int AggravatedAssault
        {
            get;
        }

        public double AggravatedAssaultPerCapita
        {
            get
            {
                return AggravatedAssault / (Population / 100000);
            }
        }

        public int PropertyCrime
        {
            get;
        }

        public double PropertyCrimePerCapita
        {
            get
            {
                return PropertyCrime / (Population / 100000);
            }
        }

        public int Burglary
        {
            get;
        }

        public double BurglaryPerCapita
        {
            get
            {
                return Burglary / (Population / 100000);
            }
        }

        public int Theft
        {
            get;
        }

        public double TheftPerCapita
        {
            get
            {
                return Theft / (Population / 100000);
            }
        }

        public int MotorTheft
        {
            get;
        }

        public double MotorTheftPerCapita
        {
            get
            {
                return MotorTheft / (Population / 100000);
            }
        }
    }
}
