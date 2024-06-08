using Dapper;
using PresentationAPI.Context;

namespace PresentationAPI.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly DapperContext _context;

        public StatisticService(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> GetActiveCategoryCountAsync()
        {
            string query = "select count(*) from category where status = true";
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<int>(query);
                return value;
            }
        }

        public async Task<decimal> GetAverageEstatePriceByRentAsync()
        {
            string query = "select avg(price) from estate where sales_type = 'Kiralık'";
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<decimal>(query);
                return value;
            }
        }

        public async Task<decimal> GetAverageEstatePriceBySaleAsync()
        {
            string query = "select avg(price) from estate where sales_type = 'Satılık'";
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<decimal>(query);
                return value;
            }
        }

        public Task<string> GetCategoryByMaxEstateCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetCategoryCountAsync()
        {
            string query = "select count(*) from category";
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<int>(query);
                return value;
            }
        }

        public Task<string> GetCityByMaxEstateCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetEstateCountAsync()
        {
            string query = "select count(*) from estate";
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<int>(query);
                return value;
            }
        }

        public async Task<int> GetInactiveCategoryCountAsync()
        {
            string query = "select count(*) from category where status = false";
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<int>(query);
                return value;
            }
        }

        public async Task<int> GetNewestBuildingYearAsync()
        {
            string query = "select min(year) from estate_detail";
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<int>(query);
                return value;
            }
        }

        public async Task<int> GetOldestBuildingYearAsync()
        {
            string query = "select max(year) from estate_detail";
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<int>(query);
                return value;
            }
        }
    }
}
