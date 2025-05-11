using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Commons;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using System.Xml.Linq;

namespace PresenterNamespace
{
    public class Presenter : IPresenter
    {
        public IModel _model;
        public IView _view;
        public Presenter(IView view, IModel model)
        {
            _model = model;
            _view = view;
        }
        public void Init()//trebuie apelata pentru a initializa prezentarea
        {
            if (!_model.BookDataExists())
            {
                _view.Display("Fisierul cu carti nu exista." + Environment.NewLine, "red");
            }
            else
            {
                _model.InitializeData();
                _view.Display("Fisier incarcat: " + _model.BookCount + " carti." + Environment.NewLine, "magenta");
            }
            if (!_model.ClientDataExists())
            {
                _view.Display("Fisierul cu clienti nu exista." + Environment.NewLine, "red");
            }
            else
            {
                _model.InitializeData();
                _view.Display("Fisier incarcat: " + _model.ClientCount + " clienti." + Environment.NewLine, "magenta");
            }
            if (!_model.BorrowHistoryDataExists())
            {
                _view.Display("Fișierul cu istoricul împrumuturilor nu există." + Environment.NewLine, "red");
            }
            else
            {
                _model.InitializeData();
                _view.Display($"Istoric încărcat: {_model.GetBorrowHistory().Count} înregistrări." + Environment.NewLine, "magenta");
            }
        }
        public void Exit()
        {
            if (_model.SaveData())
                _view.Display("Fisierul a fost salvat." + Environment.NewLine, "magenta");
            _view.Display("La revedere.", "default");

            // Check if we're in a Windows Forms environment
            bool isWindowsFormsView =
                Application.OpenForms.Count > 0 ||
                _view is Control;

            if (isWindowsFormsView)
            {
                // Use a Windows Forms timer to delay exit without blocking the UI thread
                Timer exitTimer = new Timer
                {
                    Interval = 1000 // 1 second
                };
                exitTimer.Tick += (sender, e) =>
                {
                    exitTimer.Stop();
                    Environment.Exit(0);
                };
                exitTimer.Start();

                // This allows the UI to show the goodbye message before exiting
                Application.DoEvents();
            }
            else
            {
                // For non-Windows Forms applications, use Thread.Sleep
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }
        public void AddBook(Book b)
        {
            if (!_model.AddBook(b))
            {
                _view.Display($"Cartea {b.title} a fost suprascrisa", "red");
            }
            else
            {
                _view.Display($"Cartea {b.title} a fost adaugata", "blue");
            }
        }
        public bool BookExists(string name)
        {
            return _model.BookExists(name);
        }
        public Book GetBook(string name)
        {
            return _model.SearchBook(name);
        }
        public void RemoveBook(string name)
        {
            if (_model.DeleteBook(name))
            {
                _view.Display($"Cartea a fost stearsa.", "blue");
            }
            else
            {
                _view.Display($"Cartea nu a fost gasita in lista.", "red");
            }
        }
        public bool ClientExists(string CNP)
        {
            return _model.ClientExists(CNP);
        }
        public void AddClient(Client c)
        {
            if (!_model.AddClient(c))
            {
                _view.Display($"Cartea {c.familyName} {c.firstName} a fost suprascris", "red");
            }
            else
            {
                _view.Display($"Clientul {c.familyName} {c.firstName} a fost adaugat", "blue");
            }
        }
        public void RemoveClient(string cnp)
        {
            if (_model.DeleteClient(cnp))
            {
                _view.Display($"Clientul a fost sters.", "blue");
            }
            else
            {
                _view.Display($"Clientul nu a fost gasit in lista.", "red");
            }
        }
        public Client GetClient(string cnp)
        {
            return _model.SearchClient(cnp);
        }
        public bool BorrowBook(string bookTitle, string clientCNP)
        {
            bool success = _model.BorrowBook(bookTitle, clientCNP);
            if (success)
            {
                _view.Display($"Cartea '{bookTitle}' a fost împrumutată cu succes.", "blue");
            }
            else
            {
                _view.Display($"Nu s-a putut împrumuta cartea '{bookTitle}'. Verificați disponibilitatea sau datele clientului.", "red");
            }
            return success;
        }

        public bool ReturnBook(string bookTitle)
        {
            bool success = _model.ReturnBook(bookTitle);
            if (success)
            {
                _view.Display($"Cartea '{bookTitle}' a fost returnată cu succes.", "blue");
            }
            else
            {
                _view.Display($"Nu s-a putut returna cartea '{bookTitle}'. Verificați dacă este împrumutată.", "red");
            }
            return success;
        }

        public string GetBorrowHistory(string bookTitle = null, string clientCNP = null)
        {
            var history = _model.GetBorrowHistory(bookTitle, clientCNP);
            if (history.Count == 0)
                return "Nu există istoric pentru criteriile specificate.";

            var sb = new StringBuilder();
            foreach (var record in history)
            {
                sb.AppendLine($"ID: {record.Id}");
                sb.AppendLine($"Carte: {record.Book.title}");
                sb.AppendLine($"Client: {record.Client.firstName} {record.Client.familyName}");
                sb.AppendLine($"CNP Client: {record.Client.CNP}");
                sb.AppendLine($"Data împrumut: {record.BorrowDate}");
                sb.AppendLine($"Data returnare: {(record.ReturnDate.HasValue ? record.ReturnDate.ToString() : "Încă împrumutată")}");
                sb.AppendLine("---------------------");
            }
            return sb.ToString();
        }
    }
}
