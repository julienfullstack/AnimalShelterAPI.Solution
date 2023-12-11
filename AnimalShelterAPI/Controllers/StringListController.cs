using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelterApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelterApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StringListController : Controller
  {
    private readonly AnimalShelterApiContext _db;

    public StringListController(AnimalShelterApiContext db)
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