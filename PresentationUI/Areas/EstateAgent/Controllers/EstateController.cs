using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationUI.Dtos.EstateDto;
using PresentationUI.Services;

namespace PresentationUI.Areas.EstateAgent.Controllers
{
    [Authorize]
    [Area("EstateAgent")]
    public class EstateController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILoginService _loginService;

        public EstateController(IHttpClientFactory clientFactory, ILoginService loginService)
        {
            _clientFactory = clientFactory;
            _loginService = loginService;
        }

        public async Task<IActionResult> Index()
        {
            var id = _loginService.GetUserID;

            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7071/api/Estate/ListEstateByEstateAgent?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEstateWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
