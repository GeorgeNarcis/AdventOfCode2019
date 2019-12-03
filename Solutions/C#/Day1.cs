using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2019
{
    public class Day1
    {
        public static int Solve(string[] lines)
        {
            int sum = 0;
            foreach(var mass in lines)
            {
                var initialMass = int.Parse(mass);
                var additionalMass = (int)Math.Floor((double)(initialMass / 3)) - 2;
                while (additionalMass > 0)
                {
                    sum += additionalMass;
                    additionalMass = (int)Math.Floor((double)(additionalMass / 3)) - 2;
                }
            }


            return sum;
        }
    }
}
