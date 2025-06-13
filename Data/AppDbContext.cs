using CQRSBookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSBookStore.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Book> Books => Set<Book>();
}