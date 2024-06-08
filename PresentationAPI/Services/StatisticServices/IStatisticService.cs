namespace PresentationAPI.Services.StatisticServices
{
    public interface IStatisticService
    {
        Task<int> GetCategoryCountAsync();
        Task<int> GetInactiveCategoryCountAsync();
        Task<int> GetActiveCategoryCountAsync();
        Task<int> GetEstateCountAsync();
        Task<string> GetCategoryByMaxEstateCountAsync();
        Task<decimal> GetAverageEstatePriceByRentAsync();
        Task<decimal> GetAverageEstatePriceBySaleAsync();
        Task<string> GetCityByMaxEstateCountAsync();
        Task<int> GetNewestBuildingYearAsync();
        Task<int> GetOldestBuildingYearAsync();
    }
}
