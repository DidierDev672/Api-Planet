using System.Numerics;
using Microsoft.EntityFrameworkCore;
using TodoApi.infrastracture.ports;
namespace TodoApi.application;

public class PlanetRepository : IPlanetRepository
{
    static List<Planet> planets { get; }
    static int nextId = 8;
    static PlanetRepository()
    {
        planets = new List<Planet>
        {
            new Planet { Id = 1, Name = "Mercurio", Mass = 3.3011 * 10.23, Radius = 2440, DistanceToSun = 57.91 * 10.6 },
            new Planet { Id = 2, Name = "Venus", Mass = 4.8685 * 10.24, Radius = 6051, DistanceToSun = 108.2 * 10.6 },
            new Planet { Id = 3, Name = "Tierra", Mass = 5.9724 * 10.24, Radius = 6371, DistanceToSun = 149.6 * 10.6 },
            new Planet { Id = 4, Name = "Júpiter", Mass = 1.9e27, Radius = 71, DistanceToSun = 778547200 },
            new Planet { Id = 5,Name = "Marte", Mass = 6.4217e23, Radius = 3389, DistanceToSun = 227943820 },
            new Planet { Id = 6, Name = "Saturno", Mass = 5.6886e26, Radius = 60268, DistanceToSun = 1429400000 },
            new Planet { Id = 7, Name = "Urano", Mass = 8.686e25, Radius = 25559, DistanceToSun = 2870980000 },
            new Planet { Id = 8, Name = "Neptuno", Mass = 1.0241e26, Radius = 24764, DistanceToSun = 4495600000 }
        };
    }

    public List<Planet> GetAllPlanet() => planets;

    public Planet GetByIdPlanet(int id)
    {
        var planet = planets.FirstOrDefault(p => p.Id == id);
        return planet;
    }

    public void CreatePlanet(Planet planet)
    {
        planet.Id = nextId++;
        planets.Add(planet);
    }

    public void UpdatePlanet(Planet planet)
    {
        var index = planets.FindIndex(p => p.Id == planet.Id);
        if (index == -1)
            return;
        planets[index] = planet;
    }

    public void DeletePlanet(int id)
    {
        var planet = GetByIdPlanet(id);
        if (planet is null)
            return;

        planets.Remove(planet);
    }
}