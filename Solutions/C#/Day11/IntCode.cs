using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2019
{
    public class IntCode
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

        long[] Code { get; set; }

        long CurrentInstructionPointer { get; set; }

        long CurrentOpCode { get; set; }

        long BaseOffset { get; set; }

        List<long> CurrentOutput { get; set; }

        public IntCode(long[] code)
        {
            Code = code;
            CurrentInstructionPointer = 0;
            BaseOffset = 0;
            CurrentOpCode = Code[CurrentInstructionPointer];
            CurrentOutput = new List<long>();
        }

        public List<long> GetOutput() => CurrentOutput;

        public void ClearOutput() => CurrentOutput.Clear();

        public void Process(long input)
        {
            long firstParam = GetParamIndex(1);
            long secondParam = GetParamIndex(2);
            long thirdParam = GetParamIndex(3); 

            switch (CurrentOpCode % 10)
            {
                case ADD:
                    Code[thirdParam] = Code[firstParam] + Code[secondParam];
                    CurrentInstructionPointer += 4;
                    break;
                case MULTIPLY:
                    Code[thirdParam] = Code[firstParam] * Code[secondParam];
                    CurrentInstructionPointer += 4;
                    break;
                case INPUT:
                    Code[firstParam] = input;
                    CurrentInstructionPointer += 2;
                    break;
                case OUTPUT:
                    CurrentOutput.Add(Code[firstParam]);
                    CurrentInstructionPointer += 2;
                    break;
                case JUMPTRUE:
                    if (Code[firstParam] != 0)
                    {
                        CurrentInstructionPointer = Code[secondParam];
                    }
                    else
                    {
                        CurrentInstructionPointer += 3;
                    }
                    break;
                case JUMPFALSE:
                    if (Code[firstParam] == 0)
                    {
                        CurrentInstructionPointer = Code[secondParam];
                    }
                    else
                    {
                        CurrentInstructionPointer += 3;
                    }
                    break;
                case LESSTHAN:
                    if (Code[firstParam] < Code[secondParam])
                    {
                        Code[thirdParam] = 1;
                    }
                    else
                    {
                        Code[thirdParam] = 0;
                    }
                    CurrentInstructionPointer += 4;
                    break;
                case EQUALS:
                    if (Code[firstParam] == Code[secondParam])
                    {
                        Code[thirdParam] = 1;
                    }
                    else
                    {
                        Code[thirdParam] = 0;
                    }
                    CurrentInstructionPointer += 4;
                    break;
                case RELATIVEOFFSET:
                    BaseOffset += Code[firstParam];
                    CurrentInstructionPointer += 2;
                    break;
                default:
                    break;
            }

            CurrentOpCode = Code[CurrentInstructionPointer];
        }

        public bool IsRunning()
        {
            return CurrentOpCode != 99;
        }

        long GetParamIndex(int paramNr)
        {
            long paramMode = CurrentOpCode / (long)Math.Pow(10, paramNr + 1) % 10;

            switch (paramMode)
            {
                case 0:
                    return Code[CurrentInstructionPointer + paramNr];
                case 1:
                    return CurrentInstructionPointer + paramNr;
                case 2:
                    return Code[CurrentInstructionPointer + paramNr] + BaseOffset;
                default:
                    return 0;
            }
        }
    }
}
