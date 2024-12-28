using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductWebApi1.Model;

namespace ProductWebApi1
{
    public class ProductService : IProductService
    {
        private readonly MyDBContext dbContext;
        public ProductService(MyDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //public Task<int> AddProductAsync(Product product)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<int> DeleteProductAsync(int ProductId)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<List<Product>> GetProductListAsync()
        {
            return await dbContext.Products.FromSqlRaw<Product>("GetAllProducts").ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProductListByIdAsync(int ProductId)
        {
            var param = new SqlParameter("@ProductId", ProductId);
            var ProductDetails = await Task.Run(() => dbContext.Products.
            FromSqlRaw(@"exec GetProduct1ById @Pid,prd").ToListAsync());
            return ProductDetails;
        }

        //public Task<IEnumerable<Product>> GetProductListByIdAsync(int productId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<int> UpdateProductAsync(Product product)
        //{
        //    throw new NotImplementedException();
        //}

        public new async Task<int> DeleteProductAsync(int ProductId)
        { 
            return await Task.Run(() => dbContext.Database.ExecuteSqlInterpolatedAsync
            ($"deleteProduct {ProductId}"));
        }

        public async Task<int> AddProductAsync(Product product)
        {
            var param = new List<SqlParameter>();
            param.Add(new SqlParameter("@pno", product.Pno));
            param.Add(new SqlParameter("@pname", product.Pname));
            var result = await Task.Run(() => dbContext.Database.ExecuteSqlRawAsync
            (@"exec ADDProduct1 @pno, @pname", param.ToArray()));
            return result;
        }

        public new async Task<int> UpdateProductAsync(Product product)
        {
            var param = new List<SqlParameter>();
            param.Add(new SqlParameter("@ProductId", product.Pno));
            param.Add(new SqlParameter("@ProductName", product.Pname));
            // param.Add(new SqlParameter("@ProductPrice", product.ProductPrice));
            var result = await Task.Run(() => dbContext.Database.ExecuteSqlRawAsync
            (@"exec updateproduct @ProductName,@ProductPrice", param.ToArray()));
            return result;
        }


        //public new async Task<int> insertproduct(Product product)
        //{
        //    var param = new List<SqlParameter>();
        //    param.Add(new SqlParameter("@ProductName", product.Pname));
        //    // param.Add(new SqlParameter("@ProductPrice", product.ProductPrice));
        //    var result = await Task.Run(() => dbContext.Database.ExecuteSqlRawAsync
        //    (@"exec AddNewProduct @ProductName,@ProductPrice", param.ToArray()));
        //    return result;
        //}
    }
}

