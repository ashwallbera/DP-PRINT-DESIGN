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
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string cmd = "SELECT * FROM cart where isDeleted='"+false+"' and customerid='"+userid+"'";
                    var results = await connection.QueryAsync<CartModel>(cmd);

                    var cart = results.ToList();
                    connection.Close();
                    if (results.ToList().Count > 0)
                    {
                        
                        
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
                model.isDeleted = false;
                model.Id = Guid.NewGuid();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string cmd = "INSERT INTO cart(id,productid,specification,price,created,isDeleted,customerid) values('"+model.Id+"','"+model.productId + "','"+model.specification+"','"+model.price+"','"+model.created+"','"+model.isDeleted+"','"+model.customerid+"') ";
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
