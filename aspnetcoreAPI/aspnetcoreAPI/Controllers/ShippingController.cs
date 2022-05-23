using aspnetcoreAPI.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aspnetcoreAPI.Controllers
{
    [Route("api/shipping")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private string connectionString = "Server=.;Initial Catalog=DpPrintDesign;Integrated Security=true";
        // GET: api/<ShippingController>
        [HttpGet("customerid")]
        public async Task<ActionResult<IEnumerable<ShippingModel>>> Get(Guid customerid)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmd = "SELECT * FROM shipping where isDeleted ='" + false + "' and customerid='"+ customerid + "'";
                var result = await connection.QueryAsync<ShippingModel>(cmd);
                connection.Close();

                foreach (var carts in result)
                {
                    using (var connection7 = new SqlConnection(connectionString))
                    {
                        connection7.Open();
                        string cmd7 = "SELECT * FROM cart where isDeleted='" + true + "'and orderno='"+carts.orderno+"' and customerid='" + customerid + "'";
                        var results7 = await connection7.QueryAsync<CartModel>(cmd7);
                        carts.cart = results7.ToList();
                        connection7.Close();

                        foreach (var c in carts.cart)
                        {
                            Console.WriteLine(c.customerid);
                            using (var connectionx = new SqlConnection(connectionString))
                            {
                                connectionx.Open();

                                string cmdx = string.Format(@"
                               Select 
                               *
                               FROM products where isDeleted='" + false + "' and id='" + c.productId + "'");

                                var results = await connectionx.QueryAsync<ProductModel>(cmdx);
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



                                connectionx.Close();


                            }

                        }
                    }
                }

                    return Ok(result);
            }
            return Ok();
        }

        // GET api/<ShippingController>/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShippingModel>>> GetAllShipping()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmd = "SELECT * FROM shipping where isDeleted ='" + false + "'";
                var result = await connection.QueryAsync<ShippingModel>(cmd);
                connection.Close();
                foreach (var carts in result)
                {
                    using (var connection7 = new SqlConnection(connectionString))
                    {
                        connection7.Open();
                        string cmd7 = "SELECT * FROM cart where isDeleted='" + true + "'and orderno='" + carts.orderno + "' and customerid='" + carts.customerid + "'";
                        var results7 = await connection7.QueryAsync<CartModel>(cmd7);
                        carts.cart = results7.ToList();
                        connection7.Close();

                        foreach (var c in carts.cart)
                        {
                            Console.WriteLine(c.customerid);
                            using (var connectionx = new SqlConnection(connectionString))
                            {
                                connectionx.Open();

                                string cmdx = string.Format(@"
                               Select 
                               *
                               FROM products where isDeleted='" + false + "' and id='" + c.productId + "'");

                                var results = await connectionx.QueryAsync<ProductModel>(cmdx);
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



                                connectionx.Close();


                            }

                        }
                    }
                }
                return Ok(result);
            }
        }

        // POST api/<ShippingController>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<ShippingModel>>> createShipping(ShippingModel model)
        {
            model.orderno = Guid.NewGuid();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmd = "INSERT INTO  shipping(id,customerid,orderno,status,address,fullname,paymentMethod,isDeleted) values('"+model.id+"','"+model.customerid+"','"+model.orderno+"','"+model.status+"','"+model.address+"','"+model.fullname+"','"+model.paymentMethod+"','"+false+"')";
                await connection.QueryAsync<ShippingModel>(cmd);
                connection.Close();

                
            }
            //Update cart
            foreach (CartModel c in model.cart)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string cmd = "UPDATE cart set orderno='"+model.orderno+"',qty='"+c.qty+"',isDeleted='"+true+"' where id='"+c.Id+"' ";
                    await connection.QueryAsync<CartModel>(cmd);
                    connection.Close();
            }
            }
           
            return Ok();
        }

        // PUT api/<ShippingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShippingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
