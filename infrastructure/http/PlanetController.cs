using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.infrastracture.ports;

namespace TodoApi.infrastracture.http;

[ApiController]
[Route("[controller]")]
public class PlanetController : ControllerBase
{
    private readonly IPlanetRepository _planetRepository;

    public PlanetController(IPlanetRepository planetRepository)
    {
        _planetRepository = planetRepository;
    }

    [HttpGet]
    public ActionResult<List<Planet>> Get() => _planetRepository.GetAllPlanet();

    [HttpGet("{id}")]
    public ActionResult<Planet> Get(int id)
    {
        var planet = _planetRepository.GetByIdPlanet(id);

        if (planet == null)
            return NotFound();

        return planet;
    }

    [HttpPost]
    public IActionResult CreatePlanet([FromBody] Planet planet)
    {
        _planetRepository.CreatePlanet(planet);
        return CreatedAtAction(nameof(Get), new { id = planet.Id }, planet);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePlanet(int id, Planet planet)
    {
        if (id != planet.Id)
            return BadRequest();

        var existingPizza = _planetRepository.GetByIdPlanet(id);
        if (existingPizza is null)
            return NotFound();
        _planetRepository.UpdatePlanet(planet);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePlanet(int id)
    {
        var planet = _planetRepository.GetByIdPlanet(id);
        if (planet is null)
            return NotFound();

        _planetRepository.DeletePlanet(id);
        return NoContent();
    }

}