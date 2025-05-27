using System.Net;
using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entites;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AddressService(DataContext context) : IAddressService
{
    public async Task<Response<string>> CreateAddressAsync(AddressDTO address)
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
        : new Response<string>(null, "Success");
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
        : new Response<string>(null, "Success");
    }

    public async Task<Response<AddressDTO?>> GetAddressAsync(int id)
    {
        var address = await context.Addresss.FindAsync(id);
        if (address == null)
        {
            return new Response<AddressDTO?>("address not found", HttpStatusCode.NotFound);
        }

        var result = new AddressDTO
        {
            Id = address.Id,
            City = address.City,
            Street = address.Street,
            StudentId = address.StudentId
        };
        return result == null
        ? new Response<AddressDTO?>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<AddressDTO?>(result, "success");
    }

    public async Task<Response<List<AddressDTO>>> GetAddresssAsync()
    {
        var addresss = await context.Addresss.ToListAsync();
        var result = addresss.Select(ad => new AddressDTO
        {
            Id = ad.Id,
            City = ad.City,
            Street = ad.Street,
            StudentId = ad.StudentId
            
        }).ToList();
        return result == null
        ? new Response<List<AddressDTO>>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<List<AddressDTO>>(result, "success");
    }

    public async Task<Response<string>> UpdateAddressAsync(AddressDTO address)
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
        return res == null
        ? new Response<string>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "success");
    }
}