using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public virtual Author Author { get; set; }
        public Guid AuthorId { get; set; }
        public bool IsBookInLibrary { get; set; } = true; 
        public Guid? NumberReaderTicket { get; set; }
        public DateTime? TimeOfTake { get; set; }
        public DateTime? TimeOfReturn { get; set; }
        public virtual Image? Image { get; set; }
        public Guid ImageId { get; set; }

    }
}
