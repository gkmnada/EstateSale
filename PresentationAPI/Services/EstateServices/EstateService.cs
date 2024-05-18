using Dapper;
using PresentationAPI.Context;
using PresentationAPI.Dtos.EstateDto;

namespace PresentationAPI.Services.EstateServices
{
    public class EstateService : IEstateService
    {
        private readonly DapperContext _dapperContext;

        public EstateService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateEstateAsync(CreateEstateDto createEstateDto)
        {
            string query = "insert into estate (title, price, image, city, district, address, description, category_id, status) values (@title, @price, @image, @city, @district, @address, @description, @category_id, @status)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createEstateDto.title);
            parameters.Add("@price", createEstateDto.price);
            parameters.Add("@image", createEstateDto.image);
            parameters.Add("@city", createEstateDto.city);
            parameters.Add("@district", createEstateDto.district);
            parameters.Add("@address", createEstateDto.address);
            parameters.Add("@description", createEstateDto.description);
            parameters.Add("@category_id", createEstateDto.category_id);
            parameters.Add("@status", createEstateDto.status);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteEstateAsync(int id)
        {
            string query = "delete from estate where estate_id = @estate_id";
            var parameters = new DynamicParameters();
            parameters.Add("@estate_id", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetEstateDto> GetEstateAsync(int id)
        {
            string query = "select * from estate where estate_id = @estate_id";
            var parameters = new DynamicParameters();
            parameters.Add("@estate_id", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetEstateDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultEstateDto>> ListEstateAsync()
        {
            string query = "select * from estate";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEstateDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultEstateWithCategoryDto>> ListEstateWithCategoryAsync()
        {
            string query = "select e.*, c.category_name from estate e join category c on e.category_id = c.category_id";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEstateWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateEstateAsync(UpdateEstateDto updateEstateDto)
        {
            string query = "update estate set title = @title, price = @price, image = @image, city = @city, district = @district, address = @address, description = @description, category_id = @category_id, status = @status where estate_id = @estate_id";
            var parameters = new DynamicParameters();
            parameters.Add("@title", updateEstateDto.title);
            parameters.Add("@price", updateEstateDto.price);
            parameters.Add("@image", updateEstateDto.image);
            parameters.Add("@city", updateEstateDto.city);
            parameters.Add("@district", updateEstateDto.district);
            parameters.Add("@address", updateEstateDto.address);
            parameters.Add("@description", updateEstateDto.description);
            parameters.Add("@category_id", updateEstateDto.category_id);
            parameters.Add("@status", updateEstateDto.status);
            parameters.Add("@estate_id", updateEstateDto.estate_id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
