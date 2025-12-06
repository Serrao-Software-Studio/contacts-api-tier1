using _T1__ContactsAPI.Data;
using _T1__ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _T1__ContactsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Tier 1: Basic Controller structure, direct access to DbContext
    public class ContactController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public ContactController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Retrieves all Contact records from the database.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetAll()
        {
            List<Contact> contacts = await _dbContext.Entities.ToListAsync();
            // Tier 1: Return Ok(contacts)
            return Ok(contacts);
        }

        /// <summary>
        /// Retrieves a specific Contact by ID.
        /// </summary>
        /// <param name="id">The ID of the contact</param>
        /// <returns>Contact object or 404 Not Found</returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Contact>> GetById(int id)
        {
            var contact = await _dbContext.Entities.FindAsync(id);
            // Local 404 handler bypasses global middleware
            if (contact == null) return NotFound();

            return Ok(contact);
        }

        /// <summary>
        /// Creates a new Contact record.
        /// </summary>
        /// <param name="contact">The contact to create</param>
        /// <returns>The created Contact</returns>
        [HttpPost]
        public async Task<ActionResult<Contact>> Create([FromBody] Contact contact)
        {
            // Validation is handled automatically by [ApiController]
            _dbContext.Entities.Add(contact);
            await _dbContext.SaveChangesAsync();

            // Tier 1: return the created instance (200 OK)
            return Ok(contact);
        }

        /// <summary>
        /// Updates an existing Contact record.
        /// </summary>
        /// <param name="id">ID of the contact to update</param>
        /// <param name="update">Contact object with updated fields</param>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Contact update)
        {
            // Validation is handled automatically by [ApiController]
            var contact = await _dbContext.Entities.FindAsync(id);
            if (contact == null) return NotFound();

            // Tier 1: Simple field mapping (No DTO/Mapper logic)
            contact.FirstName = update.FirstName;
            contact.LastName = update.LastName;
            contact.Number = update.Number;
            contact.Email = update.Email;

            await _dbContext.SaveChangesAsync();

            return NoContent(); // 204 No Content for successful update
        }

        /// <summary>
        /// Deletes a specific Contact by ID.
        /// </summary>
        /// <param name="id">ID of the contact to delete</param>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _dbContext.Entities.FindAsync(id);
            if (contact == null) return NotFound();

            _dbContext.Entities.Remove(contact);
            await _dbContext.SaveChangesAsync();

            return NoContent(); // 204 No Content for successful delete
        }
    }
}