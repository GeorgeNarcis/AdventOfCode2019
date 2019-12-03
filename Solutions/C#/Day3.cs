using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AoC2019
{
    public class Day3
    {
        class PointWithSteps
        {
            public Point point { get; set; }
            public int steps { get; set; }
        }

        public static int Solve1(string[] paths)
        {
            var path1Commands = paths[0].Split(
                new[] { ',' },
                StringSplitOptions.None);

            List<Point> path1Points = new List<Point>();
            List<Point> intersectionPoints = new List<Point>();
            var currentPath1Point = new Point(0, 0);

            foreach (string command in path1Commands)
            {
                switch (command[0])
                {
                    case 'U':
                        var moves = int.Parse(command.Substring(1));
                        for (int i = 1; i <= moves; i++)
                        {
                            path1Points.Add(new Point(currentPath1Point.X, currentPath1Point.Y + i));
                        }
                        currentPath1Point = new Point(currentPath1Point.X, currentPath1Point.Y + moves);
                        break;
                    case 'L':
                        moves = int.Parse(command.Substring(1));
                        for (int i = 1; i <= moves; i++)
                        {
                            path1Points.Add(new Point(currentPath1Point.X - i, currentPath1Point.Y));
                        }
                        currentPath1Point = new Point(currentPath1Point.X - moves, currentPath1Point.Y);
                        break;
                    case 'R':
                        moves = int.Parse(command.Substring(1));
                        for (int i = 1; i <= moves; i++)
                        {
                            path1Points.Add(new Point(currentPath1Point.X + i, currentPath1Point.Y));
                        }
                        currentPath1Point = new Point(currentPath1Point.X + moves, currentPath1Point.Y);
                        break;
                    case 'D':
                        moves = int.Parse(command.Substring(1));
                        for (int i = 1; i <= moves; i++)
                        {
                            path1Points.Add(new Point(currentPath1Point.X, currentPath1Point.Y - i));
                        }
                        currentPath1Point = new Point(currentPath1Point.X, currentPath1Point.Y - moves);
                        break;
                }
            }

            var currentPath2Point = new Point(0, 0);
            var path2Commands = paths[1].Split(
               new[] { ',' },
               StringSplitOptions.None);

            foreach (string command in path2Commands)
            {
                switch (command[0])
                {
                    case 'U':
                        var moves = int.Parse(command.Substring(1));
                        for (int i = 1; i <= moves; i++)
                        {
                            if (path1Points.Any(p => p.X == currentPath2Point.X && p.Y == currentPath2Point.Y + i))
                            {
                                intersectionPoints.Add(new Point(currentPath2Point.X, currentPath2Point.Y + i));
                            }
                        }
                        currentPath2Point = new Point(currentPath2Point.X, currentPath2Point.Y + moves);
                        break;
                    case 'L':
                        moves = int.Parse(command.Substring(1));
                        for (int i = 1; i <= moves; i++)
                        {
                            if (path1Points.Any(p => p.X == currentPath2Point.X - i && p.Y == currentPath2Point.Y))
                            {
                                intersectionPoints.Add(new Point(currentPath2Point.X - i, currentPath2Point.Y));
                            }
                        }
                        currentPath2Point = new Point(currentPath2Point.X - moves, currentPath2Point.Y);
                        break;
                    case 'R':
                        moves = int.Parse(command.Substring(1));
                        for (int i = 1; i <= moves; i++)
                        {
                            if (path1Points.Any(p => p.X == currentPath2Point.X + i && p.Y == currentPath2Point.Y))
                            {
                                intersectionPoints.Add(new Point(currentPath2Point.X + i, currentPath2Point.Y));
                            }
                        }
                        currentPath2Point = new Point(currentPath2Point.X + moves, currentPath2Point.Y);
                        break;
                    case 'D':
                        moves = int.Parse(command.Substring(1));
                        for (int i = 1; i <= moves; i++)
                        {
                            if (path1Points.Any(p => p.X == currentPath2Point.X && p.Y == currentPath2Point.Y - i))
                            {
                                intersectionPoints.Add(new Point(currentPath2Point.X, currentPath2Point.Y - i));
                            }
                        }
                        currentPath2Point = new Point(currentPath2Point.X, currentPath2Point.Y - moves);
                        break;
                }
            }

            var min = int.MaxValue;

            foreach (var p in intersectionPoints)
            {
                var distance = Math.Abs(p.X) + Math.Abs(p.Y);
                if (distance < min)
                {
                    min = distance;
                }
            }

            return min;
        }

        public static int Solve2(string[] paths)
        {
            var path1Commands = paths[0].Split(
               new[] { ',' },
               StringSplitOptions.None);

            List<PointWithSteps> path1Points = new List<PointWithSteps>();
            List<PointWithSteps> intersectionPoints = new List<PointWithSteps>();
            var currentPath1Point = new Point(0, 0);

            var stepsPath1 = 0;
            foreach (string command in path1Commands)
            {
                switch (command[0])
                {
                    case 'U':
                        var moves = int.Parse(command.Substring(1));
                        for (int i = 1; i <= moves; i++)
                        {
                            stepsPath1++;
                            path1Points.Add(new PointWithSteps { point = new Point(currentPath1Point.X, currentPath1Point.Y + i), steps = stepsPath1 });
                        }
                        currentPath1Point = new Point(currentPath1Point.X, currentPath1Point.Y + moves);
                        break;
                    case 'L':
                        moves = int.Parse(command.Substring(1));
                        for (int i = 1; i <= moves; i++)
                        {
                            stepsPath1++;
                            path1Points.Add(new PointWithSteps { point = new Point(currentPath1Point.X - i, currentPath1Point.Y), steps = stepsPath1 });
                        }
                        currentPath1Point = new Point(currentPath1Point.X - moves, currentPath1Point.Y);
                        break;
                    case 'R':
                        moves = int.Parse(command.Substring(1));
                        for (int i = 1; i <= moves; i++)
                        {
                            stepsPath1++;
                            path1Points.Add(new PointWithSteps { point = new Point(currentPath1Point.X + i, currentPath1Point.Y), steps = stepsPath1 });
                        }
                        currentPath1Point = new Point(currentPath1Point.X + moves, currentPath1Point.Y);
                        break;
                    case 'D':
                        moves = int.Parse(command.Substring(1));
                        for (int i = 1; i <= moves; i++)
                        {
                            stepsPath1++;
                            path1Points.Add(new PointWithSteps { point = new Point(currentPath1Point.X, currentPath1Point.Y - i), steps = stepsPath1 });
                        }
                        currentPath1Point = new Point(currentPath1Point.X, currentPath1Point.Y - moves);
                        break;
                }
            }

            var currentPath2Point = new Point(0, 0);
            var path2Commands = paths[1].Split(
               new[] { ',' },
               StringSplitOptions.None);
            var stepsPath2 = 0;

            foreach (string command in path2Commands)
            {
                switch (command[0])
                {
                    case 'U':
                        var moves = int.Parse(command.Substring(1));
                        for (int i = 1; i <= moves; i++)
                        {
                            stepsPath2++;
                            var intersectPoint = path1Points.FirstOrDefault(p => p.point.X == currentPath2Point.X && p.point.Y == currentPath2Point.Y + i);
                            if (intersectPoint != null)
                            {
                                intersectionPoints.Add(new PointWithSteps { point = new Point(currentPath2Point.X, currentPath2Point.Y + i), steps = intersectPoint.steps + stepsPath2 } );
                            }
                            
                        }
                        currentPath2Point = new Point(currentPath2Point.X, currentPath2Point.Y + moves);
                        break;
                    case 'L':
                        moves = int.Parse(command.Substring(1));
                        for (int i = 1; i <= moves; i++)
                        {
                            stepsPath2++;
                            var intersectPoint = path1Points.FirstOrDefault(p => p.point.X == currentPath2Point.X - i && p.point.Y == currentPath2Point.Y);
                            if(intersectPoint != null)
                            {
                                intersectionPoints.Add(new PointWithSteps { point = new Point(currentPath2Point.X - i, currentPath2Point.Y), steps = intersectPoint.steps + stepsPath2 });
                            }
                        }
                        currentPath2Point = new Point(currentPath2Point.X - moves, currentPath2Point.Y);
                        break;
                    case 'R':
                        moves = int.Parse(command.Substring(1));
                        for (int i = 1; i <= moves; i++)
                        {
                            stepsPath2++;
                            var intersectPoint = path1Points.FirstOrDefault(p => p.point.X == currentPath2Point.X + i && p.point.Y == currentPath2Point.Y);
                            if(intersectPoint != null)
                            {
                                intersectionPoints.Add(new PointWithSteps { point = new Point(currentPath2Point.X + i, currentPath2Point.Y), steps = intersectPoint.steps + stepsPath2 });
                            }
                        }
                        currentPath2Point = new Point(currentPath2Point.X + moves, currentPath2Point.Y);
                        break;
                    case 'D':
                        moves = int.Parse(command.Substring(1));
                        for (int i = 1; i <= moves; i++)
                        {
                            stepsPath2++;
                            var intersectPoint = path1Points.FirstOrDefault(p => p.point.X == currentPath2Point.X && p.point.Y == currentPath2Point.Y - i);
                            if (intersectPoint != null)
                            {
                                intersectionPoints.Add(new PointWithSteps { point = new Point(currentPath2Point.X, currentPath2Point.Y - i), steps = intersectPoint.steps + stepsPath2 });
                            }
                        }
                        currentPath2Point = new Point(currentPath2Point.X, currentPath2Point.Y - moves);
                        break;
                }
            }

            return intersectionPoints.OrderBy(t => t.steps).First().steps;
        }
    }
}
