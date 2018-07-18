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
                return ViolentCrime / Population;
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
                return Murder / Population;
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
                return Rape / Population;
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
                return Robbery / Population;
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
                return AggravatedAssault / Population;
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
                return PropertyCrime / Population;
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
                return Burglary / Population;
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
                return Theft / Population;
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
                return MotorTheft / Population;
            }
        }
    }
}
