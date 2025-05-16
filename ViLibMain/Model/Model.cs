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
using System.Linq;
using System.Text;
using Commons;

namespace ViLib
{
    public class Model : IModel
    {
        private const string _BookFileName = "books.txt";
        private const string _ClientFileName = "clients.txt";
        private const string _BorrowHistoryFileName = "borrow_history.txt";

        private Library _library = new Library();

        private bool _borrowHistoryFileWasModified;
        private bool _bookFileWasModified; // the booklist will be saved in the end only if it was modified
        private bool _clientFileWasModified;
        public int BookCount => _library.Books.Count;
        public int ClientCount => _library.Clients.Count;

        public Model()
        {
            _bookFileWasModified = false;
            _clientFileWasModified = false;
            _borrowHistoryFileWasModified = false;
        }
        public bool BorrowHistoryDataExists()
        {
            if (!File.Exists(_BorrowHistoryFileName))
            {
                _borrowHistoryFileWasModified = true;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks whether the file with the books exists
        /// </summary>
        public bool BookDataExists()
        {
            if (!File.Exists(_BookFileName))
            {
                _bookFileWasModified = true;
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
            // Load books
            if (File.Exists(_BookFileName))
            {
                var sr = new StreamReader(_BookFileName);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    _library.Books.Add(ParseBookLine(line));
                }
                sr.Close();
            }

            // Load clients
            if (File.Exists(_ClientFileName))
            {
                var sr = new StreamReader(_ClientFileName);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    _library.Clients.Add(ParseClientLine(line));
                }
                sr.Close();
            }

            // Load borrow history
            if (File.Exists(_BorrowHistoryFileName))
            {
                var sr = new StreamReader(_BorrowHistoryFileName);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var record = ParseBorrowRecordLine(line, _library.Books,_library.Clients);
                    _library.AllBorrowRecords.Add(record);

                    // Link to book and client
                    var book = _library.Books.FirstOrDefault(b => b.title == record.BookTitle);
                    var client = _library.Clients.FirstOrDefault(c => c.CNP == record.ClientCNP);

                    if (book != null) book.BorrowHistory.Add(record);
                    if (client != null) client.BorrowHistory.Add(record);

                    // Update book availability
                    if (book != null && record.IsActive) book.IsAvailable = false;
                }
                sr.Close();
            }
        }

        /// <summary>
        /// Adds a book to the book list
        /// </summary>
        public bool AddBook(Book book)
        {
            bool overwrite = _library.Books.Any(b => b.title.Trim().ToUpper() == book.title.Trim().ToUpper());
            _library.Books.RemoveAll(b => b.title.Trim().ToUpper() == book.title.Trim().ToUpper());
            _library.Books.Add(book);
            _bookFileWasModified = true;
            return !overwrite;
        }

        /// <summary>
        /// Deletes a book identified by title from the booklist
        /// </summary>
        public bool DeleteBook(string title)
        {
            var book = _library.Books.FirstOrDefault(b => b.title == title);
            if (book != null)
            {
                _library.Books.Remove(book);
                _bookFileWasModified = true;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks whether a book identified by title exists
        /// </summary>
        public bool BookExists(string title)
        {
            return _library.Books.Any(b => b.title == title);
        }

        /// <summary>
        /// Returns a Book object whose title is the string title
        /// </summary>
        public Book SearchBook(string title)
        {
            return _library.Books.FirstOrDefault(b => b.title == title);
        }

        /// <summary>
        /// Returns a string with all the titles of books concatenated
        /// </summary>
        public string ListAllBooks()
        {
            if (_library.Books.Count == 0)
                return string.Empty;

            var sb = new StringBuilder();

            foreach (var book in _library.Books)
            {
                // Include availability status in the output
                string availability = book.IsAvailable ? "(Available)" : "(Borrowed)";
                sb.AppendLine($"{book.title} {availability}");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Get a list of all books (cloned)
        /// </summary>
        /// <returns>List of all books</returns>
        public List<Book> GetAllBooks()
        {
            // Return a new list containing all books from the library
            return new List<Book>(_library.Books);
        }

        /// <summary>
        /// Saves the data only if the book list was modified
        /// </summary>
        /// <returns>Returns true if the new data was saved</returns>
        public bool SaveData()
        {
            bool saved = false;

            if (_bookFileWasModified)
            {
                // Delete the file if it exists
                if (File.Exists(_BookFileName))
                {
                    File.Delete(_BookFileName);
                }

                // Create a new file and write the book data
                var sw = new StreamWriter(_BookFileName);
                foreach (var book in _library.Books)
                {
                    sw.WriteLine($"{book.title}\t{book.author}\t{book.publisher}");
                }
                sw.Close();
                saved = true;
            }

            if (_clientFileWasModified)
            {
                var sw = new StreamWriter(_ClientFileName);
                foreach (var client in _library.Clients)
                {
                    sw.WriteLine($"{client.familyName}\t{client.firstName}\t{client.CNP}\t{client.address}");
                }
                sw.Close();
                saved = true;
            }

            if (_borrowHistoryFileWasModified)
            {
                var sw = new StreamWriter(_BorrowHistoryFileName);
                foreach (var record in _library.AllBorrowRecords)
                {
                    sw.WriteLine($"{record.Id}\t{record.Book.title}\t{record.Client.CNP}\t" +
                                 $"{record.BorrowDate}\t{(record.ReturnDate.HasValue ? record.ReturnDate.ToString() : "")}");
                }
                sw.Close();
                saved = true;
            }

            return saved;
        }

        private static Client ParseClientLine(string line)
        {
            string[] toks = line.Split('\t');
            return new Client(toks[0], toks[1], toks[2], toks[3]);
        }
        private static Book ParseBookLine(string line)
        {
            string[] toks = line.Split('\t');
            return new Book(toks[0], toks[1], toks[2]);
        }
        private BorrowRecord ParseBorrowRecordLine(string line, List<Book> books, List<Client> clients)
        {
            string[] toks = line.Split('\t');

            // Find the actual Book and Client objects from the library
            var book = books.FirstOrDefault(b => b.title == toks[1]);
            var client = clients.FirstOrDefault(c => c.CNP == toks[2]);

            // Handle case where book or client might not be found
            if (book == null || client == null)
            {
                // You might want to log this or handle it differently
                return null;
            }

            return new BorrowRecord
            {
                Id = int.Parse(toks[0]),
                Book = book,  // Assign the Book object
                Client = client,  // Assign the Client object
                BorrowDate = DateTime.Parse(toks[3]),
                ReturnDate = string.IsNullOrEmpty(toks[4]) ? null : (DateTime?)DateTime.Parse(toks[4])
            };
        }
        public bool AddClient(Client client)
        {
            bool overwrite = false;

            for (int i = 0; i < _library.Clients.Count; i++)
            {
                if (_library.Clients[i].CNP == client.CNP)
                {
                    _library.Clients.RemoveAt(i--);
                    overwrite = true;
                }
            }

            // adugarea cartii
            _library.Clients.Add(client);
            _clientFileWasModified = true;
            return !overwrite;
        }
        public bool ClientDataExists()
        {
            if (!File.Exists(_ClientFileName))
            {
                _clientFileWasModified = true;
                return false;
            }
            else
                return true;
        }
        public bool DeleteClient(string cnp)
        {
            for (int i = 0; i < _library.Clients.Count; i++)
            {
                if (_library.Clients[i].CNP == cnp)
                {
                    _library.Clients.RemoveAt(i);
                    _clientFileWasModified = true;
                    return true;
                }
            }

            return false;
        }
        public bool ClientExists(string cnp)
        {
            for (int i = 0; i < _library.Books.Count; i++)
            {
                if (_library.Clients[i].CNP == cnp)
                    return true;
            }

            return false;
        }
        public string ListAllClients()
        {
            if (_library.Clients.Count == 0)
                return string.Empty;

            var sb = new StringBuilder();

            foreach (var client in _library.Clients)
            {
                sb.AppendLine($"{client.firstName} {client.familyName}");
            }

            return sb.ToString();
        }
        public Client SearchClient(string cnp)
        {
            // cauta un client dupa cnp si returneaza obiectul corespunzator
            for (int i = 0; i < _library.Clients.Count; i++)
            {
                if (_library.Clients[i].CNP == cnp)
                    return _library.Clients[i];
            }

            return null;
        }
        public bool BorrowBook(string bookTitle, string clientCNP)
        {
            var book = _library.Books.FirstOrDefault(b => b.title == bookTitle);
            var client = _library.Clients.FirstOrDefault(c => c.CNP == clientCNP);

            if (book == null || client == null || !book.IsAvailable)
                return false;

            try
            {
                _library.BorrowBook(client, book);
                _borrowHistoryFileWasModified = true;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ReturnBook(string bookTitle)
        {
            var book = _library.Books.FirstOrDefault(b => b.title == bookTitle);
            if (book == null) return false;

            var record = _library.AllBorrowRecords.FirstOrDefault(r =>
                r.Book == book && r.IsActive);
            if (record == null) return false;

            try
            {
                _library.ReturnBook(record.Client, book);
                _borrowHistoryFileWasModified = true;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<BorrowRecord> GetBorrowHistory(string bookTitle = null, string clientCNP = null)
        {
            // If both filters are null, return all records
            if (string.IsNullOrEmpty(bookTitle) && string.IsNullOrEmpty(clientCNP))
                return _library.AllBorrowRecords.ToList();

            // Filter by book title if specified
            if (!string.IsNullOrEmpty(bookTitle))
            {
                return _library.AllBorrowRecords
                    .Where(r => r.Book != null && r.Book.title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // Filter by client CNP if specified
            if (!string.IsNullOrEmpty(clientCNP))
            {
                return _library.AllBorrowRecords
                    .Where(r => r.Client != null && r.Client.CNP.Equals(clientCNP, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return new List<BorrowRecord>();
        }
        public List<BorrowRecord> GetActiveBorrows()
        {
            return _library.GetActiveBorrows();
        }

        public List<Book> GetAvailableBooks()
        {
            return _library.GetAvailableBooks();
        }

        public List<Book> GetBorrowedBooksByClient(string clientCNP)
        {
            var client = _library.Clients.FirstOrDefault(c => c.CNP == clientCNP);
            return client?.BorrowedBooks ?? new List<Book>();
        }

    }
}
