using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commons;
using ViLib;
using PresenterNamespace;
using View;
using System.Windows.Forms;

namespace ViLibMain
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Required for Windows Forms applications
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize MVP components
            IModel model = new Model();
            //IView view = new ConsoleView(model);
            IView view = new FormView(model);
            IPresenter presenter = new Presenter(view, model);

            // Connect view with presenter
            view.SetPresenter(presenter);

            // Run the Windows Forms application with the FormView
            Application.Run((FormView)view);
            //((ConsoleView)view).Start();

        }
    }

}
