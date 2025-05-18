using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    /// <summary>
    /// Represents a library client with personal information and borrowing history.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Client's last name (family name)
        /// </summary>
        public readonly string familyName;

        /// <summary>
        /// Client's first name
        /// </summary>
        public readonly string firstName;

        /// <summary>
        /// Client's unique identification number (Romanian CNP)
        /// </summary>
        public readonly string CNP;

        /// <summary>
        /// Client's physical address
        /// </summary>
        public readonly string address;

        /// <summary>
        /// List of books currently borrowed by the client
        /// </summary>
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();

        /// <summary>
        /// Complete history of all borrow records for this client
        /// </summary>
        public List<BorrowRecord> BorrowHistory { get; set; } = new List<BorrowRecord>();

        /// <summary>
        /// Initializes a new Client instance with personal information.
        /// </summary>
        /// <param name="_familyName">Client's family name (last name)</param>
        /// <param name="_firstName">Client's first name</param>
        /// <param name="_CNP">Client's unique identification number</param>
        /// <param name="_address">Client's physical address</param>
        public Client(string _familyName, string _firstName, string _CNP, string _address)
        {
            familyName = _familyName;
            firstName = _firstName;
            CNP = _CNP;
            address = _address;
        }
    }
}