using Dapper;
using PresentationAPI.Context;
using PresentationAPI.Dtos.SubscribeDto;

namespace PresentationAPI.Services.SubscribeServices
{
    public class SubscribeService : ISubscribeService
    {
        private readonly DapperContext _dapperContext;

        public SubscribeService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateSubscribeAsync(CreateSubscribeDto createSubscribeDto)
        {
            string query = "insert into subscribe (email) values (@email)";
            var parameters = new DynamicParameters();
            parameters.Add("@email", createSubscribeDto.email);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteSubscribeAsync(int id)
        {
            string query = "delete from subscribe where subscribe_id = @subscribe_id";
            var parameters = new DynamicParameters();
            parameters.Add("@subscribe_id", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetSubscribeDto> GetSubscribeAsync(int id)
        {
            string query = "select * from subscribe where subscribe_id = @subscribe_id";
            var parameters = new DynamicParameters();
            parameters.Add("@subscribe_id", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetSubscribeDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultSubscribeDto>> ListSubscribeAsync()
        {
            string query = "select * from subscribe";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultSubscribeDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateSubscribeAsync(UpdateSubscribeDto updateSubscribeDto)
        {
            string query = "update subscribe set email = @email where subscribe_id = @subscribe_id";
            var parameters = new DynamicParameters();
            parameters.Add("@subscribe_id", updateSubscribeDto.subscribe_id);
            parameters.Add("@email", updateSubscribeDto.email);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
