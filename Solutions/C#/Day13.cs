using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AoC2019
{

    public enum TileType
    {
        Empty = 0,
        Wall,
        Block,
        HorizontalPaddle,
        Ball
    }

    public class Tile
    {
        public long X;
        public long Y;
        public TileType Type { get; set; }
    }

    public class Arcade
    {
        IntCode Computer;
        List<Tile> Tiles;
        long Score;


        public Arcade(long[] Code)
        {
            Code[0] = 2;
            Computer = new IntCode(Code);
            Tiles = new List<Tile>();
        }

        public long Solve1()
        {
            while (Computer.IsRunning())
            {
                while (Computer.GetOutput().Count < 3 && Computer.IsRunning())
                {
                    Computer.Process(0);
                }

                var output = Computer.GetOutput();
                if (output.Count == 3)
                {
                    Tiles.Add(new Tile { X = output.ElementAt(0), Y = output.ElementAt(1), Type = (TileType)output.ElementAt(2) });
                    Computer.ClearOutput();
                }
            }

            return Tiles.Count(t => t.Type == TileType.Block);

        }

        public long Solve2()
        {
            Computer.SetMemoryAddress(2, 0);
            while (Computer.IsRunning())
            {
                while (Computer.GetOutput().Count < 3 && Computer.IsRunning())
                {
                    Computer.Process(getJoystickPos());
                }


                var output = Computer.GetOutput();
                if (output.Count == 3)
                {
                    var firstOutput = output.ElementAt(0);
                    var secondOutput = output.ElementAt(1);
                    if (firstOutput == -1 && secondOutput == 0)
                    {
                        Score = output.ElementAt(2);
                    }
                    else
                    {
                        Tiles.Add(new Tile { X = firstOutput, Y = secondOutput, Type = (TileType)output.ElementAt(2) });
                    }
                    Computer.ClearOutput();
                }
            }

            return Score;
        }

        public int getJoystickPos()
        {
            var ball = Tiles.LastOrDefault(t => t.Type == TileType.Ball);
            var paddle = Tiles.LastOrDefault(t => t.Type == TileType.HorizontalPaddle);

            if (ball != null && paddle != null)
            {
                if (paddle.X < ball.X)
                {
                    return 1;
                }
                else if (paddle.X == ball.X)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            return 0;
        }
    }
}
