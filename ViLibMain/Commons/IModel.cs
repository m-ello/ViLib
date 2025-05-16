using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public interface IModel
    {
        bool AddBook(Book book);
        int BookCount
        {
            get;
        }
        bool BookDataExists();
        bool DeleteBook(string title);
        bool BookExists(string title);
        void InitializeData();
        string ListAllBooks();
        bool SaveData();
        Book SearchBook(string title);

        bool AddClient(Client client);
        int ClientCount
        {
            get;
        }
        bool ClientDataExists();
        bool DeleteClient(string cnp);
        bool ClientExists(string cnp);
        string ListAllClients();
        Client SearchClient(string cnp);
        bool BorrowHistoryDataExists();
        bool BorrowBook(string bookTitle, string clientCNP);
        bool ReturnBook(string bookTitle);
        List<BorrowRecord> GetBorrowHistory(string bookTitle = null, string clientCNP = null);
        List<Book> GetAllBooks();
    }

}
