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
            if (!_model.DataExists())
            {
                _view.Display("Fisierul cu carti nu exista." + Environment.NewLine, "red");
            }
            else
            {
                _model.InitializeData();
                _view.Display("Fisier incarcat: " + _model.BookCount + " carti." + Environment.NewLine, "magenta");
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
            if (!_model.Add(b))
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
            return _model.Exists(name);
        }
        public Book GetBook(string name)
        {
            return _model.Search(name);
        }
        public void RemoveBook(string name)
        {
            if (_model.Delete(name))
            {
                _view.Display($"Cartea a fost stearsa.", "blue");
            }
            else
            {
                _view.Display($"Cartea nu a fost gasita in lista.", "red");
            }
        }
    }
}
