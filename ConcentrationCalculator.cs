using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Solute is a thing being dissolved
//Solution is the total volume of liquid

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
        public double CalculateSum(double Solution, int Units)
        {
                        return Solution * Units;
        }

        public double CalculatePercentageWithSum(double Solute, double Solution, int Units)
        {
            double totalSolution = CalculateSum(Solution, Units);
            return CalculatePercentage(Solute, totalSolution);
        }

    }


}
