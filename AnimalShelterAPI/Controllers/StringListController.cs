using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelterApi.Models;

namespace AnimalShelterApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnimalController : ControllerBase
  {
    private readonly AnimalShelterApiContext _db;

    public AnimalController(AnimalShelterApiContext db)
    {
      _db = db;
    }


    [Route("api/v{version:apiVersion}/StringList")]
    [ApiVersion("1.0")]
    public async Task<List<Animal>> GetV1(string species)
    {
      IQueryable<Animal> query = _db.Animals.AsQueryable();

      if (species != null)
      {
        query = query.Where(entry => entry.Species == "cat"); 
        return await query.ToListAsync();
      }

      return new List<Animal>(); 
    }

    [Route("api/v{version:apiVersion}/StringList")]
    [ApiVersion("2.0")]
      public async Task<List<Animal>> GetV2(string species)
      {
        IQueryable<Animal> query = _db.Animals.AsQueryable();

        if (species != null)
        {
          query = query.Where(entry => entry.Species == "dog"); 
          return await query.ToListAsync();
        }

        return new List<Animal>(); 
      }
}
}