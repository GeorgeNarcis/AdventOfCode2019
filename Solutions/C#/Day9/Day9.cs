using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2019
{
    public class Day9
    {
        public const int ADD = 1;
        public const int MULTIPLY = 2;
        public const int INPUT = 3;
        public const int OUTPUT = 4;
        public const int JUMPTRUE = 5;
        public const int JUMPFALSE = 6;
        public const int LESSTHAN = 7;
        public const int EQUALS = 8;
        public const int RELATIVEOFFSET = 9;


        public static void Solve1(long[] code)
        {
            Solve(code, 1);
        }

        public static void Solve2(long[] code)
        {
            Solve(code, 2);
        }

        static void Solve(long[] code, int input)
        {
            long currentIndex = 0;
            long opcode = code[currentIndex];
            long baseOffset = 0;

            do
            {
                long firstParamMode = opcode / 100 % 10;
                long secondParamMode = opcode / 1000 % 10;
                long thirdParamMode = opcode / 10000 % 10;

                long firstParam = 0;
                long secondParam = 0;
                long thirdParam = 0;


                switch (firstParamMode)
                {
                    case 0:
                        firstParam = code[currentIndex + 1];
                        break;
                    case 1:
                        firstParam = currentIndex + 1;
                        break;
                    case 2:
                        firstParam = code[currentIndex + 1] + baseOffset;
                        break;
                    default:
                        break;
                }


                switch (secondParamMode)
                {
                    case 0:
                        secondParam = code[currentIndex + 2];
                        break;
                    case 1:
                        secondParam = currentIndex + 2;
                        break;
                    case 2:
                        secondParam = code[currentIndex + 2] + baseOffset;
                        break;
                    default:
                        break;
                }

                switch (thirdParamMode)
                {
                    case 0:
                        thirdParam = code[currentIndex + 3];
                        break;
                    case 1:
                        thirdParam = currentIndex + 3;
                        break;
                    case 2:
                        thirdParam = code[currentIndex + 3] + baseOffset;
                        break;
                    default:
                        break;
                }

                switch (opcode % 10)
                {
                    case ADD:
                        code[thirdParam] = code[firstParam] + code[secondParam];
                        currentIndex += 4;
                        break;
                    case MULTIPLY:
                        code[thirdParam] = code[firstParam] * code[secondParam];
                        currentIndex += 4;
                        break;
                    case INPUT:
                        code[firstParam] = input;
                        currentIndex += 2;
                        break;
                    case OUTPUT:
                        Console.WriteLine(code[firstParam]);
                        currentIndex += 2;
                        break;
                    case JUMPTRUE:
                        if (code[firstParam] != 0)
                        {
                            currentIndex = code[secondParam];
                        }
                        else
                        {
                            currentIndex += 3;
                        }
                        break;
                    case JUMPFALSE:
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
                        if (code[firstParam] < code[secondParam])
                        {
                            code[thirdParam] = 1;
                        }
                        else
                        {
                            code[thirdParam] = 0;
                        }
                        currentIndex += 4;
                        break;
                    case EQUALS:
                        if (code[firstParam] == code[secondParam])
                        {
                            code[thirdParam] = 1;
                        }
                        else
                        {
                            code[thirdParam] = 0;
                        }
                        currentIndex += 4;
                        break;
                    case RELATIVEOFFSET:
                        baseOffset += code[firstParam];
                        currentIndex += 2;
                        break;
                    default:
                        break;
                }

                opcode = code[currentIndex];

            } while (opcode != 99);
        }
    }
}
