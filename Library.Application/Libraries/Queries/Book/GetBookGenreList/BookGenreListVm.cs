using Library.Application.Libraries.Queries.Book.GetBookList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.Book.GetBookGenreList
{
    public class BookGenreListVm
    {
        public IList<string> Genres { get; set; }
        public IDictionary<string, IList<BookLookupDto>> BooksByGenre { get; set; }
    }
}
