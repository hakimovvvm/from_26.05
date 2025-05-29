using System.Net;
using Domain.ApiResponse;
using Domain.DTOs;
using Domain.DTOs.AddressDTOs;
using Domain.Entites;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AddressService(DataContext context) : IAddressService
{
    public async Task<Response<string>> CreateAddressAsync(CreateAddressDTO address)
    {
        var newSt = new Address
        {
            City = address.City,
            Street = address.Street,
            StudentId = address.StudentId
        };
        await context.Addresss.AddAsync(newSt);
        var res = await context.SaveChangesAsync();
        return res == 0
        ? new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null!, "Success");
    }

    public async Task<Response<string>> DeleteAddressAsync(int id)
    {
        var address = await context.Addresss.FindAsync(id);
        if (address == null)
        {
            return new Response<string>("address not found", HttpStatusCode.NotFound);
        }

        context.Addresss.Remove(address);
        var res = await context.SaveChangesAsync();
        return res == 0
        ? new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null!, "Success");
    }

    public async Task<Response<GetAddressDTO>> GetAddressAsync(int id)
    {
        var address = await context.Addresss.FindAsync(id);
        if (address == null)
        {
            return new Response<GetAddressDTO>("address not found", HttpStatusCode.NotFound);
        }

        var result = new GetAddressDTO
        {
            Id = address.Id,
            City = address.City,
            Street = address.Street,
            StudentId = address.StudentId
        };
        return result == null
        ? new Response<GetAddressDTO>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<GetAddressDTO>(result, "success");
    }

    public async Task<Response<List<GetAddressDTO>>> GetAddresssAsync()
    {
        var addresss = await context.Addresss.ToListAsync();
        var result = addresss.Select(ad => new GetAddressDTO
        {
            Id = ad.Id,
            City = ad.City,
            Street = ad.Street,
            StudentId = ad.StudentId

        }).ToList();
        return result == null
        ? new Response<List<GetAddressDTO>>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<List<GetAddressDTO>>(result, "success");
    }

    public async Task<Response<string>> UpdateAddressAsync(UpdateAddressDTO address)
    {
        var ad = await context.Addresss.FindAsync(address.Id);
        if (ad == null)
        {
            return new Response<string>("address not found", HttpStatusCode.NotFound);
        }

        ad.City = address.City;
        ad.Street = address.Street;
        ad.StudentId = address.StudentId;

        var res = await context.SaveChangesAsync();
        return res <= 0
        ? new Response<string>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null!, "success");
    }
}