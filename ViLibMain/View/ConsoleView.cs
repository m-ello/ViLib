using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static View.Menus;
using Commons;
using System.IO;
using System.Globalization;

namespace View
{

    public class ConsoleView : IView
    {
        public IPresenter _presenter;
        public IModel _model;
        public List<MenuOption> _menuOptions;

        public ConsoleView(IModel model)
        {
            _model = model;
        }
        public void Start()
        {
            _presenter.Init();

            Menus.UserChoice choice = Menus.UserChoice.Undefined;
            Menus.MenuState menuState = Menus.MenuState.Main;

            while (choice != Menus.UserChoice.Exit)
            {
                // preia comanda in functie de starea curenta a meniului
                choice = GetMenuOption(menuState);
                switch (choice)
                {
                    // comenzi
                    case Menus.UserChoice.Info:
                        break;
                    case Menus.UserChoice.RemoveBook:
                        string title = GetBook();
                        RemoveBook(title);
                        break;
                    case Menus.UserChoice.AddBook:
                        Book b = InputBook();
                        _presenter.AddBook(b);
                        break;
                    case Menus.UserChoice.List:
                        ListAll();
                        break;
                    case Menus.UserChoice.Exit:
                        _presenter.Exit();
                        break;

                    // navigare meniuri
                    case Menus.UserChoice.AdminMenu:
                        menuState = Menus.MenuState.Administrator;
                        break;
                    case Menus.UserChoice.PreviousMenu:
                        menuState = Menus.MenuState.Main;
                        break;
                }
            }
        }

        public void Display(string text, string color)
        {
            ConsoleColor c = ConsoleColor.DarkGray;

            switch (color)
            {
                case "default": c = ConsoleColor.White; break;
                case "red": c = ConsoleColor.Red; break;
                case "green": c = ConsoleColor.Green; break;
                case "blue": c = ConsoleColor.Blue; break;
                case "yellow": c = ConsoleColor.Yellow; break;
                case "magenta": c = ConsoleColor.Magenta; break;
            }

            Console.ForegroundColor = c;
            Console.WriteLine(text);
        }

        private Menus.UserChoice GetMenuOption(Menus.MenuState menuType)
        {
            string action = "";

            switch (menuType)
            {
                case Menus.MenuState.Main:
                    Menus.MainMenu(out _menuOptions, out action);
                    break;
                case Menus.MenuState.Administrator:
                    Menus.AdminMenu(out _menuOptions, out action);
                    break;
            }
            Menus.UserChoice choice = Menus.UserChoice.Undefined;
            while (choice == Menus.UserChoice.Undefined)
            {
                Display(action + Environment.NewLine, "yellow");

                for (int i = 0; i < _menuOptions.Count; i++)
                    Display(_menuOptions[i].Number + ". " + _menuOptions[i].Text, "default");

                Console.Write(Environment.NewLine + "Optiunea dumneavoastra: ");
                string userChoiceNumber = Console.ReadLine();
                Console.WriteLine();

                for (int i = 0; i < _menuOptions.Count; i++)
                {
                    if (userChoiceNumber == _menuOptions[i].Number)
                    {
                        choice = _menuOptions[i].Choice;
                        break;
                    }
                }
            }

            return choice;
        }

        public void SetPresenter(IPresenter presenter)
        {
            _presenter = presenter;
        }

        private void ListAll()
        {
            Console.WriteLine(_model.ListAllBooks());
        }
        private Book InputBook()
        {
            string title = "";
            while (title == "")
            {
                Console.Write("Book title:");
                title = Console.ReadLine();
                title = title.Trim();
            }
            string author = "";
            while (author == "")
            {
                Console.Write("Book author:");
                author = Console.ReadLine();
                author = author.Trim();
            }
            string publisher = "";
            while (publisher == "")
            {
                Console.Write("Book publisher:");
                publisher = Console.ReadLine();
                publisher = publisher.Trim();
            }

            return new Book(title, author, publisher);
        }
        private string GetBook()
        {
            return Console.ReadLine() ?? "";
        }

        private void RemoveBook(string title)
        {
            _presenter.RemoveBook(title);
            Display($"Cartea '{title}' a fost stearsa\n", "blue");
        }
    }
}
