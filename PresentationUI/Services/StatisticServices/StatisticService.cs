
namespace PresentationUI.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly HttpClient _httpClient;

        public StatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetActiveCategoryCountAsync()
        {
            var response = await _httpClient.GetAsync("statistic/getactivecategorycount");
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<decimal> GetAverageEstatePriceByRentAsync()
        {
            var response = await _httpClient.GetAsync("statistic/getaverageestatepricebyrent");
            return await response.Content.ReadFromJsonAsync<decimal>();
        }

        public async Task<decimal> GetAverageEstatePriceBySaleAsync()
        {
            var response = await _httpClient.GetAsync("statistic/getaverageestatepricebysale");
            return await response.Content.ReadFromJsonAsync<decimal>();
        }

        public async Task<string> GetCategoryByMaxEstateCountAsync()
        {
            var response = await _httpClient.GetAsync("statistic/getcategorybymaxestatecount");
            return await response.Content.ReadFromJsonAsync<string>();
        }

        public async Task<int> GetCategoryCountAsync()
        {
            var response = await _httpClient.GetAsync("statistic/getcategorycount");
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<string> GetCityByMaxEstateCountAsync()
        {
            var response = await _httpClient.GetAsync("statistic/getcitybymaxestatecount");
            return await response.Content.ReadFromJsonAsync<string>();
        }

        public async Task<int> GetEstateCountAsync()
        {
            var response = await _httpClient.GetAsync("statistic/getestatecount");
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<int> GetInactiveCategoryCountAsync()
        {
            var response = await _httpClient.GetAsync("statistic/getinactivecategorycount");
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<int> GetNewestBuildingYearAsync()
        {
            var response = await _httpClient.GetAsync("statistic/getnewestbuildingyear");
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<int> GetOldestBuildingYearAsync()
        {
            var response = await _httpClient.GetAsync("statistic/getoldestbuildingyear");
            return await response.Content.ReadFromJsonAsync<int>();
        }
    }
}
