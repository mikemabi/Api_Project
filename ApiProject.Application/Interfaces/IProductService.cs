using ApiProject.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ApiProject.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task  AddProductAsync(ProductDto product);
        Task EditProductAsync(int id, ProductDto product);
        Task DeleteProductAsync(int id);
        IPagedList<ProductDto> GetPaginatedProducts(int pageNumber, int pageSize);
    }
}
