using Dapper;
using PresentationAPI.Context;
using PresentationAPI.Dtos.SocialMediaDto;

namespace PresentationAPI.Services.SocialMediaServices
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly DapperContext _dapperContext;

        public SocialMediaService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateSocialMediaAsync(CreateSocialMediaDto createSocialMediaDto)
        {
            string query = "insert into social_media (name, address, icon) values (@name, @address, @icon)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", createSocialMediaDto.name);
            parameters.Add("@address", createSocialMediaDto.address);
            parameters.Add("@icon", createSocialMediaDto.icon);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteSocialMediaAsync(int id)
        {
            string query = "delete from social_media where social_media_id = @social_media_id";
            var parameters = new DynamicParameters();
            parameters.Add("@social_media_id", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetSocialMediaDto> GetSocialMediaAsync(int id)
        {
            string query = "select * from social_media where social_media_id = @social_media_id";
            var parameters = new DynamicParameters();
            parameters.Add("@social_media_id", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetSocialMediaDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultSocialMediaDto>> ListSocialMediaAsync()
        {
            string query = "select * from social_media";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultSocialMediaDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateSocialMediaAsync(UpdateSocialMediaDto updateSocialMediaDto)
        {
            string query = "update social_media set name = @name, address = @address, icon = @icon where social_media_id = @social_media_id";
            var parameters = new DynamicParameters();
            parameters.Add("@name", updateSocialMediaDto.name);
            parameters.Add("@address", updateSocialMediaDto.address);
            parameters.Add("@icon", updateSocialMediaDto.icon);
            parameters.Add("@social_media_id", updateSocialMediaDto.social_media_id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
