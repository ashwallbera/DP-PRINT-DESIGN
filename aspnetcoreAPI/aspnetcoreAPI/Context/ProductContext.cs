using aspnetcoreAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace aspnetcoreAPI.Context
{
    public class ProductContext: DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
          : base(options)
        {
        }

        public DbSet<ProductContext> User { get; set; }
    }
}
