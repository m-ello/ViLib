using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commons;
using ViLib;
using PresenterNamespace;
using View;

namespace ViLibMain
{
    static class Program
    {
        static void Main()
        {
            IModel model = new Model();
            IView view = new ConsoleView(model);
            IPresenter presenter = new Presenter(view, model);
            view.SetPresenter(presenter);
            ((ConsoleView)view).Start();
        }
    }

}
