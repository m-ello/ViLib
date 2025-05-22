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
    /// <summary>
    /// The Model class implements the IModel interface and serves as the data layer
    /// of the application, managing all data persistence and business logic operations.
    /// </summary>
    public class Model : IModel
    {
        // File names for data persistence
        private const string _BookFileName = "books.txt";
        private const string _ClientFileName = "clients.txt";
        private const string _BorrowHistoryFileName = "borrow_history.txt";

        /// <summary>
        /// Core library data structure
        /// </summary>
        private Library _library = new Library();

        // Flags to track file modifications for efficient saving
        private bool _borrowHistoryFileWasModified;
        private bool _bookFileWasModified;
        private bool _clientFileWasModified;

        /// <summary>
        /// Property exposing book count
        /// </summary>
        public int BookCount => _library.Books.Count;

        /// <summary>
        /// Property exposing client count
        /// </summary>
        public int ClientCount => _library.Clients.Count;

        /// <summary>
        /// Initializes a new instance of the Model class
        /// </summary>
        public Model()
        {
            _bookFileWasModified = false;
            _clientFileWasModified = false;
            _borrowHistoryFileWasModified = false;
        }

        /// <summary>
        /// Checks if the borrow history data file exists
        /// </summary>
        /// <returns>True if file exists, false otherwise</returns>
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
        /// Checks if the book data file exists
        /// </summary>
        /// <returns>True if file exists, false otherwise</returns>
        public bool BookDataExists()
        {
            if (!File.Exists(_BookFileName))
            {
                _bookFileWasModified = true;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Initializes the model by loading all data from files
        /// </summary>
        public void InitializeData()
        {
            // Load books
            if (File.Exists(_BookFileName))
            {
                using (var sr = new StreamReader(_BookFileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        _library.Books.Add(ParseBookLine(line));
                    }
                }
            }

            // Load clients
            if (File.Exists(_ClientFileName))
            {
                using (var sr = new StreamReader(_ClientFileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        _library.Clients.Add(ParseClientLine(line));
                    }
                }
            }

            // Load borrow history
            if (File.Exists(_BorrowHistoryFileName))
            {
                using (var sr = new StreamReader(_BorrowHistoryFileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var record = ParseBorrowRecordLine(line, _library.Books, _library.Clients);
                        if (record != null)
                        {
                            _library.AllBorrowRecords.Add(record);

                            // Link to book and client
                            var book = _library.Books.FirstOrDefault(b => b.title == record.BookTitle);
                            var client = _library.Clients.FirstOrDefault(c => c.CNP == record.ClientCNP);

                            if (book != null) book.BorrowHistory.Add(record);
                            if (client != null) client.BorrowHistory.Add(record);

                            // Update book availability
                            if (book != null && record.IsActive) book.IsAvailable = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Adds a book to the library collection
        /// </summary>
        /// <param name="book">Book to add</param>
        /// <returns>True if book didn't exist before, false if it was overwritten</returns>
        public bool AddBook(Book book)
        {
            bool overwrite = _library.Books.Any(b => b.title.Trim().ToUpper() == book.title.Trim().ToUpper());
            _library.Books.RemoveAll(b => b.title.Trim().ToUpper() == book.title.Trim().ToUpper());
            _library.Books.Add(book);
            _bookFileWasModified = true;
            return !overwrite;
        }

        /// <summary>
        /// Deletes a book by title
        /// </summary>
        /// <param name="title">Title of book to delete</param>
        /// <returns>True if book was found and deleted, false otherwise</returns>
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
        /// Checks if a book exists by title
        /// </summary>
        /// <param name="title">Title to check</param>
        /// <returns>True if book exists, false otherwise</returns>
        public bool BookExists(string title)
        {
            return _library.Books.Any(b => b.title == title);
        }

        /// <summary>
        /// Searches for a book by title
        /// </summary>
        /// <param name="title">Title to search for</param>
        /// <returns>Book object if found, null otherwise</returns>
        public Book SearchBook(string title)
        {
            return _library.Books.FirstOrDefault(b => b.title == title);
        }

        /// <summary>
        /// Lists all books with their availability status
        /// </summary>
        /// <returns>Formatted string of all books</returns>
        public string ListAllBooks()
        {
            if (_library.Books.Count == 0)
                return string.Empty;

            var sb = new StringBuilder();

            foreach (var book in _library.Books)
            {
                string availability = book.IsAvailable ? "(Available)" : "(Borrowed)";
                sb.AppendLine($"{book.title} {availability}");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Gets all books in the library
        /// </summary>
        /// <returns>List of all books</returns>
        public List<Book> GetAllBooks()
        {
            return new List<Book>(_library.Books);
        }

        /// <summary>
        /// Saves all modified data to files
        /// </summary>
        /// <returns>True if any data was saved, false otherwise</returns>
        public bool SaveData()
        {
            bool saved = false;

            // Save books if modified
            if (_bookFileWasModified)
            {
                if (File.Exists(_BookFileName))
                {
                    File.Delete(_BookFileName);
                }

                using (var sw = new StreamWriter(_BookFileName))
                {
                    foreach (var book in _library.Books)
                    {
                        sw.WriteLine($"{book.title}\t{book.author}\t{book.publisher}");
                    }
                }
                saved = true;
            }

            // Save clients if modified
            if (_clientFileWasModified)
            {
                using (var sw = new StreamWriter(_ClientFileName))
                {
                    foreach (var client in _library.Clients)
                    {
                        sw.WriteLine($"{client.familyName}\t{client.firstName}\t{client.CNP}\t{client.address}");
                    }
                }
                saved = true;
            }

            // Save borrow history if modified
            if (_borrowHistoryFileWasModified)
            {
                using (var sw = new StreamWriter(_BorrowHistoryFileName))
                {
                    foreach (var record in _library.AllBorrowRecords)
                    {
                        sw.WriteLine($"{record.Id}\t{record.Book.title}\t{record.Client.CNP}\t" +
                                     $"{record.BorrowDate}\t{(record.ReturnDate.HasValue ? record.ReturnDate.ToString() : "")}");
                    }
                }
                saved = true;
            }

            return saved;
        }

        /// <summary>
        /// Parses a client record from a file line
        /// </summary>
        private static Client ParseClientLine(string line)
        {
            string[] toks = line.Split('\t');
            return new Client(toks[0], toks[1], toks[2], toks[3]);
        }

        /// <summary>
        /// Parses a book record from a file line
        /// </summary>
        private static Book ParseBookLine(string line)
        {
            string[] toks = line.Split('\t');
            return new Book(toks[0], toks[1], toks[2]);
        }

        /// <summary>
        /// Parses a borrow record from a file line
        /// </summary>
        private BorrowRecord ParseBorrowRecordLine(string line, List<Book> books, List<Client> clients)
        {
            string[] toks = line.Split('\t');

            var book = books.FirstOrDefault(b => b.title == toks[1]);
            var client = clients.FirstOrDefault(c => c.CNP == toks[2]);

            if (book == null || client == null)
            {
                return null;
            }

            return new BorrowRecord
            {
                Id = int.Parse(toks[0]),
                Book = book,
                Client = client,
                BorrowDate = DateTime.Parse(toks[3]),
                ReturnDate = string.IsNullOrEmpty(toks[4]) ? null : (DateTime?)DateTime.Parse(toks[4])
            };
        }

        /// <summary>
        /// Adds a client to the library
        /// </summary>
        public bool AddClient(Client client)
        {
            bool overwrite = false;

            // Remove existing client with same CNP if exists
            for (int i = 0; i < _library.Clients.Count; i++)
            {
                if (_library.Clients[i].CNP == client.CNP)
                {
                    _library.Clients.RemoveAt(i--);
                    overwrite = true;
                }
            }

            _library.Clients.Add(client);
            _clientFileWasModified = true;
            return !overwrite;
        }

        /// <summary>
        /// Checks if client data file exists
        /// </summary>
        public bool ClientDataExists()
        {
            if (!File.Exists(_ClientFileName))
            {
                _clientFileWasModified = true;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Deletes a client by CNP
        /// </summary>
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

        /// <summary>
        /// Checks if a client exists by CNP
        /// </summary>
        public bool ClientExists(string cnp)
        {
            return _library.Clients.Any(c => c.CNP == cnp);
        }

        /// <summary>
        /// Lists all clients
        /// </summary>
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

        /// <summary>
        /// Searches for a client by CNP
        /// </summary>
        public Client SearchClient(string cnp)
        {
            return _library.Clients.FirstOrDefault(c => c.CNP == cnp);
        }

        /// <summary>
        /// Processes a book borrowing operation
        /// </summary>
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

        /// <summary>
        /// Processes a book return operation
        /// </summary>
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

        /// <summary>
        /// Gets borrow history with optional filters
        /// </summary>
        public List<BorrowRecord> GetBorrowHistory(string bookTitle = null, string clientCNP = null)
        {
            if (string.IsNullOrEmpty(bookTitle) && string.IsNullOrEmpty(clientCNP))
                return _library.AllBorrowRecords.ToList();

            if (!string.IsNullOrEmpty(bookTitle))
            {
                return _library.AllBorrowRecords
                    .Where(r => r.Book != null && r.Book.title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (!string.IsNullOrEmpty(clientCNP))
            {
                return _library.AllBorrowRecords
                    .Where(r => r.Client != null && r.Client.CNP.Equals(clientCNP, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return new List<BorrowRecord>();
        }

        /// <summary>
        /// Gets all active borrows
        /// </summary>
        public List<BorrowRecord> GetActiveBorrows()
        {
            return _library.GetActiveBorrows();
        }

        /// <summary>
        /// Gets all available books
        /// </summary>
        public List<Book> GetAvailableBooks()
        {
            return _library.GetAvailableBooks();
        }

        /// <summary>
        /// Gets all books borrowed by a specific client
        /// </summary>
        public List<Book> GetBorrowedBooksByClient(string clientCNP)
        {
            var client = _library.Clients.FirstOrDefault(c => c.CNP == clientCNP);
            return client?.BorrowedBooks ?? new List<Book>();
        }
    }
}