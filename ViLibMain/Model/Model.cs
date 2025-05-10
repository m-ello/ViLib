/**************************************************************************
 *                                                                        *
 *  File:        Model.cs                                                 *
 *  Copyright:   (c) 2008-2024, Florin Leon                               *
 *  E-mail:      florin.leon@academic.tuiasi.ro                           *
 *  Website:     http://florinleon.byethost24.com/lab_ip.html             *
 *  Description: TransportInfo application with MVC architecture.         *
 *               Model class. (Software Engineering lab 6)                *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.IO;
using System.Text;
using Commons;

namespace ViLib
{
    public class Model : IModel
    {
        private const string _BookFileName = "books.txt";
        private List<Book> _bookList;
        private bool _wasModified; // the booklist will be saved in the end only if it was modified

        public int BookCount => _bookList.Count;

        public Model()
        {
            _bookList = new List<Book>();
            _wasModified = false;
        }

        /// <summary>
        /// Checks whether the file with the books exists
        /// </summary>
        public bool DataExists()
        {
            if (!File.Exists(_BookFileName))
            {
                _wasModified = true;
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Reads the books from the file
        /// </summary>
        public void InitializeData()
        {
            var sr = new StreamReader(_BookFileName);
            string line;
            while ((line = sr.ReadLine()) != null)
                _bookList.Add(ParseBookLine(line));
            sr.Close();
        }

        /// <summary>
        /// Adds a book to the book list
        /// </summary>
        public bool Add(Book book)
        {
            // daca o carte cu acelasi title exista deja, el va fi sters
            bool overwrite = false;

            for (int i = 0; i < _bookList.Count; i++)
            {
                if (_bookList[i].title.Trim().ToUpper() == book.title.Trim().ToUpper())
                {
                    _bookList.RemoveAt(i--);
                    overwrite = true;
                }
            }

            // adugarea cartii
            _bookList.Add(book);
            _wasModified = true;
            return !overwrite;
        }

        /// <summary>
        /// Deletes a book identified by title from the booklist
        /// </summary>
        public bool Delete(string title)
        {
            for (int i = 0; i < _bookList.Count; i++)
            {
                if (_bookList[i].title == title)
                {
                    _bookList.RemoveAt(i);
                    _wasModified = true;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether a book identified by title exists
        /// </summary>
        public bool Exists(string title)
        {
            for (int i = 0; i < _bookList.Count; i++)
            {
                if (_bookList[i].title == title)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Returns a Book object whose title is the string title
        /// </summary>
        public Book Search(string title)
        {
            // cauta p carte dupa titlu si returneaza obiectul corespunzator
            for (int i = 0; i < _bookList.Count; i++)
            {
                if (_bookList[i].title == title)
                    return _bookList[i];
            }

            return null;
        }

        /// <summary>
        /// Returns a string with all the titles of books concatenated
        /// </summary>
        public string ListAll()
        {
            if (_bookList.Count == 0)
                return string.Empty;

            var sb = new StringBuilder();
            sb.Append(_bookList[0].title);

            for (int i = 1; i < _bookList.Count; i++)
            {
                sb.Append(", ");
                sb.Append(_bookList[i].title);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Saves the data only if the book list was modified
        /// </summary>
        /// <returns>Returns true if the new data was saved</returns>
        public bool SaveData()
        {
            if (_wasModified)
            {
                var sw = new StreamWriter(_BookFileName);

                for (int i = 0; i < _bookList.Count; i++)
                {
                    Book b = _bookList[i];
                    sw.WriteLine(b.title + "\t" + b.author + "\t" + b.publisher);
                }

                sw.Close();
                return true;
            }
            else
                return false;
        }

        private static Book ParseBookLine(string line)
        {
            // citeste informatiile unei carti de pe o linie din fisier

            string[] toks = line.Split('\t');

            Book book = new Book(toks[0], toks[1], toks[2]);
            return book;
        }
    }
}
