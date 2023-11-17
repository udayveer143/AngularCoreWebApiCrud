using Microsoft.EntityFrameworkCore;
using Product.API.Data;
using Product.API.DTO;
using Product.API.Mapper;

namespace Product.API.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _context;

        public ProductService(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> CreateUpdateProductAsync(ProductDto product)
        {
            var _product = ModelConverter.DtoToModel(product);
            if (product.Id > 0)
            {
                _context.Products.Update(_product); 
            }
            else
            {
                await _context.Products.AddAsync(_product);
            }
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product= await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProduct()
        {
            return await _context.Products.Select(product => ModelConverter.ModelToDto(product)).ToListAsync();
        }
        public async Task<ProductDto> GetProductById(int id)
        {
            return await _context.Products.Select(product=>ModelConverter.ModelToDto(product)).FirstOrDefaultAsync();
                
        }
    }
}
