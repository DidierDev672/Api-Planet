namespace TodoApi.infrastracture.ports;

public interface IPlanetRepository
{
    List<Planet> GetAllPlanet();
    Planet GetByIdPlanet(int id);
    void CreatePlanet(Planet planet);
    void UpdatePlanet(Planet planet);
    void DeletePlanet(int id);
}