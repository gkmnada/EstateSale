using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationUI.Dtos.AddressDto;
using PresentationUI.Services.AddressServices;

namespace PresentationUI.ViewComponents.Contact
{
    public class Address : ViewComponent
    {
        private readonly IAddressService _addressService;

        public Address(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _addressService.ListAddressAsync();
            return View(values);
        }
    }
}
