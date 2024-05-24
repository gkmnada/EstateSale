using Dapper;
using PresentationAPI.Context;
using PresentationAPI.Dtos.PopularLocationDto;

namespace PresentationAPI.Services.PopularLocationServices
{
    public class PopularLocationService : IPopularLocationService
    {
        private readonly DapperContext _context;

        public PopularLocationService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreatePopularLocationAsync(CreatePopularLocationDto createPopularLocationDto)
        {
            string query = "insert into popular_location (location_name, image, status) values (@location_name, @image, @status)";
            var parameters = new DynamicParameters();
            parameters.Add("@location_name", createPopularLocationDto.location_name);
            parameters.Add("@image", createPopularLocationDto.image);
            parameters.Add("@status", createPopularLocationDto.status);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeletePopularLocationAsync(int id)
        {
            string query = "delete from popular_location where location_id = @location_id";
            var parameters = new DynamicParameters();
            parameters.Add("@location_id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetPopularLocationDto> GetPopularLocationsAsync(int id)
        {
            string query = "select * from popular_location where location_id = @location_id";
            var parameters = new DynamicParameters();
            parameters.Add("@location_id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetPopularLocationDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultPopularLocationDto>> ListPopularLocationAsync()
        {
            string query = "select * from popular_location";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdatePopularLocationAsync(UpdatePopularLocationDto updatePopularLocationDto)
        {
            string query = "update popular_location set location_name = @location_name, image = @image, status = @status where location_id = @location_id";
            var parameters = new DynamicParameters();
            parameters.Add("@location_id", updatePopularLocationDto.location_id);
            parameters.Add("@location_name", updatePopularLocationDto.location_name);
            parameters.Add("@image", updatePopularLocationDto.image);
            parameters.Add("@status", updatePopularLocationDto.status);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
