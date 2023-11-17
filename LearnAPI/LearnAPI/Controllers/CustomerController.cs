using LearnAPI.Modal;
using LearnAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService service;
        public CustomerController(ICustomerService customerService)
        {
            service = customerService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await service.GetAll();
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpGet("Getbycode")]
        public async Task<IActionResult> Getbycode(string code)
        {
            var data = await service.Getbycode(code);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Customermodal customermodal)
        {
            var data = await service.Create(customermodal);
            return Ok(data);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(Customermodal customermodal, string code)
        {
            var data = await service.Update(customermodal,code);
            return Ok(data);
        }
        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(string code)
        {
            var data = await service.Remove(code);
            return Ok(data);
        }
    }
}
