using Microsoft.AspNetCore.Mvc;
using Product.API.DTO;
using Product.API.Entities;
using Product.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            ResponseDto responseDto = new ResponseDto();
            try
            {
                responseDto.Result = await _productService.GetAllProduct();
                if (responseDto.Result == null)
                {
                    responseDto.IsSuccess = false;
                    responseDto.Message = "No data found";
                }
            }
            catch (Exception ex)
            {
                responseDto.Message = ex.Message.ToString();
            }
            return responseDto;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ResponseDto> Get(int id)
        {
            ResponseDto responseDto = new ResponseDto();
            if (id > 0)
            {
                try
                {
                    responseDto.Result = await _productService.GetProductById(id);
                    if (responseDto.Result == null)
                    {
                        responseDto.IsSuccess = false;
                        responseDto.Message = "No data found";
                    }
                }
                catch (Exception ex)
                {
                    responseDto.Message = ex.Message.ToString();
                }
            }
            return responseDto;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ResponseDto> Post(ProductDto product)
        {
            ResponseDto responseDto = new ResponseDto();
            try
            {
                if (product == null)
                {
                    responseDto.IsSuccess = false;
                    responseDto.Message = "Invalid input data";
                    return responseDto;
                }
                responseDto.Result = await _productService.CreateUpdateProductAsync(product);
                return responseDto;
            }
            catch (Exception ex)
            {
                responseDto.Message = ex.Message.ToString();
            }
            return responseDto;
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<ResponseDto> Put(ProductDto product)
        {
            ResponseDto responseDto = new ResponseDto();
            try
            {
                if (product.Id <= 0)
                {
                    responseDto.IsSuccess = false;
                    responseDto.Message = "Invalid input data";
                    return responseDto;
                }
                responseDto.Result = await _productService.CreateUpdateProductAsync(product);
                return responseDto;
            }
            catch (Exception ex)
            {
                responseDto.Message = ex.Message.ToString();
            }
            return responseDto;
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<ResponseDto> Delete(int id)
        {
            ResponseDto responseDto = new ResponseDto();
            try
            {
                if (id <= 0)
                {
                    responseDto.IsSuccess = false;
                    responseDto.Message = "Invalid input data";
                    return responseDto;
                }
                responseDto.Result = await _productService.DeleteProductAsync(id);
                return responseDto;
            }
            catch (Exception ex)
            {
                responseDto.Message = ex.Message.ToString();
            }
            return responseDto;
        }
    }
}
