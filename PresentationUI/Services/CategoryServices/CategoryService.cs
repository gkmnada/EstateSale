using PresentationUI.Dtos.CategoryDto;

namespace PresentationUI.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            await _httpClient.PostAsJsonAsync("category", createCategoryDto);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _httpClient.DeleteAsync("category?id=" + id);
        }

        public async Task<GetCategoryDto> GetCategoryAsync(int id)
        {
            var response = await _httpClient.GetAsync("category/getcategory?id=" + id);
            return await response.Content.ReadFromJsonAsync<GetCategoryDto>();
        }

        public async Task<List<ResultCategoryDto>> ListCategoryAsync()
        {
            var response = await _httpClient.GetAsync("category");
            return await response.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            await _httpClient.PutAsJsonAsync("category", updateCategoryDto);
        }
    }
}
