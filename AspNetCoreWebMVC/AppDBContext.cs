using AspNetCoreWebMVC.Models;
using Microsoft.EntityFrameworkCore;
namespace AspNetCoreWebMVC
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
    }
}
