using Domain.ApiResponse;
using Domain.DTOs;
using Domain.DTOs.AddressDTOs;
using Domain.Entites;

namespace Infrastructure.Interfaces;

public interface IAddressService
{
    Task<Response<List<GetAddressDTO>>> GetAddresssAsync();
    Task<Response<GetAddressDTO>> GetAddressAsync(int id);
    Task<Response<string>> CreateAddressAsync(CreateAddressDTO address);
    Task<Response<string>> UpdateAddressAsync(UpdateAddressDTO address);
    Task<Response<string>> DeleteAddressAsync(int id);
}
