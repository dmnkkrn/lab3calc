using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labcalcgit
{
    internal class ConcentrationCalculator
    {
        public double CalculatePercentage(double Solute, double Solution)
        {
            if (Solution == 0)
            {
                throw new ArgumentException("Solution cannot be zero.");
            }
            return (Solute / Solution) * 100;
        }
        public double CalculateSum(double Volume, int Units)
        {
                        return Volume * Units;
        }

        public double CalculatePercentageWithSum(double Solute, double Volume, int Units)
        {
            double totalSolution = CalculateSum(Volume, Units);
            return CalculatePercentage(Solute, totalSolution);
        }

    }


}
