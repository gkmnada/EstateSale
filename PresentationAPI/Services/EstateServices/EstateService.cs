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
            string query = "insert into estate (title, price, image, city, district, address, description, sales_type, category_id, employee_id, deal_of_day, status) values (@title, @price, @image, @city, @district, @address, @description, @sales_type, @category_id, @employee_id, @deal_of_day, @status)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createEstateDto.title);
            parameters.Add("@price", createEstateDto.price);
            parameters.Add("@image", createEstateDto.image);
            parameters.Add("@city", createEstateDto.city);
            parameters.Add("@district", createEstateDto.district);
            parameters.Add("@address", createEstateDto.address);
            parameters.Add("@description", createEstateDto.description);
            parameters.Add("@sales_type", createEstateDto.sales_type);
            parameters.Add("@deal_of_day", false);
            parameters.Add("@category_id", createEstateDto.category_id);
            parameters.Add("@employee_id", createEstateDto.employee_id);
            parameters.Add("@status", true);
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

        public async Task<List<ResultEstateWithCategoryDto>> ListEstateByEstateAgentAsync(int id)
        {
            string query = "select e.*, c.category_name from estate e join category c on e.category_id = c.category_id where employee_id = @employee_id order by estate_id";
            var parameters = new DynamicParameters();
            parameters.Add("@employee_id", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEstateWithCategoryDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultEstateWithCategoryDto>> ListEstateWithCategoryAsync()
        {
            string query = "select e.*, c.category_name from estate e join category c on e.category_id = c.category_id order by estate_id";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEstateWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultEstateWithCategoryDto>> ListLastEstateAsync()
        {
            string query = "select e.*, c.category_name from estate e join category c on e.category_id = c.category_id order by estate_id desc limit 5";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEstateWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateDealOfDayChangeToFalseAsync(int id)
        {
            string query = "update estate set deal_of_day = @deal_of_day where estate_id = @estate_id";
            var parameters = new DynamicParameters();
            parameters.Add("@deal_of_day", false);
            parameters.Add("@estate_id", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task UpdateDealOfDayChangeToTrueAsync(int id)
        {
            string query = "update estate set deal_of_day = @deal_of_day where estate_id = @estate_id";
            var parameters = new DynamicParameters();
            parameters.Add("@deal_of_day", true);
            parameters.Add("@estate_id", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task UpdateEstateAsync(UpdateEstateDto updateEstateDto)
        {
            string query = "update estate set title = @title, price = @price, image = @image, city = @city, district = @district, address = @address, description = @description, sales_type = @sales_type, category_id = @category_id, employee_id = @employee_id where estate_id = @estate_id";
            var parameters = new DynamicParameters();
            parameters.Add("@title", updateEstateDto.title);
            parameters.Add("@price", updateEstateDto.price);
            parameters.Add("@image", updateEstateDto.image);
            parameters.Add("@city", updateEstateDto.city);
            parameters.Add("@district", updateEstateDto.district);
            parameters.Add("@address", updateEstateDto.address);
            parameters.Add("@description", updateEstateDto.description);
            parameters.Add("@sales_type", updateEstateDto.sales_type);
            parameters.Add("@category_id", updateEstateDto.category_id);
            parameters.Add("@employee_id", updateEstateDto.employee_id);
            parameters.Add("@estate_id", updateEstateDto.estate_id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
