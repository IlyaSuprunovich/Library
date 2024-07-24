using Library.Application.Libraries.Queries.Book.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.LibraryUser.DTO
{
    public class TakenBooksListResponseDto
    {
        public IList<BookResponseDto> TakenBooks { get; set; }
    }
}
