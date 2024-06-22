using AutoMapper;
using Library.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.Image
{
    public class GetImageByIdQueryHandler : IRequestHandler<GetImageByIdQuery, Domain.Image>
    {
        private readonly ILibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public GetImageByIdQueryHandler(ILibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        public async Task<Domain.Image> Handle(GetImageByIdQuery request, CancellationToken cancellationToken)
        {
            return await _libraryDbContext.Images.FindAsync(request.Id);
        }
    }

}
