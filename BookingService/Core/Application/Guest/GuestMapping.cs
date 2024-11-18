using Application.Guests.Dtos;
using AutoMapper;
using Domain.Guests.Entities;

namespace Application.Guests
{
    public class GuestMapping : Profile
    {
        public GuestMapping()
        {
            CreateMap<GuestDto, Guest>();
        }
    }
}