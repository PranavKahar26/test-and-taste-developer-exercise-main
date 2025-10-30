using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Test_Taste_Console_Application.Domain.DataTransferObjects;

namespace Test_Taste_Console_Application.Domain.Objects
{
    public class Planet
    {
        public string Id { get; set; }
        public float SemiMajorAxis { get; set; }
        public ICollection<Moon> Moons { get; set; }
        public float AverageMoonGravity
        {
            get => 0.0f;
        }

        //Added
        public double AverageMoonTemperature
        {
            get
            {
                if (Moons == null || Moons.Count == 0)
                    return 0.0f;

                double total = 0.0;
                int count = 0;
                foreach (var moon in Moons)
                {
                    total += moon.AverageTemperature;
                    count++;
                }

                return count > 0 ? total / count : 0.0;
            }
        }
        //

        public Planet(PlanetDto planetDto)
        {
            Id = planetDto.Id;
            SemiMajorAxis = planetDto.SemiMajorAxis;
            Moons = new Collection<Moon>();
            if(planetDto.Moons != null)
            {
                foreach (MoonDto moonDto in planetDto.Moons)
                {
                    Moons.Add(new Moon(moonDto));
                }
            }
        }

        public Boolean HasMoons()
        {
            return (Moons != null && Moons.Count > 0);
        }
    }
}
