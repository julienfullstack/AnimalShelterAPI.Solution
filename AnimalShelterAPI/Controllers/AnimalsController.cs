using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelterApi.Models;

namespace AnimalShelterApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [ApiVersion("1.0")]
  public class AnimalsController : ControllerBase
  {
    private readonly AnimalShelterApiContext _db;

    public AnimalsController(AnimalShelterApiContext db)
    {
      _db = db;
    }

    // GET api/animals
    [HttpGet]
    [ApiVersion("1.0")]
    public async Task<List<Animal>> Get(string species, string name, int minimumAge)
    {
      IQueryable<Animal> query = _db.Animals.AsQueryable();

      if (species != null)
      {
        query = query.Where(entry => entry.Species == species);
      }

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if (minimumAge > 0)
      {
        query = query.Where(entry => entry.Age >= minimumAge);
      }

      return await query.ToListAsync();
    }

    // GET: api/Animals/5
    [HttpGet("{id}")]
    [ApiVersion("1.0")]
    public async Task<ActionResult<Animal>> GetAnimal(int id)
    {
      Animal animal = await _db.Animals.FindAsync(id);

      if (animal == null)
      {
        return NotFound();
      }

      return animal;
    }

    // POST api/animals
    [HttpPost]
    [ApiVersion("1.0")]
    public async Task<ActionResult<Animal>> Post([FromBody] Animal animal)
    {
      _db.Animals.Add(animal);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetAnimal), new { id = animal.AnimalId }, animal);
    }

        // PUT: api/Animals/5
    [HttpPut("{id}")]
    [ApiVersion("1.0")]
    public async Task<IActionResult> Put(int id, Animal animal)
    {
      if (id != animal.AnimalId)
      {
        return BadRequest();
      }

      _db.Animals.Update(animal);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AnimalExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    private bool AnimalExists(int id)
    {
      return _db.Animals.Any(e => e.AnimalId == id);
    }

    // DELETE: api/Animals/5
    [HttpDelete("{id}")]
    [ApiVersion("1.0")]
    public async Task<IActionResult> DeleteAnimal(int id)
    {
      Animal animal = await _db.Animals.FindAsync(id);
      if (animal == null)
      {
        return NotFound();
      }

      _db.Animals.Remove(animal);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    // GET: api/Animals/Random
  [HttpGet("Random")]
  [ApiVersion("1.0")]
  public async Task<ActionResult<Animal>> GetRandomAnimal()
  {
    Random random = new Random();
    int count = await _db.Animals.CountAsync();
    int randomId = random.Next(1, count + 1);

    Animal animal = await _db.Animals.FindAsync(randomId);

    if (animal == null)
    {
      return NotFound();
    }

    return animal;
  }

    [Route("api/v{version:apiVersion}/StringList")]
    [ApiVersion("1.0")]
    [HttpGet]
    public async Task<List<Animal>> GetV1(string species)
    {
      IQueryable<Animal> query = _db.Animals.AsQueryable();
      query = query.Where(entry => entry.Species == "cat"); 
      return await query.ToListAsync();
    }

    [Route("api/v{version:apiVersion}/StringList")]
    [ApiVersion("2.0")]
    [HttpGet]
      public async Task<List<Animal>> GetV2(string species)
      {
        IQueryable<Animal> query = _db.Animals.AsQueryable();

        query = query.Where(entry => entry.Species == "dog"); 
      return await query.ToListAsync();
      }
  
}

}