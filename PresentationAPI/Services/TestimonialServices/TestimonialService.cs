using Dapper;
using PresentationAPI.Context;
using PresentationAPI.Dtos.TestimonialDto;

namespace PresentationAPI.Services.TestimonialServices
{
    public class TestimonialService : ITestimonialService
    {
        private readonly DapperContext _context;

        public TestimonialService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto)
        {
            string query = "insert into testimonial (name, title, comment, status) values (@name, @title, @comment, @status)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", createTestimonialDto.name);
            parameters.Add("@title", createTestimonialDto.title);
            parameters.Add("@comment", createTestimonialDto.comment);
            parameters.Add("@status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteTestimonialAsync(int id)
        {
            string query = "delete from testimonial where testimonial_id = @testimonial_id";
            var parameters = new DynamicParameters();
            parameters.Add("@testimonial_id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetTestimonialDto> GetTestimonialAsync(int id)
        {
            string query = "select * from testimonial where testimonial_id = @testimonial_id";
            var parameters = new DynamicParameters();
            parameters.Add("@testimonial_id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetTestimonialDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultTestimonialDto>> ListTestimonialAsync()
        {
            string query = "select * from testimonial";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTestimonialDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto)
        {
            string query = "update testimonial set name = @name, title = @title, comment = @comment where testimonial_id = @testimonial_id";
            var parameters = new DynamicParameters();
            parameters.Add("@name", updateTestimonialDto.name);
            parameters.Add("@title", updateTestimonialDto.title);
            parameters.Add("@comment", updateTestimonialDto.comment);
            parameters.Add("@testimonial_id", updateTestimonialDto.testimonial_id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
