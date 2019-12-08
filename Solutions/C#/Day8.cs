using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2019
{
    public class Day8
    {
        public static int Solve1(string input)
        {
            var layers = Split(input, 25 * 6);

            var minimun0Layer = layers.FirstOrDefault(l => l.Count(s => s == '0') == layers.Min(t => t.Count(s => s == '0')));

            return minimun0Layer.Count(t => t == '1') * minimun0Layer.Count(t => t == '2');

        }

        public static string Solve2(string input)
        {
            var size = 25 * 6;
            char[] finalLayer = new char[size];
            var layers = Split(input, size);

            for(int i=0; i < size; i++)
            {
                var layer = layers.FirstOrDefault(t => t[i] != '2');
                finalLayer[i] = layer[i];
            }

            var msg = new string(finalLayer);
            return msg;
        }

        static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
    }
}
