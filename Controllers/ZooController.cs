using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Model;

namespace Test
{
    [Route ("api/[controller]")]
    public class ZooController : Controller
    {
        private ZooContext db;
        public ZooController(ZooContext db)
        {
            this.db = db;
        }

        [HttpGet("SayHello")]
        public async Task<IActionResult> SayHello() => Ok("Hello!");

        [HttpGet("bob")]
        public async Task<IActionResult> GetAllAnimals()
        {

        
            return Ok(from s in db.Species
                      from a in db.Animals
                      where a.SpeciesId == s.Id
                      select new { Species = s.SpeciesName, Animal = a.Name  }
                      );
        }

        [HttpPost("random")]
        public async Task<IActionResult> MakeRandomAnimals()
        {
            
            // example to create one animal
            //db.Animals.Add(new Animal()
            //{
            //    Name = "Stephan",
            //});


            // example with both animals and species that are relational,
            // species can have many animals, animals have one species
            // See models for more details how to do it
            db.Species.Add(new Species(){
                SpeciesName = "Lions",
                Animals = new List<Animal>() { 
                    new Animal () { Name = "Stephan" }
                }
            });

            // always run to save changes
            db.SaveChanges();
            return Ok();
        }


    }

}