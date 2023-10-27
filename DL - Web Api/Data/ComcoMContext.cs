using DL___Web_Api.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace DL___Web_Api.Data
{
    public class ComcoMContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Teams> Teams { get; set; }
       
    }
}
