using Microsoft.EntityFrameworkCore;
using aspnetcoreAPI.Models;

namespace aspnetcoreAPI.ApplicationDbContext
{
 
    public class DpPrintDesign : DbContext
    {
        public DpPrintDesign(DbContextOptions<DpPrintDesign> options)
            : base(options)
        {
        }
        public DbSet<TodoItem> TodoItems { get; set; } = null!;
    }
}
/*using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;
    }
}*/