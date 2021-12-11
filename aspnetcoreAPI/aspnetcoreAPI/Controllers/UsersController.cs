using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aspnetcoreAPI.Context;
using aspnetcoreAPI.Models;
using System.Data;
using System.Data.SqlClient;
using Dapper;


namespace aspnetcoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private string connectionString = "Server=.;Initial Catalog=DpPrintDesign;Integrated Security=true";

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetTodoItems()
        {

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string cmd = string.Format(@"
                               Select 
                               *
                               FROM accounts");

                    var results = await connection.QueryAsync<UserModel>(cmd);
                    connection.Close();
                    var product = results.ToList();
                    return Ok(product);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
       

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUser(string id)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string cmd = string.Format(@"
                               Select 
                               *
                               FROM accounts where id='"+id+"' ");

                    var results = await connection.QueryAsync<UserModel>(cmd);
                    connection.Close();
                    var product = results.ToList();
                    if (product.Count() == 0)
                    {
                        return NotFound();
                    }
                    return Ok(product);

                }

               
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(UserModel user)
        {
            

            try
            {
                if (UserExists(user.Id))
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string cmd = "UPDATE accounts set username='"+user.username+"', password='"+user.password+"' WHERE id='"+user.Id+"' ";
                        var results = await connection.QueryAsync<UserModel>(cmd);
                        connection.Close();
                        return Ok(true);
                    }
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserModel>> PostUser(UserModel user)
        {
            //var acc =  _accountRepository.AddUserAsync(user);

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    
                    string cmd = "INSERT INTO accounts (id,username,password) values('"+Guid.NewGuid()+"','"+user.username+"','"+user.password+"')";
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

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                if (UserExists(id))
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string cmd = "DELETE FROM account WHERE id='" + id + "'";
                        var results = await connection.QueryAsync<UserModel>(cmd);
                        connection.Close();
                        return Ok(true);
                    }
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                throw ex;
            }

           
        }

        private bool UserExists(Guid id)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string cmd = "DELETE FROM account WHERE id='" + id + "'";
                    var results = connection.QueryAsync<UserModel>(cmd);
                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }
    }
}
