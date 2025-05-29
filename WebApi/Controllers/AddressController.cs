using Domain.ApiResponse;
using Domain.DTOs;
using Domain.DTOs.AddressDTOs;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController(IAddressService adServ) : ControllerBase
{
    [HttpGet]
    public async Task<Response<List<GetAddressDTO>>> GetAllAddresssAsync()
    {
        return await adServ.GetAddresssAsync();
    }

    [HttpGet("Get by id")]
    public async Task<Response<GetAddressDTO>> GetAddressByIdAsync(int id)
    {
        return await adServ.GetAddressAsync(id);
    }

    [HttpPost]
    public async Task<Response<string>> CreateAddressAsync(CreateAddressDTO address)
    {
        return await adServ.CreateAddressAsync(address);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateAddressAsync(UpdateAddressDTO address)
    {
        return await adServ.UpdateAddressAsync(address);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteAddressAsync(int id)
    {
        return await adServ.DeleteAddressAsync(id);
    }
}
