using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2019
{
    public class Day6
    {
        public class Orbit
        {
            public string Name { get; set; }

            public string Previous { get; set; }

            public int Level { get; set; }
        }

        public static int Solve1(string[] vertexes)
        {
            var nrOfOrbits = 0;
            List<Orbit> orbits = new List<Orbit>();

            foreach(var vertex in vertexes)
            {
                var splitted = vertex.Split(new char[] { ')' }, StringSplitOptions.RemoveEmptyEntries);
                orbits.Add(new Orbit { Name = splitted[1], Previous = splitted[0] });
            }

            int level = 1;
            var startingPoint = orbits.FirstOrDefault(t => t.Previous == "COM");
            startingPoint.Level = level;
            CountLevel(orbits.Where(t => t.Previous == startingPoint.Name).ToList(), orbits, level);


            return orbits.Sum(t => t.Level);
        }

        public static void CountLevel(List<Orbit> orbitsAdj, List<Orbit> allOrbits, int level)
        {
            if(orbitsAdj.Count > 0)
            {
                level++;
                foreach(var orbit in orbitsAdj)
                {
                    orbit.Level = level; 
                    CountLevel(allOrbits.Where(t => t.Previous == orbit.Name).ToList(), allOrbits, level);
                }
            }
        }

        public static int Solve2(string[] vertexes)
        {
            List<Orbit> orbits = new List<Orbit>();

            foreach (var vertex in vertexes)
            {
                var splitted = vertex.Split(new char[] { ')' }, StringSplitOptions.RemoveEmptyEntries);
                orbits.Add(new Orbit { Name = splitted[1], Previous = splitted[0] });
            }

            var intersectNode = GetIntersectNode("SAN", "YOU", orbits);

            int sourceCount = GetPathCount("YOU", intersectNode, orbits);

            int destCount = GetPathCount("SAN", intersectNode, orbits); ;

            return destCount + sourceCount;
        }

        public static string GetIntersectNode(string destNodeName, string sourceNodeName, List<Orbit> orbits)
        {
            var listPrevSource = new List<string>();
            var listPrevDest = new List<string>();

            var source = orbits.FirstOrDefault(t => t.Name == sourceNodeName);
            var destination = orbits.FirstOrDefault(t => t.Name == destNodeName);

            while (source.Previous != "COM")
            {
                listPrevSource.Add(source.Name);
                source = orbits.FirstOrDefault(t => t.Name == source.Previous);
            }

            while (destination.Previous != "COM")
            {
                listPrevDest.Add(destination.Name);
                destination = orbits.FirstOrDefault(t => t.Name == destination.Previous);
            }

            return listPrevSource.Intersect(listPrevDest).First();
        }

        public static int GetPathCount(string sourceNodeName, string destNodeName, List<Orbit> orbits)
        {
            int pathCount = 0;
            var source = orbits.FirstOrDefault(t => t.Name == sourceNodeName);
            while (source.Previous != destNodeName)
            {
                pathCount++;
                source = orbits.FirstOrDefault(t => t.Name == source.Previous);
            }

            return pathCount;
        }
    }
}
