using CQRSBookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSBookStore.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Book> Books => Set<Book>();
}