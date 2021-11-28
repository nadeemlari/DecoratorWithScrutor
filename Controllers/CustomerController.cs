using DecoratorWithScrutor.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DecoratorWithScrutor.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var guid = Guid.Parse(id);
            var customer = await _repository.GetCustomerAsync(guid);
            return Ok(customer);
        }
    }
}
