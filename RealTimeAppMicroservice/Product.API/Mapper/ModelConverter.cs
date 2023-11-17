using Product.API.DTO;

namespace Product.API.Mapper
{
    public static class ModelConverter
    {
        public static Entities.Product DtoToModel(ProductDto model)
        {
            return new Entities.Product
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                CategoryId = model.CategoryId,
                ImageUrl = model.ImageUrl
            };
        }
        public static ProductDto ModelToDto(Entities.Product model)
        {
            return new ProductDto
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                CategoryId = model.CategoryId,
                ImageUrl = model.ImageUrl
            };
        }
    }
}
