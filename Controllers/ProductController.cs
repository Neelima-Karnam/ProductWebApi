//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using ProductWebApi1.Model;

//namespace ProductWebApi1.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductController : ControllerBase
//    {
//        private readonly IProductService productService;

//        public ProductController(IProductService productService)
//        {
//            this.productService = productService;
//        }
//        [HttpGet("getproductlist")]
//        public async Task<List<Product>> GetProductListAsync()
//        {
//            try
//            {
//                return await productService.GetProductListAsync();
//            }
//            catch
//            {
//                throw;
//            }
//        }
//        //[HttpGet("getproductlist")]
//        //public async Task<ActionResult<List<Product>>> GetProductListAsync()
//        //{
//        //    try
//        //    {
//        //        var products = await productService.GetProductListAsync();  // Fetch products from the service
//        //        return Ok(products);  // Return the products as a successful response
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        return StatusCode(500, "Internal server error: " + ex.Message); // Return a 500 status code in case of an error
//        //    }
//        //}




//        //[HttpGet("getproductlist")]
//        //public async Task<ActionResult<List<Product>>> GetProductList()
//        //{
//        //    try
//        //    {
//        //        var products = await MyDBContext.Products.ToListAsync();  // Assuming _context is your DbContext
//        //        return Ok(products);
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        return StatusCode(500, "Internal server error: " + ex.Message); // Return detailed error if needed
//        //    }
//        //}


//        [HttpPost("{ID}")]
//        public async Task<int> AddProductAsync(Product id)
//        {
//            try
//            {
//                return await productService.AddProductAsync(id);
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        [HttpDelete("deleteproduct")]
//        public async Task<int> DeleteProductAsyc(int productId)
//        {
//            try
//            {

//                return await productService.DeleteProductAsync(productId);
//            }
//            catch
//            {
//                throw;
//            }
//        }





//    }
//}
//-------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductWebApi1.Model;

namespace ProductWebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyDBContext context;

        public ProductController(MyDBContext context)
        {
            this.context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await context.Products.ToListAsync();
            return Ok(products);
        }

        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult<Product>> InsertProduct(Product product)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return Ok(product);
        }

        // DELETE: api/Product/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            // Find the product by id
            var product = await context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound(); // Return 404 if the product is not found
            }

            // Remove the product from the context
            context.Products.Remove(product);
            await context.SaveChangesAsync(); // Save changes to the database

            return NoContent(); // Return 204 No Content to indicate successful deletion
        }

        // PUT: api/Product/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product updatedProduct)
        {
            if (id != updatedProduct.Pno)
            {
                return BadRequest("Product ID mismatch"); // Return 400 if IDs don't match
            }

            var existingProduct = await context.Products.FindAsync(id);

            if (existingProduct == null)
            {
                return NotFound(); // Return 404 if the product doesn't exist
            }

            // Update the product's details
            existingProduct.Pname = updatedProduct.Pname;

            // Mark the entity as modified
            context.Entry(existingProduct).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent(); // Return 204 No Content to indicate successful update
        }
    }
}   

