using Library.Application.Libraries.Queries.GetBookList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.GetAuthorList
{
    public class AuthorListVm
    {
        public IList<AuthorLookupDto> Authors { get; set; }
    }
}
