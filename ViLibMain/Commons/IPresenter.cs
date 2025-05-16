using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public interface IPresenter
    {
        void AddBook(Book b);
        bool BookExists(string title);
        void Exit();
        Book GetBook(string title);
        void Init();
        void RemoveBook(string title);
        void AddClient(Client c);
        void EditBook(string title, Book b);
        bool ClientExists(string cnp);
        void RemoveClient(string cnp);
        Client GetClient(string cnp);
        bool ReturnBook(string bookTitle);
        string GetBorrowHistory(string bookTitle = null, string clientCNP = null);
        void ShowBookDetails(Book book);
        void ShowAllBooks();
        bool BorrowBook(string bookTitle, string clientCNP);
    }
}
