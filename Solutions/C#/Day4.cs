using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2019
{
    public class Day4
    {
        public static int Solve1()
        {
            int counter = 0;
            for(var i = 138241; i<= 674034; i++ )
            {
                var digits = i.ToString().Select(t => int.Parse(t.ToString())).ToArray();
                bool doubleFound = false;
                bool decrease = false;
                for(var j = 0; j < digits.Length - 1; j++)
                {
                    if(digits[j] > digits[j + 1])
                    {
                        decrease = true;
                        break;
                    }
                    else if (digits[j] == digits[j +1])
                    {
                        doubleFound = true;
                    }
                }

                if(!decrease && doubleFound)
                {
                    counter++;
                }

            }

            return counter;
        }

        public static int Solve2()
        {
            int counter = 0;
            for (var i = 138241; i <= 674034; i++)
            {
                var digits = i.ToString().Select(t => int.Parse(t.ToString())).ToArray();
                bool doubleFound = false;
                bool decrease = false;
                for (var j = 1; j < digits.Length - 2; j++)
                {
                    if (digits[j] > digits[j + 1])
                    {
                        decrease = true;
                        break;
                    }

                    if (digits[0] > digits[1])
                    {
                        decrease = true;
                        break;
                    }

                    if (digits[digits.Length - 2] > digits[digits.Length - 1])
                    {
                        decrease = true;
                        break;
                    }


                    else if (digits[j] == digits[j + 1] && digits[j + 1] != digits[j + 2] && digits[j] != digits[j-1])
                    {
                        doubleFound = true;
                    }

                    if (digits[digits.Length - 1] == digits[digits.Length - 2] && digits[digits.Length - 2] != digits[digits.Length - 3])
                    {
                        doubleFound = true;
                    }

                    if (digits[0] == digits[1] && digits[1] != digits[2])
                    {
                        doubleFound = true;
                    }                
                }

                if (!decrease && doubleFound)
                {
                    counter++;
                }

            }

            return counter;
        }
    }
}
