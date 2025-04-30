using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public class Menus
    {
        // structuri de date

        public enum UserChoice { AdminMenu, PreviousMenu, Info, AddBook, RemoveBook, Exit, List, Undefined };
        public enum MenuState { Main, Administrator };

        public struct MenuOption
        {
            // structura pentru construirea dinamica a unui meniu
            // reprezinta o optiune intr-un meniu

            public readonly string Number;
            public readonly string Text;
            public readonly UserChoice Choice;

            public MenuOption(string number, string text, UserChoice choice)
            {
                Number = number;
                Text = text;
                Choice = choice;
            }
        };

        // metodele de mai jos trebuie plasate in clasele potrivite
        public static void MainMenu(out List<MenuOption> options, out string action)
        {
            action = "Selectati rolul";
            options = new List<MenuOption>(2);
            options.Add(new MenuOption("1", "Administrator", UserChoice.AdminMenu));
            options.Add(new MenuOption("2", "Iesire", UserChoice.Exit));
        }

        public static void AdminMenu(out List<MenuOption> options, out string action)
        {
            action = "Selectati actiunea dorita";
            options = new List<MenuOption>(5);
            options.Add(new MenuOption("1", "Informatii despre o carte", UserChoice.Info));
            options.Add(new MenuOption("2", "Afisarea tuturor cartilor", UserChoice.List));
            options.Add(new MenuOption("3", "Introducerea unei carti noi", UserChoice.AddBook));
            options.Add(new MenuOption("4", "Stergerea unei carti", UserChoice.RemoveBook));
            options.Add(new MenuOption("5", "Iesire", UserChoice.Exit));
        }

    }
}
