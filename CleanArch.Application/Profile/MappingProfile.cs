using AutoMapper;
using MyProject.Application.DTO.User;
using MyProject.Domain.Entities;
using System;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, CreateUserRequestDTO>(); // Map Person to PersonDTO
        CreateMap<CreateUserRequestDTO, User>(); // Map PersonDTO t o Person
    }
}
