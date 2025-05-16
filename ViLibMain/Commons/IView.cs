using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public interface IView
    {
        void LogStatus(string text, string color);
        void ShowBooks(List<Book> books);
        void ShowClients(List<Client> clients);
        void ShowBorrowHistory(List<BorrowRecord> borrowRecords);
        void ShowBookDetails(Book book);
        void ShowClientDetails(Client client);
        void ShowBorrowRecordDetails(BorrowRecord record);
        void SetPresenter(IPresenter presenter);
    }
}
