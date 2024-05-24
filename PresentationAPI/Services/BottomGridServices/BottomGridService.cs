using Dapper;
using PresentationAPI.Context;
using PresentationAPI.Dtos.BottomGridDto;

namespace PresentationAPI.Services.BottomGridServices
{
    public class BottomGridService : IBottomGridService
    {
        private readonly DapperContext _context;

        public BottomGridService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateBottomGridAsync(CreateBottomGridDto createBottomGridDto)
        {
            string query = "insert into bottom_grid (title, descriptioni icon) values (@title, @description, @icon)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createBottomGridDto.title);
            parameters.Add("@description", createBottomGridDto.description);
            parameters.Add("@icon", createBottomGridDto.icon);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteBottomGridAsync(int id)
        {
            string query = "delete from bottom_grid where bottom_grid_id = @bottom_grid_id";
            var parameters = new DynamicParameters();
            parameters.Add("@bottom_grid_id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetBottomGridDto> GetBottomGridAsync(int id)
        {
            string query = "select * from bottom_grid where bottom_grid_id = @bottom_grid_id";
            var parameters = new DynamicParameters();
            parameters.Add("@bottom_grid_id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetBottomGridDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultBottomGridDto>> ListBottomGridAsync()
        {
            string query = "select * from bottom_grid";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultBottomGridDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateBottomGridAsync(UpdateBottomGridDto updateBottomGridDto)
        {
            string query = "update bottom_grid set title = @title, description = @description, icon = @icon where bottom_grid_id = @bottom_grid_id";
            var parameters = new DynamicParameters();
            parameters.Add("@title", updateBottomGridDto.title);
            parameters.Add("@description", updateBottomGridDto.description);
            parameters.Add("@icon", updateBottomGridDto.icon);
            parameters.Add("@bottom_grid_id", updateBottomGridDto.bottom_grid_id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
