using Dapper;
using PresentationAPI.Context;
using PresentationAPI.Dtos.ClientDto;

namespace PresentationAPI.Services.ClientServices
{
    public class ClientService : IClientService
    {
        private readonly DapperContext _context;

        public ClientService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateClientAsync(CreateClientDto createClientDto)
        {
            string query = "insert into client (client_name, title, comment, status) values (@client_name, @title, @comment, @status)";
            var parameters = new DynamicParameters();
            parameters.Add("@client_name", createClientDto.client_name);
            parameters.Add("@title", createClientDto.title);
            parameters.Add("@comment", createClientDto.comment);
            parameters.Add("@status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task DeleteClientAsync(int id)
        {
            string query = "delete from client where client_id = @client_id";
            var parameters = new DynamicParameters();
            parameters.Add("@client_id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetClientDto> GetClientAsync(int id)
        {
            string query = "select * from client where client_id = @client_id";
            var parameters = new DynamicParameters();
            parameters.Add("@client_id", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetClientDto>(query, parameters);
                return value;
            }
        }

        public async Task<List<ResultClientDto>> ListClientAsync()
        {
            string query = "select * from client";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultClientDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateClientAsync(UpdateClientDto updateClientDto)
        {
            string query = "update client set client_name = @client_name, title = @title, comment = @comment where client_id = @client_id";
            var parameters = new DynamicParameters();
            parameters.Add("@client_id", updateClientDto.client_id);
            parameters.Add("@client_name", updateClientDto.client_name);
            parameters.Add("@title", updateClientDto.title);
            parameters.Add("@comment", updateClientDto.comment);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
