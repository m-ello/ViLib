using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public class BorrowRecord
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public Client Client { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsActive => ReturnDate == null;

        public string BookTitle => Book?.title;
        public string ClientCNP => Client?.CNP;
    }
}
