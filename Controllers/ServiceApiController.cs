using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApp3.Data;
using ServiceManagerApp3.Models;

namespace ServiceManagerApp3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceApiController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ServiceApiController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var requests = _context.ServiceRequests.ToList();
            return Ok(requests);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var request = _context.ServiceRequests.Find(id);
            if (request == null)
                return NotFound();

            return Ok(request);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ServiceRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            request.CreateTime = DateTime.Now;
            _context.ServiceRequests.Add(request);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = request.Id }, request);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ServiceRequest updated)
        {
            var existing = _context.ServiceRequests.Find(id);
            if (existing == null)
                return NotFound();

            existing.Name = updated.Name;
            existing.Description = updated.Description;
            existing.ServiceType = updated.ServiceType;

            _context.ServiceRequests.Update(existing);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var request = _context.ServiceRequests.Find(id);
            if (request == null)
                return NotFound();

            _context.ServiceRequests.Remove(request);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
