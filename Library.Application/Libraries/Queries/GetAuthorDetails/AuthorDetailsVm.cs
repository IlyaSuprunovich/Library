using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Application.Libraries.Queries.GetLibraryDetails;
using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.GetAuthorDetails
{
    public class AuthorDetailsVm : IMapWith<Author>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country {  get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorDetailsVm>()
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
