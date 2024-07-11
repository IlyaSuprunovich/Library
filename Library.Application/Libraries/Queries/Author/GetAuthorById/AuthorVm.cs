﻿using AutoMapper;
using Library.Application.Common.Mappings;

namespace Library.Application.Libraries.Queries.Author.GetAuthorDetails
{
    public class AuthorVm : IMapWith<Domain.Author>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Author, AuthorVm>()
                .ForMember(authorVm => authorVm.Name,
                    x => x.MapFrom(author => author.Name))
                .ForMember(authorVm => authorVm.Surname,
                    x => x.MapFrom(author => author.Surname))
                .ForMember(authorVm => authorVm.DateOfBirth,
                    x => x.MapFrom(author => author.DateOfBirth))
                .ForMember(authorVm => authorVm.Country,
                    x => x.MapFrom(author => author.Country));
        }
    }
}