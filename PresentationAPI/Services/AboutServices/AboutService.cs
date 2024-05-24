using Dapper;
using PresentationAPI.Context;
using PresentationAPI.Dtos.AboutDto;

namespace PresentationAPI.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly DapperContext _dapperContext;

        public AboutService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            string query = "insert into about (title, subtitle, description1, description2, image, status) values (@title, @subtitle, @description1, @description2, @image, @status)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createAboutDto.title);
            parameters.Add("@subtitle", createAboutDto.subtitle);
            parameters.Add("@description1", createAboutDto.description1);
            parameters.Add("@description2", createAboutDto.description2);
            parameters.Add("@image", createAboutDto.image);
            parameters.Add("@status", createAboutDto.status);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteAboutAsync(int id)
        {
            string query = "delete from about where about_id = @about_id";
            var parameters = new DynamicParameters();
            parameters.Add("@about_id", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetAboutDto> GetAboutAsync(int id)
        {
            string query = "select * from about where about_id = @about_id";
            var parameters = new DynamicParameters();
            parameters.Add("@about_id", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetAboutDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultAboutDto>> ListAboutAsync()
        {
            string query = "select * from about";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultAboutDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            string query = "update about set title = @title, subtitle = @subtitle, description1 = @description1, description2 = @description2, image = @image, status = @status where about_id = @about_id";
            var parameters = new DynamicParameters();
            parameters.Add("@title", updateAboutDto.title);
            parameters.Add("@subtitle", updateAboutDto.subtitle);
            parameters.Add("@description1", updateAboutDto.description1);
            parameters.Add("@description2", updateAboutDto.description2);
            parameters.Add("@image", updateAboutDto.image);
            parameters.Add("@status", updateAboutDto.status);
            parameters.Add("@about_id", updateAboutDto.about_id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
