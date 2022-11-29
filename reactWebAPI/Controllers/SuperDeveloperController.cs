using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using reactWebAPI.Data;
using reactWebAPI.Data.Entities;

namespace reactWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuperDeveloperController : Controller
    {
        private readonly ReactJSDemoContext _reactJSDemoContext;
        public SuperDeveloperController(ReactJSDemoContext reactJSDemoContext)
        {
            _reactJSDemoContext = reactJSDemoContext;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var developer = await _reactJSDemoContext.SuperDeveloper.ToListAsync();
            return Ok(developer);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SuperDeveloper newSuperDeveloper)
        {
            _reactJSDemoContext.SuperDeveloper.Add(newSuperDeveloper);
            await _reactJSDemoContext.SaveChangesAsync();
            return Ok(newSuperDeveloper);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var developerById = await _reactJSDemoContext
            .SuperDeveloper.Where(_ => _.Id == id)
            .FirstOrDefaultAsync();
            return Ok(developerById);
        }

        [HttpPut]
        public async Task<IActionResult> Put(SuperDeveloper developerToUpdate)
        {
            _reactJSDemoContext.SuperDeveloper.Update(developerToUpdate);
            await _reactJSDemoContext.SaveChangesAsync();
            return Ok(developerToUpdate);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var developerToDelete = await _reactJSDemoContext.SuperDeveloper.FindAsync(id);
            if (developerToDelete == null)
            {
                return NotFound();
            }
            _reactJSDemoContext.SuperDeveloper.Remove(developerToDelete);
            await _reactJSDemoContext.SaveChangesAsync();
            return Ok();
        }
    }
}
