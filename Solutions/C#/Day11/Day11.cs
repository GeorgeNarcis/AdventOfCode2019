using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AoC2019
{
    public class Robot
    {
        const long size = 100;
        IntCode Computer;
        long[,] painted = new long[size, size];
        long[,] grid = new long[size, size];
        long CurrentX;
        long CurrentY;
        char CurrentDirection = 'N';

        public Robot(long[] Code)
        {
            Computer = new IntCode(Code);
            CurrentX = CurrentY = size / 2;
        }

        public long Solve1()
        {
            while(Computer.IsRunning())
            {
                while (Computer.GetOutput().Count < 2 && Computer.IsRunning())
                {
                    Computer.Process(grid[CurrentX, CurrentY]);
                }

                var output = Computer.GetOutput();
                if (output.Count > 1)
                {
                    grid[CurrentX, CurrentY] = output.ElementAt(0);
                    painted[CurrentX, CurrentY] = 1;
                    ProcessDirection(output.ElementAt(1));
                    Computer.ClearOutput();
                }
            }

            var count = 0;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if(painted[i, j] == 1)
                    {
                        count++;
                    }
            return count;
        }

        public void Solve2()
        {
            grid[CurrentX, CurrentY] = 1;
            while (Computer.IsRunning())
            {
                while (Computer.GetOutput().Count < 2 && Computer.IsRunning())
                {
                    Computer.Process(grid[CurrentX, CurrentY]);
                }

                var output = Computer.GetOutput();
                if (output.Count > 1)
                {
                    grid[CurrentX, CurrentY] = output.ElementAt(0);
                    painted[CurrentX, CurrentY] = 1;
                    ProcessDirection(output.ElementAt(1));
                    Computer.ClearOutput();
                }
            }

            for (int i = 0; i < size; i++)
            { 
                Console.WriteLine();
                for (int j = 0; j < size; j++)
                    if (grid[i, j] == 1)
                        Console.Write(grid[i, j]);
                    else
                        Console.Write(" ");
            }
        }

        public void ProcessDirection(long nextInstruction)
        {
            switch(CurrentDirection)
            {
                case 'N':
                    if(nextInstruction == 0)
                    {
                        CurrentDirection = 'W';
                        CurrentX--;
                    }
                    else if(nextInstruction == 1)
                    {
                        CurrentDirection = 'E';
                        CurrentX++;
                    }
                    break;
                case 'E':
                    if (nextInstruction == 0)
                    {
                        CurrentDirection = 'N';
                        CurrentY--;
                    }
                    else if (nextInstruction == 1)
                    {
                        CurrentDirection = 'S';
                        CurrentY++;
                    }
                    break;
                case 'S':
                    if (nextInstruction == 0)
                    {
                        CurrentDirection = 'E';
                        CurrentX++;
                    }
                    else if (nextInstruction == 1)
                    {
                        CurrentDirection = 'W';
                        CurrentX--;
                    }
                    break;
                case 'W':
                    if (nextInstruction == 0)
                    {
                        CurrentDirection = 'S';
                        CurrentY++;
                    }
                    else if (nextInstruction == 1)
                    {
                        CurrentDirection = 'N';
                        CurrentY--;
                    }
                    break;
                default:
                    var asd = 2;
                    break;
            }
        }
    }
}
