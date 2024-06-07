using Dapper;
using PresentationAPI.Context;
using PresentationAPI.Dtos.ServiceDto;

namespace PresentationAPI.Services.ServiceServices
{
    public class ServiceService : IServiceService
    {
        private readonly DapperContext _context;

        public ServiceService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateServiceAsync(CreateServiceDto createServiceDto)
        {
            string query = "insert into service (service_name, status) values (@service_name, @status)";
            var parameters = new DynamicParameters();
            parameters.Add("@service_name", createServiceDto.service_name);
            parameters.Add("@status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteServiceAsync(int id)
        {
            string query = "delete from service where service_id = @service_id";
            var parameters = new DynamicParameters();
            parameters.Add("@service_id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetServiceDto> GetServiceAsync(int id)
        {
            string query = "select * from service where service_id = @service_id";
            var parameters = new DynamicParameters();
            parameters.Add("@service_id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetServiceDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultServiceDto>> ListServiceAsync()
        {
            string query = "select * from service";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServiceDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateServiceAsync(UpdateServiceDto updateServiceDto)
        {
            string query = "update service set service_name = @service_name where service_id = @service_id";
            var parameters = new DynamicParameters();
            parameters.Add("@service_id", updateServiceDto.service_id);
            parameters.Add("@service_name", updateServiceDto.service_name);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
