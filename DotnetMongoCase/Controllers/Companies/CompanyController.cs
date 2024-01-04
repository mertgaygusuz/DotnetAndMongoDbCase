using DotnetMongoCase.Models.Companies;
using DotnetMongoCase.Services.Companies;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotnetMongoCase.Controllers.Companies
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET: api/Company
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var companies = await _companyService.GetAllAsync();
            return Ok(companies);
        }

        // GET api/CompanyController/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var company = await _companyService.GetById(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        // POST api/CompanyController
        [HttpPost]
        public async Task<IActionResult> Post(Company input)
        {
            await _companyService.CreateAsync(input);
            return Ok("Created succesfully");
        }

        // PUT api/CompanyController/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Company input)
        {
            var company = await _companyService.GetById(id);
            if (company == null)
            {
                return NotFound();
            }
            await _companyService.UpdateAsync(id, input);
            return Ok("Created succesfully");
        }

        // DELETE api/CompanyController/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var company = await _companyService.GetById(id);
            if (company == null)
            {
                return NotFound();
            }
            await _companyService.DeleteAsync(id);
            return Ok("Created succesfully");
        }
    }
}
