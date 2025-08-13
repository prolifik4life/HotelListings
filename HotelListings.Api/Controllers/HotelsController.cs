using HotelListings.Api.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelListings.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {

        private List<Hotel> hotels = new List<Hotel>() { 
            new Hotel { Id = 1, Name = "Tremont Hotels", Address = "1359 tremont drive", Rating = 4.4 },
            new Hotel { Id = 2, Name = "Holiday Hotels", Address = "139 holiday drive", Rating = 4.4 }

        };

        // GET: api/<HotelsController>
        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> Get()
        {
            return Ok(hotels);
        }

        // GET api/<HotelsController>/5
        [HttpGet("{id}")]
        public ActionResult<Hotel> Get(int id)
        {
            var hotel = hotels.FirstOrDefault(h => h.Id == id);
            if (hotel == null)
            {
                return NotFound(new { message = "Hotel not found"});
            }
            return Ok(hotel);
        }

        // POST api/<HotelsController>
        [HttpPost]
        public ActionResult<Hotel> Post([FromBody] Hotel newHotel)
        {
            if (newHotel == null) return BadRequest();
            var hotel = hotels.FirstOrDefault(h => h.Id == newHotel.Id);
            if (hotel != null) {
                return BadRequest(new { message = "Hotel with the same Id already exists." });
            }

            hotels.Add(newHotel);
            return CreatedAtAction(nameof(Get), new { id = newHotel.Id }, newHotel);
        }

        // PUT api/<HotelsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Hotel updatedHotel)
        {
            var hotel = hotels.FirstOrDefault(h => h.Id == updatedHotel.Id);
            if (hotel == null)
            {
                return NotFound(new { message = "Hotel not found." });
            }
            hotels[hotel.Id] = updatedHotel;
            return NoContent();
        }

        // DELETE api/<HotelsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var hotel = hotels.FirstOrDefault(h => h.Id == id);
            if (hotel == null)
            {
                return NotFound(new { message = "Hotel not found." });
            }
            hotels.Remove(hotel);
            return NoContent();
        }
    }
}
