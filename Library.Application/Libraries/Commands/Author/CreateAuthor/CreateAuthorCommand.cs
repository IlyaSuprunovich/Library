﻿using Library.Application.Libraries.Commands.Author.DTO;
using MediatR;

namespace Library.Application.Libraries.Commands.Author.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<Guid>
    {
        public AuthorRequestDto Author { get; set; }
    }
}
