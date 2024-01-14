using Microsoft.EntityFrameworkCore;
using WatchList_Netflix.Models;

namespace WatchList_Netflix.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Film> Films => Set<Film>();
        public DbSet<User> Users => Set<User>();
    }
}
