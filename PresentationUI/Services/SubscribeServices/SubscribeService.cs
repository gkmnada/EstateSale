﻿using PresentationUI.Dtos.SubscribeDto;

namespace PresentationUI.Services.SubscribeServices
{
    public class SubscribeService : ISubscribeService
    {
        private readonly HttpClient _httpClient;

        public SubscribeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateSubscribeAsync(CreateSubscribeDto createSubscribeDto)
        {
            await _httpClient.PostAsJsonAsync("subscribe", createSubscribeDto);
        }

        public async Task DeleteSubscribeAsync(int id)
        {
            await _httpClient.DeleteAsync("subscribe?id=" + id);
        }

        public async Task<GetSubscribeDto> GetSubscribeAsync(int id)
        {
            var response = await _httpClient.GetAsync("subscribe/getsubscribe?id=" + id);
            return await response.Content.ReadFromJsonAsync<GetSubscribeDto>();
        }

        public async Task<List<ResultSubscribeDto>> ListSubscribeAsync()
        {
            var response = await _httpClient.GetAsync("subscribe");
            return await response.Content.ReadFromJsonAsync<List<ResultSubscribeDto>>();
        }

        public async Task UpdateSubscribeAsync(UpdateSubscribeDto updateSubscribeDto)
        {
            await _httpClient.PutAsJsonAsync("subscribe", updateSubscribeDto);
        }
    }
}
