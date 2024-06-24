using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.Contact
{
    public class Address : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public Address(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
