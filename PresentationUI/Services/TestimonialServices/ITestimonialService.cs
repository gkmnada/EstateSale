using PresentationUI.Dtos.TestimonialDto;

namespace PresentationUI.Services.TestimonialServices
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> ListTestimonialAsync();
        Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto);
        Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto);
        Task DeleteTestimonialAsync(int id);
        Task<GetTestimonialDto> GetTestimonialAsync(int id);
    }
}
