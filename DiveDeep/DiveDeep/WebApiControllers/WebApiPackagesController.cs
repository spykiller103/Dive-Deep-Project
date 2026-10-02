using DiveDeep.Models;
using DiveDeep.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeep.WebApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebApiPackagesController : ControllerBase
    {
        private readonly IPackageRepository _packageRepository;

        public WebApiPackagesController(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Package> packages = await _packageRepository.GetAllAsync();
            return Ok(packages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecefic(int id)
        {
            if (id <= 0)
                return BadRequest();

            Package package = await _packageRepository.GetByIdAsync(id);

            if (package == null)
                return NotFound();

            return Ok(package);
        }

        [HttpPost]
    }
}
