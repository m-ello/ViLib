using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public class Book
    {
        public readonly string author;
        public readonly string title;
        public readonly string publisher;
        public bool IsAvailable;
        public List<BorrowRecord> BorrowHistory { get; set; } = new List<BorrowRecord>();
        public Book(string _title, string _author, string _publisher)
        {
            title = _title;
            author = _author;
            publisher = _publisher;
            IsAvailable = true;
        }
    }
}
