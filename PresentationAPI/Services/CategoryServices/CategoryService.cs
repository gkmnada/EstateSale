using Dapper;
using PresentationAPI.Context;
using PresentationAPI.Dtos.CategoryDto;

namespace PresentationAPI.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly DapperContext _dapperContext;

        public CategoryService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            string query = "insert into category (category_name, status) values (@category_name, @status)";
            var parameters = new DynamicParameters();
            parameters.Add("@category_name", createCategoryDto.category_name);
            parameters.Add("@status", createCategoryDto.status);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            string query = "delete from category where category_id = @category_id";
            var parameters = new DynamicParameters();
            parameters.Add("@category_id", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetCategoryDto> GetCategoryAsync(int id)
        {
            string query = "select * from category where category_id = @category_id";
            var parameters = new DynamicParameters();
            parameters.Add("@category_id", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetCategoryDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultCategoryDto>> ListCategoryAsync()
        {
            string query = "select * from category";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            string query = "update category set category_name = @category_name, status = @status where category_id = @category_id";
            var parameters = new DynamicParameters();
            parameters.Add("@category_name", updateCategoryDto.category_name);
            parameters.Add("@status", updateCategoryDto.status);
            parameters.Add("@category_id", updateCategoryDto.category_id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
