using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2019
{
    public class Day2
    {
        public static int Solve1(int[] code)
        {
            code[1] = 12;
            code[2] = 2;
            var currentIndex = 0;
            var opcode = code[currentIndex];
            
            do
            {
                switch(opcode)
                {
                    case 1:
                        code[code[currentIndex + 3]] = code[code[currentIndex + 1]] + code[code[currentIndex + 2]];
                        break;
                    case 2:
                        code[code[currentIndex + 3]] = code[code[currentIndex + 1]] * code[code[currentIndex + 2]];
                        break;
                    default:
                        break;
                }

                currentIndex += 4;
                opcode = code[currentIndex];

            } while (opcode != 99);

            return code[0];
        }

        public static int Solve2(int[] code)
        {
            int[] backupCode = new int[code.Length];
            Array.Copy(code, backupCode, code.Length);

           for(var i = 1; i < 145; i++)
                for(var j = 1; j < 145; j++)
                { 
                    Array.Copy(backupCode, code, backupCode.Length);
                    code[1] = i;
                    code[2] = j;
                    var currentIndex = 0;
                    var opcode = code[currentIndex];

                    do
                    {
                        switch (opcode)
                        {
                            case 1:
                                code[code[currentIndex + 3]] = code[code[currentIndex + 1]] + code[code[currentIndex + 2]];
                                break;
                            case 2:
                                code[code[currentIndex + 3]] = code[code[currentIndex + 1]] * code[code[currentIndex + 2]];
                                break;
                            default:
                                break;
                        }

                        currentIndex += 4;
                        opcode = code[currentIndex];

                    } while (opcode != 99);

                    if(code[0] == 19690720)
                    {
                        return 100 * i + j;
                    }
            }

            return 0;
        }
    }
}
