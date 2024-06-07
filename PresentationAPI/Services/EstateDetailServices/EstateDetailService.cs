using Dapper;
using PresentationAPI.Context;
using PresentationAPI.Dtos.EstateDetailDto;

namespace PresentationAPI.Services.EstateDetailServices
{
    public class EstateDetailService : IEstateDetailService
    {
        private readonly DapperContext _context;

        public async Task CreateEstateDetailAsync(CreateEstateDetailDto createEstateDetailDto)
        {
            string query = "insert into estate_detail (estate_size, bedroom, bathroom, room, garage_size, year, price, location, estate_id) values (@estate_size, @bedroom, @bathroom, @room, @garage_size, @year, @price, @location, @estate_id)";
            var parameters = new DynamicParameters();
            parameters.Add("@estate_size", createEstateDetailDto.estate_size);
            parameters.Add("@bedroom", createEstateDetailDto.bedroom);
            parameters.Add("@bathroom", createEstateDetailDto.bathroom);
            parameters.Add("@room", createEstateDetailDto.room);
            parameters.Add("@garage_size", createEstateDetailDto.garage_size);
            parameters.Add("@year", createEstateDetailDto.year);
            parameters.Add("@price", createEstateDetailDto.price);
            parameters.Add("@location", createEstateDetailDto.location);
            parameters.Add("@estate_id", createEstateDetailDto.estate_id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteEstateDetailAsync(int id)
        {
            string query = "delete from estate_detail where estate_detail_id = @estate_detail_id";
            var parameters = new DynamicParameters();
            parameters.Add("@estate_detail_id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetEstateDetailDto> GetEstateDetailAsync(int id)
        {
            string query = "select * from estate_detail where estate_detail_id = @estate_detail_id";
            var parameters = new DynamicParameters();
            parameters.Add("@estate_detail_id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetEstateDetailDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultEstateDetailDto>> ListEstateDetailAsync()
        {
            string query = "select * from estate_detail";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEstateDetailDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateEstateDetailAsync(UpdateEstateDetailDto updateEstateDetailDto)
        {
            string query = "update estate_detail set estate_size = @estate_size, bedroom = @bedroom, bathroom = @bathroom, room = @room, garage_size = @garage_size, year = @year, price = @price, location = @location, estate_id = @estate_id where estate_detail_id = @estate_detail_id";
            var parameters = new DynamicParameters();
            parameters.Add("@estate_size", updateEstateDetailDto.estate_size);
            parameters.Add("@bedroom", updateEstateDetailDto.bedroom);
            parameters.Add("@bathroom", updateEstateDetailDto.bathroom);
            parameters.Add("@room", updateEstateDetailDto.room);
            parameters.Add("@garage_size", updateEstateDetailDto.garage_size);
            parameters.Add("@year", updateEstateDetailDto.year);
            parameters.Add("@price", updateEstateDetailDto.price);
            parameters.Add("@location", updateEstateDetailDto.location);
            parameters.Add("@estate_id", updateEstateDetailDto.estate_id);
            parameters.Add("@estate_detail_id", updateEstateDetailDto.estate_detail_id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
