using System.Net;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using API.Models;
namespace API.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class DriverController : ControllerBase
    {
        private DataContext dc;

        public DriverController(DataContext context)
        {
            this.dc = context;
        }
        [HttpPost("api")]
        public async Task<ActionResult> register([FromBody] Driver d)
        {
            dc.driver.Add(d);
            await dc.SaveChangesAsync();

            return Created("Objeto Driver", d);

        }
        [HttpGet("api/{id}")]
        public Driver filter(int id)
        {
            Driver d = dc.driver.Find(id);

            return d;
        }
        [HttpPut("api")]

        public async Task<ActionResult> editar([FromBody] Driver d)
        {
            dc.driver.Update(d);
            await dc.SaveChangesAsync();

            return Ok(d);
        }
        [HttpDelete("api/{id}")]
        public async Task<ActionResult> remover(int id)
        {
            Driver d = filter(id);

            if (d == null)
            {
                return NotFound();
            }
            else
            {
                dc.driver.Remove(d);
                await dc.SaveChangesAsync();
                return Ok();
            }
        }

    }
}