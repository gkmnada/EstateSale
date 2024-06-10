using Dapper;
using PresentationAPI.Context;
using PresentationAPI.Dtos.ContactDto;

namespace PresentationAPI.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly DapperContext _dapperContext;

        public ContactService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            string query = "insert into contact (name, email, message, created_at) values (@name, @email, @message, @created_at)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", createContactDto.name);
            parameters.Add("@email", createContactDto.email);
            parameters.Add("@message", createContactDto.message);
            parameters.Add("@created_at", DateTime.Now);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteContactAsync(int id)
        {
            string query = "delete from contact where contact_id = @contact_id";
            var parameters = new DynamicParameters();
            parameters.Add("@contact_id", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetContactDto> GetContactAsync(int id)
        {
            string query = "select * from contact where contact_id = @contact_id";
            var parameters = new DynamicParameters();
            parameters.Add("@contact_id", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetContactDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultContactDto>> ListContactAsync()
        {
            string query = "select * from contact";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultContactDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            string query = "update contact set name = @name, email = @email, message = @message where contact_id = @contact_id";
            var parameters = new DynamicParameters();
            parameters.Add("@name", updateContactDto.name);
            parameters.Add("@email", updateContactDto.email);
            parameters.Add("@message", updateContactDto.message);
            parameters.Add("@contact_id", updateContactDto.contact_id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
