using Microsoft.EntityFrameworkCore;
using Npgsql;
using PresentationAPI.Entities;
using System.Data;

namespace PresentationAPI.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        public DbSet<Category> category { get; set; }
        public DbSet<Client> client { get; set; }
        public DbSet<Employee> employee { get; set; }
        public DbSet<Estate> estate { get; set; }
        public DbSet<EstateDetail> estate_detail { get; set; }
        public DbSet<Service> service { get; set; }
        public DbSet<About> about { get; set; }
        public DbSet<BottomGrid> bottom_grid { get; set; }
        public DbSet<PopularLocation> popular_location { get; set; }
        public DbSet<Testimonial> testimonial { get; set; }

        public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
    }
}
