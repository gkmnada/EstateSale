using Dapper;
using PresentationAPI.Context;
using PresentationAPI.Dtos.EmployeeDto;

namespace PresentationAPI.Services.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DapperContext _context;

        public EmployeeService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto)
        {
            string query = "insert into employee (name, title, mail, phone, image, status, app_user_id) values (@name, @title, @mail, @phone, @image, @status, @app_user_id)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", createEmployeeDto.name);
            parameters.Add("@title", createEmployeeDto.title);
            parameters.Add("@mail", createEmployeeDto.mail);
            parameters.Add("@phone", createEmployeeDto.phone);
            parameters.Add("@image", createEmployeeDto.image);
            parameters.Add("@status", true);
            parameters.Add("@app_user_id", createEmployeeDto.app_user_id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            string query = "delete from employee where employee_id = @employee_id";
            var parameters = new DynamicParameters();
            parameters.Add("@employee_id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetEmployeeDto> GetEmployeeAsync(int id)
        {
            string query = "select * from employee where employee_id = @employee_id";
            var parameters = new DynamicParameters();
            parameters.Add("@employee_id", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetEmployeeDto>(query, parameters);
                return value;
            }
        }

        public async Task<List<ResultEmployeeDto>> ListEmployeeAsync()
        {
            string query = "select * from employee";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto)
        {
            string query = "update employee set name = @name, title = @title, mail = @mail, phone = @phone, image = @image, app_user_id = @app_user_id where employee_id = @employee_id";
            var parameters = new DynamicParameters();
            parameters.Add("@name", updateEmployeeDto.name);
            parameters.Add("@title", updateEmployeeDto.title);
            parameters.Add("@mail", updateEmployeeDto.mail);
            parameters.Add("@phone", updateEmployeeDto.phone);
            parameters.Add("@image", updateEmployeeDto.image);
            parameters.Add("@app_user_id", updateEmployeeDto.app_user_id);
            parameters.Add("@employee_id", updateEmployeeDto.employee_id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
