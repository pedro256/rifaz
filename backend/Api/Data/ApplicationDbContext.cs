using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){}
    
    public DbSet<UserEntity> Users { get; set; }
}