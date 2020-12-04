using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SolarSystem
{
    class Program
    {
        public class Planets
        {
            string name;
            int mass;

            public Planets(string _name, int _mass)
            {
                name = _name;
                mass = _mass;

            }

            public string Name { get { return name; } }
            public int Mass { get { return mass; } }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ReadFromPlanetsFiles();


        }

        public static void ReadFromPlanetsFiles()
        {
            string filePath = @"C:\Users\opilane\samples";
            string fileName = @"planets.txt";

            List<Planets> planets = new List<Planets>();

            List<string> planetList = File.ReadAllLines(Path.Combine(filePath, fileName)).ToList();
            
            foreach(string line in planetList)
            {
                string[] tempArray = line.Split(new char[] { '$' }, StringSplitOptions.RemoveEmptyEntries);
                Planets newPlanet = new Planets(tempArray[0], Int32.Parse(tempArray[1]));
                planets.Add(newPlanet);
                
               
            }

            int total = 0;

            foreach(Planets planet in planets)
            {
                Console.WriteLine($"Planet: {planet.Name}; Mass: {planet.Mass}");
                total += planet.Mass;
            }

            Console.WriteLine($"Total mass: {total}");
        }
    }
}
