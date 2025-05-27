using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entites;

namespace Infrastructure.Interfaces;

public interface IAddressService
{
    Task<Response<List<AddressDTO>>> GetAddresssAsync();
    Task<Response<AddressDTO?>> GetAddressAsync(int id);
    Task<Response<string>> CreateAddressAsync(AddressDTO address);
    Task<Response<string>> UpdateAddressAsync(AddressDTO address);
    Task<Response<string>> DeleteAddressAsync(int id);
}
