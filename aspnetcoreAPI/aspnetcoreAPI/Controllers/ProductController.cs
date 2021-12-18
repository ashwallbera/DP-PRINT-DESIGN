using aspnetcoreAPI.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace aspnetcoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private string connectionString = "Server=.;Initial Catalog=DpPrintDesign;Integrated Security=true";



        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProduct()
        {

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string cmd = string.Format(@"
                               Select 
                               *
                               FROM products where isDeleted='"+ false + "' ");

                var results = await connection.QueryAsync<ProductModel>(cmd);
                connection.Close();
                var product = results.ToList();
                return Ok(product);
            }

        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ProductModel>>> CreateProduct(ProductModel product)
        {

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string cmd = "INSERT INTO products (id,name,description,imgUri,categoryid,isDeleted) values('" + Guid.NewGuid() + "','" + product.name + "','" + product.description+ "','" + product.imgUri+ "','" + product.categoryid+ "','" + product.isDeleted + "')";
                    var results = await connection.QueryAsync<UserModel>(cmd);
                    connection.Close();
                    return Ok(true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<ProductModel>>> UpdateProduct()
        {

            try
            {

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<UserModel>>> DeleteProduct()
        {

            try
            {

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
