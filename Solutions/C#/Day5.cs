using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2019
{
    public class Day5
    {
        public const int ADD = 1;
        public const int MULTIPLY = 2;
        public const int INPUT = 3;
        public const int OUTPUT = 4;
        public const int JUMPTRUE = 5;
        public const int JUMPFALSE = 6;
        public const int LESSTHAN = 7;
        public const int EQUALS = 8;

        public static void Solve1(int[] code)
        {
            var currentIndex = 0;
            var opcode = code[currentIndex];

            do
            {         
                int firstParamMode = opcode % 1000 / 100;
                int secondParamMode = opcode % 10000 / 1000;
                
                switch (opcode % 10)
                {
                    case ADD:
                        var firstParam = firstParamMode == 0 ? code[currentIndex + 1] : currentIndex + 1;
                        var secondParam = secondParamMode == 0 ? code[currentIndex + 2] : currentIndex + 2;
                        code[code[currentIndex + 3]] = code[firstParam] + code[secondParam];
                        currentIndex += 4;
                        break;
                    case MULTIPLY:
                        firstParam = firstParamMode == 0 ? code[currentIndex + 1] : currentIndex + 1;
                        secondParam = secondParamMode == 0 ? code[currentIndex + 2] : currentIndex + 2;
                        code[code[currentIndex + 3]] = code[firstParam] * code[secondParam];
                        currentIndex += 4;
                        break;
                    case INPUT:
                        code[code[currentIndex + 1]] = 1;
                        currentIndex += 2;
                        break;
                    case OUTPUT:
                        Console.WriteLine(code[code[currentIndex + 1]]);
                        currentIndex += 2;
                        break;
                }

              
                opcode = code[currentIndex];

            } while (opcode != 99);
        }

        public static void Solve2(int[] code)
        {
            var currentIndex = 0;
            var opcode = code[currentIndex];

            do
            {        
                int firstParamMode = opcode % 1000 / 100;
                int secondParamMode = opcode % 10000 / 1000;
                
                switch (opcode % 10)
                {
                    case ADD:
                        var firstParam = firstParamMode == 0 ? code[currentIndex + 1] : currentIndex + 1;
                        var secondParam = secondParamMode == 0 ? code[currentIndex + 2] : currentIndex + 2;
                        code[code[currentIndex + 3]] = code[firstParam] + code[secondParam];
                        currentIndex += 4;
                        break;
                    case MULTIPLY:
                        firstParam = firstParamMode == 0 ? code[currentIndex + 1] : currentIndex + 1;
                        secondParam = secondParamMode == 0 ? code[currentIndex + 2] : currentIndex + 2;
                        code[code[currentIndex + 3]] = code[firstParam] * code[secondParam];
                        currentIndex += 4;
                        break;
                    case INPUT:
                        code[code[currentIndex + 1]] = 5;
                        currentIndex += 2;
                        break;
                    case OUTPUT:
                        Console.WriteLine(code[code[currentIndex + 1]]);
                        currentIndex += 2;
                        break;
                    case JUMPTRUE:
                        firstParam = firstParamMode == 0 ? code[currentIndex + 1] : currentIndex + 1;
                        secondParam = secondParamMode == 0 ? code[currentIndex + 2] : currentIndex + 2;
                        if(code[firstParam] != 0)
                        {
                            currentIndex = code[secondParam];
                        }
                        else
                        {
                            currentIndex += 3;
                        }
                        break;
                    case JUMPFALSE:
                        firstParam = firstParamMode == 0 ? code[currentIndex + 1] : currentIndex + 1;
                        secondParam = secondParamMode == 0 ? code[currentIndex + 2] : currentIndex + 2;
                        if (code[firstParam] == 0)
                        {
                            currentIndex = code[secondParam];
                        }
                        else
                        {
                            currentIndex += 3;
                        }
                        break;
                    case LESSTHAN:
                        firstParam = firstParamMode == 0 ? code[currentIndex + 1] : currentIndex + 1;
                        secondParam = secondParamMode == 0 ? code[currentIndex + 2] : currentIndex + 2;
                        if (code[firstParam] < code[secondParam])
                        {
                            code[code[currentIndex + 3]] = 1;
                        }
                        else
                        {
                            code[code[currentIndex + 3]] = 0;
                        }
                        currentIndex += 4;
                        break;
                    case EQUALS:
                        firstParam = firstParamMode == 0 ? code[currentIndex + 1] : currentIndex + 1;
                        secondParam = secondParamMode == 0 ? code[currentIndex + 2] : currentIndex + 2;
                        if (code[firstParam] == code[secondParam])
                        {
                            code[code[currentIndex + 3]] = 1;
                        }
                        else
                        {
                            code[code[currentIndex + 3]] = 0;
                        }
                        currentIndex += 4;
                        break;
                    default:
                        break;
                }

                opcode = code[currentIndex];

            } while (opcode != 99);
        }
    }
}
