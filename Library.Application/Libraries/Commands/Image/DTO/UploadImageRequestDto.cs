using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Commands.Image.DTO
{
    public class UploadImageRequestDto
    {
        public IFormFile File { get; set; }
        public Guid BookId { get; set; }

        /* public void Mapping(Profile profile)
         {
             profile.CreateMap<UploadImageRequestDto, UploadImageCommand>()
                 .ForMember(imageCommand => imageCommand.Image.File,
                     x => x.MapFrom(imageDto => imageDto.File))
                 .ForMember(imageCommand => imageCommand.Image.BookId,
                     x => x.MapFrom(imageDto => imageDto.BookId));
         }*/
    }
}
