using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2019
{
    public class Moon
    {
        public int PosX { get; set; }

        public int PosY { get; set; }

        public int PosZ { get; set; }

        public int VelocityX { get; set; }

        public int VelocityY { get; set; }

        public int VelocityZ { get; set; }

        public void Parse(string input)
        {
            var startPos = input.IndexOf("x=") + 2;
            var endPos = input.IndexOf(',', startPos); 
            PosX = int.Parse(input.Substring(startPos, endPos - startPos));
            startPos = input.IndexOf("y=") + 2;
            endPos = input.IndexOf(',', startPos);
            PosY = int.Parse(input.Substring(startPos, endPos - startPos));
            startPos = input.IndexOf("z=") + 2;
            endPos = input.IndexOf('>', startPos);
            PosZ = int.Parse(input.Substring(startPos, endPos - startPos));
        }
    }

    public class Day12
    {
        public static int Solve1(Moon[] moons)
        {
            for(int i = 0; i< 1000;i++)
            {
                ApplyGravity(moons);
                UpdatePosition(moons);
            }

            return moons.Sum(t => (Math.Abs(t.PosX) + Math.Abs(t.PosY) + Math.Abs(t.PosZ)) * (Math.Abs(t.VelocityX) + Math.Abs(t.VelocityY) + Math.Abs(t.VelocityZ))); 
        }

        public static long Solve2(Moon[] moons)
        {
            Moon[] initialMoons = new Moon[4];
            for(int i=0;i<4;i++)
            {
                initialMoons[i] = new Moon
                {
                    PosX = moons[i].PosX,
                    PosY = moons[i].PosY,
                    PosZ = moons[i].PosZ
                };
            }
            var positionFoundX = 0;
            var positionFoundY = 0;
            var positionFoundZ = 0;

            for (int i = 1; ; i++)
            {
                ApplyGravity(moons);
                UpdatePosition(moons);

                int foundOk = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (moons[j].PosX == initialMoons[j].PosX && moons[j].VelocityX == 0)
                    {
                        foundOk++;
                    }
                }

                if (foundOk == 4)
                {
                    positionFoundX = i;
                    break;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                moons[i] = new Moon
                {
                    PosX = initialMoons[i].PosX,
                    PosY = initialMoons[i].PosY,
                    PosZ = initialMoons[i].PosZ
                };
            }

            for (int i = 1;; i++)
            {
                ApplyGravity(moons);
                UpdatePosition(moons);

                int foundOk = 0;
                for (int j =0; j < 4; j++)
                {
                    if(moons[j].PosY == initialMoons[j].PosY && moons[j].VelocityY == 0)
                    {
                        foundOk++;
                    }
                }

                if (foundOk == 4)
                {
                    positionFoundY = i;
                    break;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                moons[i] = new Moon
                {
                    PosX = initialMoons[i].PosX,
                    PosY = initialMoons[i].PosY,
                    PosZ = initialMoons[i].PosZ
                };
            }

            for (int i = 1; ; i++)
            {
                ApplyGravity(moons);
                UpdatePosition(moons);

                int foundOk = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (moons[j].PosZ == initialMoons[j].PosZ && moons[j].VelocityZ == 0)
                    {
                        foundOk++;
                    }
                }

                if (foundOk == 4)
                {
                    positionFoundZ = i;
                    break;
                }
            }

            var lcm = determineLCM(positionFoundX, positionFoundY);
            return determineLCM(lcm, positionFoundZ);
        }

        public static long determineLCM(long a, long b)
        {
            long num1, num2;
            if (a > b)
            {
                num1 = a; num2 = b;
            }
            else
            {
                num1 = b; num2 = a;
            }

            for (int i = 1; i < num2; i++)
            {
                if ((num1 * i) % num2 == 0)
                {
                    return i * num1;
                }
            }
            return num1 * num2;
        }

        public static void ApplyGravity(Moon[] moons)
        {
            for(int i = 0; i < moons.Length; i++)
                for(int j = i + 1; j < moons.Length; j++)
                {
                    var moon = moons[i];
                    var otherMoon = moons[j];

                    if (moon.PosX > otherMoon.PosX)
                    {
                        moon.VelocityX--;
                        otherMoon.VelocityX++;
                    }
                    else if (moon.PosX < otherMoon.PosX)
                    {
                        moon.VelocityX++;
                        otherMoon.VelocityX--;
                    }

                    if (moon.PosY > otherMoon.PosY)
                    {
                        moon.VelocityY--;
                        otherMoon.VelocityY++;
                    }
                    else if (moon.PosY < otherMoon.PosY)
                    {
                        moon.VelocityY++;
                        otherMoon.VelocityY--;
                    }

                    if (moon.PosZ > otherMoon.PosZ)
                    {
                        moon.VelocityZ--;
                        otherMoon.VelocityZ++;
                    }
                    else if (moon.PosZ < otherMoon.PosZ)
                    {
                        moon.VelocityZ++;
                        otherMoon.VelocityZ--;
                    }
                }                
        }


        public static void UpdatePosition(Moon[] moons)
        {
            foreach(var moon in moons)
            {
                moon.PosX += moon.VelocityX;
                moon.PosY += moon.VelocityY;
                moon.PosZ += moon.VelocityZ;
            }
        }


    }
}
