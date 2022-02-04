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
    public class TripController : ControllerBase
    {
        private DataContext dc;
        public TripController(DataContext context)
        {
            this.dc = context;
        }

        [HttpGet("api/viagem/{id}")]
        public Trip filter(int id)
        {
            Trip t = dc.trip.Find(id);

            return t;
        }
        [HttpDelete("api/viagem/{id}")]
        public async Task<ActionResult> remover(int id)
        {
            Trip t = filter(id);

            if (t == null)
            {
                return NotFound();
            }
            else
            {
                dc.trip.Remove(t);
                await dc.SaveChangesAsync();
                return Ok();
            }
        }
         [HttpPost("api/viagem")]
        public async Task<ActionResult> registerTrip([FromBody] Trip t)
        {
            dc.trip.Add(t);
            await dc.SaveChangesAsync();
            return Created("Objeto Trip", t);
        }
        [HttpPut("api/viagem")]

        public async Task<ActionResult> editar([FromBody] Trip t)
        {
            dc.trip.Update(t);
            await dc.SaveChangesAsync();

            return Ok(t);
        }
    }
}