using Microsoft.EntityFrameworkCore;
using ProjectAnimesAPI.Models;

namespace ProjectAnimesAPI.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Anime> Animes { get; set; }
        public DbSet<Episode> Episodes { get; set; }
    }
}