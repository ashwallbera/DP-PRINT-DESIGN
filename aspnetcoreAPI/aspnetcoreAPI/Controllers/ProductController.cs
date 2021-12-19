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
                var product = results.ToList();
                foreach (var p in product)
                {
                    //Get Category
                    var cmdcategory = string.Format(@"
                               Select 
                               *
                               FROM category where productid='"+p.Id+"'");
                    var cresults = await connection.QueryAsync<CategoryModel>(cmdcategory);
                    if (cresults != null)
                    {
                        p.category = cresults.ToList();
                    }

                    var cmdspecification = string.Format(@"
                               Select 
                               *
                               FROM specification where productid='" + p.Id + "'");
                    var sresults = await connection.QueryAsync<SpecificationModel>(cmdspecification);
                    if (sresults != null)
                    {
                        p.specification = sresults.ToList();
                        //get Identification of each specs
                        foreach (var s in p.specification)
                        {
                            var cmdidentification = string.Format(@"
                                                    Select
                                                    *
                                                    FROM identification where specificationid = '"+s.Id+"'");
                            var iresults = await connection.QueryAsync<IdentificationModel>(cmdidentification);
                            if (iresults != null)
                            {
                                s.identification = iresults.ToList();
                            }
                        }
                    }
                }
                
                connection.Close();
               
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

                    string cmd = "INSERT INTO products (id,name,description,imgUri,isDeleted) values('" + Guid.NewGuid() + "','" + product.name + "','" + product.description+ "','" + product.imgUri+ "','" + product.isDeleted + "')";
                    var results = await connection.QueryAsync<ProductModel>(cmd);
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
