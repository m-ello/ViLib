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
        private readonly IModel _model;
        private readonly IView _view;

        public Presenter(IView view, IModel model)
        {
            _model = model;
            _view = view;
        }

        void IPresenter.Init()
        {
            if (!_model.BookDataExists())
            {
                _view.LogStatus("Fisierul cu carti nu exista." + Environment.NewLine, "red");
            }
            else
            {
                _model.InitializeData();
                _view.LogStatus("Fisier incarcat: " + _model.BookCount + " carti." + Environment.NewLine, "magenta");
            }

            if (!_model.ClientDataExists())
            {
                _view.LogStatus("Fisierul cu clienti nu exista." + Environment.NewLine, "red");
            }
            else
            {
                _model.InitializeData();
                _view.LogStatus("Fisier incarcat: " + _model.ClientCount + " clienti." + Environment.NewLine, "magenta");
            }

            if (!_model.BorrowHistoryDataExists())
            {
                _view.LogStatus("Fișierul cu istoricul împrumuturilor nu există." + Environment.NewLine, "red");
            }
            else
            {
                _model.InitializeData();
                _view.LogStatus($"Istoric încărcat: {_model.GetBorrowHistory().Count} înregistrări." + Environment.NewLine, "magenta");
            }

            ((IPresenter)this).ShowAllBooks();
        }

        void IPresenter.Exit()
        {
            if (_model.SaveData())
                _view.LogStatus("Fisierul a fost salvat." + Environment.NewLine, "magenta");
            _view.LogStatus("La revedere.", "default");

            bool isWindowsFormsView =
                Application.OpenForms.Count > 0 ||
                _view is Control;

            if (isWindowsFormsView)
            {
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

                Application.DoEvents();
            }
            else
            {
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }

        bool IPresenter.BookExists(string name)
        {
            return _model.BookExists(name);
        }

        Book IPresenter.GetBook(string name)
        {
            return _model.SearchBook(name);
        }

        void IPresenter.ShowAllBooks()
        {
            _view.ShowBooks(_model.GetAllBooks());
        }

        void IPresenter.RemoveBook(string name)
        {
            if (_model.DeleteBook(name))
            {
                _view.LogStatus($"Cartea a fost stearsa.", "blue");
            }
            else
            {
                _view.LogStatus($"Cartea nu a fost gasita in lista.", "red");
            }
        }

        bool IPresenter.ClientExists(string CNP)
        {
            return _model.ClientExists(CNP);
        }

        void IPresenter.AddClient(Client c)
        {
            if (!_model.AddClient(c))
            {
                _view.LogStatus($"Cartea {c.familyName} {c.firstName} a fost suprascris", "red");
            }
            else
            {
                _view.LogStatus($"Clientul {c.familyName} {c.firstName} a fost adaugat", "blue");
            }
        }

        void IPresenter.RemoveClient(string cnp)
        {
            if (_model.DeleteClient(cnp))
            {
                _view.LogStatus($"Clientul a fost sters.", "blue");
            }
            else
            {
                _view.LogStatus($"Clientul nu a fost gasit in lista.", "red");
            }
        }

        Client IPresenter.GetClient(string cnp)
        {
            return _model.SearchClient(cnp);
        }

        bool IPresenter.BorrowBook(string bookTitle, string clientCNP)
        {
            bool success = _model.BorrowBook(bookTitle, clientCNP);
            if (success)
            {
                _view.LogStatus($"Cartea '{bookTitle}' a fost împrumutată cu succes.", "blue");
            }
            else
            {
                _view.LogStatus($"Nu s-a putut împrumuta cartea '{bookTitle}'. Verificați disponibilitatea sau datele clientului.", "red");
            }
            return success;
        }

        bool IPresenter.ReturnBook(string bookTitle)
        {
            bool success = _model.ReturnBook(bookTitle);
            if (success)
            {
                _view.LogStatus($"Cartea '{bookTitle}' a fost returnată cu succes.", "blue");
            }
            else
            {
                _view.LogStatus($"Nu s-a putut returna cartea '{bookTitle}'. Verificați dacă este împrumutată.", "red");
            }
            return success;
        }

        string IPresenter.GetBorrowHistory(string bookTitle, string clientCNP)
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

        void IPresenter.ShowBookDetails(Book book)
        {
            _view.ShowBookDetails(book);
        }

        void IPresenter.AddBook(Book b)
        {
            bool success = _model.AddBook(b);

            if (success)
            {
                _view.LogStatus($"Cartea \"{b.title}\" a fost adaugata.", "green");
                ((IPresenter)this).ShowAllBooks();
            }
            else
            {
                _view.LogStatus($"Cartea \"{b.title}\" exista deja.", "red");
            }
        }

        void IPresenter.EditBook(string oldTitle, Book updatedBook)
        {
            
            // Check if the book exists
            if (!_model.BookExists(oldTitle))
            {
                _view.LogStatus($"Cartea \"{oldTitle}\" nu exista.", "red");
                return;
            }

            // Update the book in the model
            _model.DeleteBook(oldTitle); // Remove the old book
            bool success = _model.AddBook(updatedBook); // Add the updated book

            // Notify the user of the result
            if (success)
            {
                _view.LogStatus($"Cartea \"{oldTitle}\" a fost actualizata.", "green");
                ((IPresenter)this).ShowAllBooks();
            }
            else
            {
                _view.LogStatus($"Eroare la actualizarea cartii \"{oldTitle}\".", "red");
            }
            
        }
    }
}
