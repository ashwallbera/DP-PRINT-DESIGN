using aspnetcoreAPI.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace aspnetcoreAPI.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private string connectionString = "Server=.;Initial Catalog=DpPrintDesign;Integrated Security=true";
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartModel>>> getCart(Guid userid)
        {
            try
            {
                using (var connection7 = new SqlConnection(connectionString))
                {
                    connection7.Open();
                    string cmd7 = "SELECT * FROM cart where isDeleted='"+false+"' and customerid='"+userid+"'";
                    var results7 = await connection7.QueryAsync<CartModel>(cmd7);

                    var cart = results7.ToList();
                    connection7.Close();
                    if (results7.ToList().Count > 0)
                    {
                        
                        
                    }

                    foreach (var c in cart)
                    {
                        Console.WriteLine(c.customerid);
                        using (var connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string cmd = string.Format(@"
                               Select 
                               *
                               FROM products where isDeleted='" + false + "' and id='"+c.productId+"'");

                            var results = await connection.QueryAsync<ProductModel>(cmd);
                            var product = results.ToList();
                            foreach (var p in product)
                            {
                                //Get Category
                                var cmdcategory = string.Format(@"
                               Select 
                               *
                               FROM category where productid='" + p.Id + "'");
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
                                                    FROM identification where specificationid = '" + s.Id + "' and productid='" + p.Id + "'");
                                        var iresults = await connection.QueryAsync<IdentificationModel>(cmdidentification);
                                        if (iresults != null)
                                        {
                                            s.identification = iresults.ToList();
                                        }
                                    }
                                }

                                c.product = product[0];
                                
                            }

                            

                            connection.Close();

                           
                        }
                       
                    }
                    return Ok(cart);
                }

              

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex);
            }

        }
        [HttpPost]
        public async Task<ActionResult> addCart(CartModelPost model)
        {
            try
            {
                model.created = DateTime.UtcNow.ToString();
                model.isDeleted = false;
                model.Id = Guid.NewGuid();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string cmd = "INSERT INTO cart(id,productid,specification,price,created,isDeleted,customerid,qty) values('"+Guid.NewGuid()+"','"+model.productId + "','"+model.specification+"','"+model.price+"','"+model.created+"','"+model.isDeleted+"','"+model.customerid+"','"+model.qty+"') ";
                    var results = await connection.QueryAsync<CartModelPost>(cmd);
                    connection.Close();


                }


                    return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCart(CartModelPost model)
        {
            try
            {
                model.isDeleted = false;
                model.Id = Guid.NewGuid();
                using (var connection = new SqlConnection(connectionString))
                {
                  /*  connection.Open();
                    string cmd = "INSERT INTO cart(id,productid,specification,price,created,isDeleted,customerid) values('" + model.Id + "','" + model.productId + "','" + model.specification + "','" + model.price + "','" + model.created + "','" + model.isDeleted + "','" + model.customerid + "') ";
                    var results = await connection.QueryAsync<CartModelPost>(cmd);
                    connection.Close();*/
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
