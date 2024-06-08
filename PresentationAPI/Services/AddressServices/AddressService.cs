using Dapper;
using PresentationAPI.Context;
using PresentationAPI.Dtos.AddressDto;

namespace PresentationAPI.Services.AddressServices
{
    public class AddressService : IAddressService
    {
        private readonly DapperContext _dapperContext;

        public AddressService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateAddressAsync(CreateAddressDto createAddressDto)
        {
            string query = "insert into address (address_detail, phone, email) values (@address_detail, @phone, @email)";
            var parameters = new DynamicParameters();
            parameters.Add("@address_detail", createAddressDto.address_detail);
            parameters.Add("@phone", createAddressDto.phone);
            parameters.Add("@email", createAddressDto.email);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteAddressAsync(int id)
        {
            string query = "delete from address where address_id = @address_id";
            var parameters = new DynamicParameters();
            parameters.Add("@address_id", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetAddressDto> GetAddressAsync(int id)
        {
            string query = "select * from address where address_id = @address_id";
            var parameters = new DynamicParameters();
            parameters.Add("@address_id", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetAddressDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultAddressDto>> ListAddressAsync()
        {
            string query = "select * from address";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultAddressDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateAddressAsync(UpdateAddressDto updateAddressDto)
        {
            string query = "update address set address_detail = @address_detail, phone = @phone, email = @email where address_id = @address_id";
            var parameters = new DynamicParameters();
            parameters.Add("@address_id", updateAddressDto.address_id);
            parameters.Add("@address_detail", updateAddressDto.address_detail);
            parameters.Add("@phone", updateAddressDto.phone);
            parameters.Add("@email", updateAddressDto.email);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
