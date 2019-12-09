using System;
using System.IO;
using System.Linq;

namespace AoC2019
{
    class Program
    {
        static void Main(string[] args)
        {
            var originalCode = File.ReadAllText("input.txt").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            var extendedCode = new long[1000000];
            Array.Copy(originalCode, extendedCode, originalCode.Length);

            Day9.Solve1(extendedCode);
            Day9.Solve2(extendedCode);
        }
    }
}
