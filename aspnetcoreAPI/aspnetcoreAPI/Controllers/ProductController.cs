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
                                                    FROM identification where specificationid = '"+s.Id+"' and productid='"+p.Id+"'");
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
                product.Id = Guid.NewGuid();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string cmd = "INSERT INTO products (id,name,description,imgUri,isDeleted,price) values('" + product.Id + "','" + product.name + "','" + product.description+ "','" + product.imgUri+ "','" + false + "','"+product.price+"')";
                    var results = await connection.QueryAsync<ProductModel>(cmd);
                    connection.Close();
                    if(product.category.Count > 0)
                    {
                        foreach (var category in product.category)
                        {
                            connection.Open();
                            string cmdCatergory = "INSERT INTO category(id,productid,name) values('" + Guid.NewGuid() + "','" + product.Id + "','" + category.name + "')";
                            var categoryResults = await connection.QueryAsync<CategoryModel>(cmdCatergory);
                            connection.Close();
                        }

                    }
                    if(product.specification.Count > 0)
                    {
                        
                        foreach (var specification in product.specification)
                        {
                            var specid = Guid.NewGuid();
                            connection.Open();
                            string cmdSpecification="INSERT INTO specification(id,productid,name) values('"+ specid + "','"+product.Id+"','"+specification.name+"')";
                            var specificationResult = await connection.QueryAsync<SpecificationModel>(cmdSpecification);
                            connection.Close();
                            if(specification.identification.Count > 0)
                            {
                                foreach (var identity in specification.identification)
                                {
                                    connection.Open();
                                    string cmdidentification = "INSERT INTO identification(id,productid,specificationid,name) values('" + Guid.NewGuid() + "','"+product.Id+"','"+ specid + "','"+identity.name+"')";
                                    var identificationResult = await connection.QueryAsync<IdentificationModel>(cmdidentification);

                                    connection.Close();
                                }
                            }
                        }
                    }
                    
                   
                   
                  
                
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
        public async Task<ActionResult<IEnumerable<UserModel>>> DeleteProduct(string id)
        {

            try
            {
     
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string cmd = "UPDATE products set isDeleted='True' where id='"+id+"'";
                    var results = await connection.QueryAsync<ProductModel>(cmd);
                    connection.Close();
  
                    connection.Close();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
