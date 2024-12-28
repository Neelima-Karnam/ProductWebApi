
//using ProductWebApi1.Model;

//namespace ProductWebApi1
//{
//    public interface IProductService
//    {
//        public Task<List<Product>> GetProductListAsync();
//        public Task<IEnumerable<Product>> GetProductListByIdAsync(int productId);
//        public Task<int> AddProductAsync(Product product);
//        public Task<int> UpdateProductAsync(Product product);
//        public Task<int> DeleteProductAsync(int productId);
//    }
//}
using ProductWebApi1.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductWebApi1
{
    public interface IProductService
    {
        Task<List<Product>> GetProductListAsync();
        Task<IEnumerable<Product>> GetProductListByIdAsync(int productId);
        Task<int> AddProductAsync(Product product);
        Task<int> UpdateProductAsync(Product product);
        Task<int> DeleteProductAsync(int productId);
    }
}
