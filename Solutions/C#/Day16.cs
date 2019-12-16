using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2019
{
    public class Day16
    {
        public static long Solve1(string input)
        {
            int[] pattern = { 0, 1, 0, -1 };

            int[] number = input.Select(t => int.Parse(t.ToString())).ToArray();

            for (int i = 0; i < 100; i++)
            {
                int[] auxNr = new int[number.Length];

                Parallel.ForEach(number, (digit, state, j) =>
                {
                    var sum = 0;
                    Parallel.ForEach(number, (digitK, stateK, k) =>
                    {
                        var index = (long)Math.Floor((double)(k + 1) / (j + 1)) % 4;

                        sum += number[k] * pattern[index];
                    });
                    auxNr[j] = Math.Abs(sum) % 10;
                });
                number = auxNr;
            }

            long val = 0;
            for(long i=0; i < 7; i++)
            {
                val += number[i] * (long)Math.Pow(10, 7 - i);
            }

            return val;

        }

        public static long Solve2(string input)
        {
            int[] pattern = { 0, 1, 0, -1 };
           
            input = RepeatStringBuilderAppend(input, 10000);

            int[] number = input.Select(t => int.Parse(t.ToString())).ToArray();
            long position = 0;
            for (int i = 0; i < 7; i++)
            {
                position += number[i] * Convert.ToInt64(Math.Pow(10, 7 - i - 1));
            }
         
            for (int i = 0; i < 100; i++)
            {
                int[] auxNr = new int[number.Length];

                var sum = 0;
                for (int it = number.Length - 1; it >=position / 2; it--)
                {
                    sum += number[it];
                    auxNr[it] = Math.Abs(sum) % 10;
                }

                number = auxNr;
            }

            long val = 0;
            var index = 0;
            for (long i = position; i < position + 8; i++)
            {
                val += number[i] * (long)Math.Pow(10, 7 - index++);
            }

            return val;

        }
        static string RepeatStringBuilderAppend(string s, int n)
        {
            return new StringBuilder(s.Length * n)
                        .AppendJoin(s, new string[n + 1])
                        .ToString();
        }
    }
}
