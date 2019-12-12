using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2019
{
    class Program
    {
        static void Main(string[] args)
        {
            //var originalCode = File.ReadAllText("input.txt").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            //var extendedCode = new long[1000000];
            //Array.Copy(originalCode, extendedCode, originalCode.Length);

            //IntCode computer = new IntCode(extendedCode);
            //computer.Process(2);
            //Console.WriteLine(computer.GetOutput());

            //var originalCode = File.ReadAllText("input.txt").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            //var extendedCode = new long[1000000];
            //Array.Copy(originalCode, extendedCode, originalCode.Length);
            //var robot = new Robot(extendedCode);
            //Console.WriteLine(robot.Solve1());

            Moon[] moons = new Moon[4];
            int i = 0;
            foreach (string line in File.ReadLines("input.txt"))
            {
                var moon = new Moon();
                moon.Parse(line);
                moons[i++] = moon;
            }

            Console.WriteLine(Day12.Solve2(moons));

        }
    }
}
