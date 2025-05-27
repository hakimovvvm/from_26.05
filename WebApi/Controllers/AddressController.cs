using Domain.ApiResponse;
using Domain.DTOs;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController(IAddressService adServ) : ControllerBase
{
    [HttpGet]
    public async Task<Response<List<AddressDTO>>> GetAllAddresssAsync()
    {
        return await adServ.GetAddresssAsync();
    }

    [HttpGet("Get by id")]
    public async Task<Response<AddressDTO?>> GetAddressByIdAsync(int id)
    {
        return await adServ.GetAddressAsync(id);
    }

    [HttpPost]
    public async Task<Response<string>> CreateAddressAsync(AddressDTO address)
    {
        return await adServ.CreateAddressAsync(address);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateAddressAsync(AddressDTO address)
    {
        return await adServ.UpdateAddressAsync(address);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteAddressAsync(int id)
    {
        return await adServ.DeleteAddressAsync(id);
    }
}
