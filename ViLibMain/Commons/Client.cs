using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public class Client
    {
        public readonly string familyName;
        public readonly string firstName;
        public readonly string CNP;
        public readonly string address;
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();
        public List<BorrowRecord> BorrowHistory { get; set; } = new List<BorrowRecord>();

        public Client(string _familyName, string _firstName, string _CNP, string _address)
        {
            familyName = _familyName;
            firstName = _firstName;
            CNP = _CNP;
            address = _address;
        }
    }
}
