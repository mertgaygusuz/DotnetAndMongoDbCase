using DotnetMongoCase.Models.Companies;
using DotnetMongoCase.Models.Contacts;
using DotnetMongoCase.Services.Companies;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotnetMongoCase.Controllers.Contacts
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // GET: api/Contact
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var contacts = await _contactService.GetAllAsync();
            return Ok(contacts);
        }

        // GET api/ContactController/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var contact = await _contactService.GetById(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        // POST api/ContactController
        [HttpPost]
        public async Task<IActionResult> Post(Contact input)
        {
            input.CompanyName = null;
            await _contactService.CreateAsync(input);
            return Ok("Created succesfully");
        }

        // PUT api/ContactController/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Contact input)
        {
            input.CompanyName = null;
            var contact = await _contactService.GetById(id);
            if (contact == null)
            {
                return NotFound();
            }
            await _contactService.UpdateAsync(id, input);
            return Ok("Created succesfully");
        }

        // DELETE api/ContactController/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var contact = await _contactService.GetById(id);
            if (contact == null)
            {
                return NotFound();
            }
            await _contactService.DeleteAsync(id);
            return Ok("Created succesfully");
        }
    }
}
