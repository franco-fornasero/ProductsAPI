using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApp.Data;
using ProductsApp.Data.Models;
using ProductsApp.Services.Interfaces;
using ProductsApp.Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsApp.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // Interfaz de servicio para las operaciones de producto
        private readonly IProduct _product;
  
        public ProductsController(IProduct product)
        {
            _product = product;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get(int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber < 1 || pageSize < 1)
                return BadRequest("Los parámetros de paginación deben ser mayores que 0.");

            var products = await _product.GetProducts(pageNumber, pageSize);

            return Ok(products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _product.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); 

            var createdProduct = await _product.CreateProduct(product);
            return CreatedAtAction(nameof(Post), new { id = createdProduct.Id }, createdProduct);

        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != product.Id) 
                return BadRequest("El ID de la ruta no coincide con el ID del producto.");

            var updatedProduct = await _product.UpdateProduct(product);
            if (updatedProduct == null)
                return NotFound(); 

            return Ok(updatedProduct); 

        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _product.DeleteProduct(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
