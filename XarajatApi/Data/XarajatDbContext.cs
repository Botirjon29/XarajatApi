using Microsoft.EntityFrameworkCore;
using XarajatApi.Entity;

namespace XarajatApi.Data;

public class XarajatDbContext : DbContext
{
	public XarajatDbContext(DbContextOptions options) : base(options)
	{

	}

	public DbSet<User> Users { get; set; }
}
