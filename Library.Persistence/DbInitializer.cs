using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(LibraryDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
