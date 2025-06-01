using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Commons;
using ViLib;
using PresenterNamespace;

namespace ViLibTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private IModel model;
        private bool addBookResult;

        /// <summary>
        /// this code needs to be executed before every test
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            model = new Model();
            addBookResult = model.AddBook(new Book("B00K", "author", "publisher"));
            Client client = new Client("FamilyName", "FirstName", "0000", "Adress");
            model.AddClient(client);
        }
        /// <summary>
        /// this code needs to be executed after every test
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            model.DeleteBorrowRecord("B00K");
            model.DeleteClient("0000");
            model.DeleteBook("B00K");
        }
        /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
         * 
         *                          BOOK RELATED TESTS
         *
         @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*/
        /// <summary>
        /// checks AddBook happy flow
        /// </summary>
        [TestMethod]
        public void AddABook()
        {
            Assert.IsTrue(addBookResult, "Expected AddBook to return true for an added book.");
        }
        /// <summary>
        /// checks DeleteBook happy flow
        /// </summary>
        [TestMethod]
        public void DeleteABook()
        {
            model.AddBook(new Book("title", "author", "publisher"));
            bool result = model.DeleteBook("title");
            Assert.IsTrue(result, "Expected DeleteBook to return true for a deleted book.");
        }
        /// <summary>
        /// checks whether SearchBook returns a book with given title
        /// </summary>
        [TestMethod]
        public void SearchABook()
        {
            Book book = model.SearchBook("B00K");
            Assert.IsTrue(book.title == "B00K", "Expected SearchBook to return a book with given title.");
        }
        /// <summary>
        /// checks whether SearchBook returns null when searching for an nonexistent book
        /// </summary>
        [TestMethod]
        public void SearchABookThatDoesntExist()
        {
            Book book = model.SearchBook("Russian democracy");
            Assert.IsTrue(book == null, "Expected SearchBookto to return null when searching for an nonexistent book.");
        }
        /// <summary>
        /// checks wherther BookExists finds a book with given title
        /// </summary>
        [TestMethod]
        public void ABookExists()
        {
            bool result = model.BookExists("B00K");
            Assert.IsTrue(result, "Expected BookExists to return true if a book with given title exists");
        }
        /// <summary>
        /// checks whether the app can delete a book that doesnt exist
        /// </summary>
        [TestMethod]
        public void DeleteABookThatDoesntExist()
        {
            bool result = model.DeleteBook("title");
            Assert.IsFalse(result, "Expected DeleteBook to return false for a deleted book.");
        }
        /// <summary>
        /// checks whether GetAllBooks returns a list with all the books in the library
        /// </summary>
        [TestMethod]
        public void GetBookList()
        {
            var list = model.GetAllBooks();
            Assert.IsTrue(list != null, "Expected GetAllBooks to return a list!=null");
        }
        [TestMethod]
        public void BookCount()
        {
            var count = model.BookCount;
            Assert.IsTrue(count == 1,"Expected BookCount to return the number of book in the library.");
        }
        /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
         * 
         *                          BORROW RECORDS RELATED TESTS
         *
         @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*/
        /// <summary>
        /// checks the BorrowBook happy flow
        /// </summary>
        [TestMethod]
        public void BorrowABook()
        {
            bool result = model.BorrowBook("B00K","0000");
            Assert.IsTrue(result, "Expected BorrowBook to return true for a borrowed book.");
        }
        /// <summary>
        /// checks whether the app can return a book that was not borrowed by the specific client
        /// </summary>
        [TestMethod]
        public void ReturnABookUnborrowedByCLient()
        {
            bool result = model.ReturnBook("B00K");
            Assert.IsFalse(result, "Expected ReturnBook to return false for an unborrowed book.");
        }
        /// <summary>
        /// checks ReturnBook happy flow
        /// </summary>
        [TestMethod]
        public void ReturnABook()
        {
            model.BorrowBook("B00K", "0000");
            bool result = model.ReturnBook("B00K");
            Assert.IsTrue(result, "Expected ReturnBook to return true for a returned book");
        }
        /// <summary>
        /// checks DeleteBorrowRecord happy flow
        /// </summary>
        [TestMethod]
        public void DeleteABorrowRecord()
        {
            model.BorrowBook("B00K", "0000");
            bool result = model.DeleteBorrowRecord("B00K");
            Assert.IsTrue(result, "Expected DeleteBorrowRecord to return true for a deleted borrow record.");
        }
        /// <summary>
        /// checks whether GetBorrowHistory returns a list with all the borrow records in the library
        /// </summary>
        [TestMethod]
        public void GetBorrowRecordList()
        {
            var list = model.GetBorrowHistory();
            Assert.IsTrue(list != null, "Expected GetBorrowHistory to return a list != null");
        }
        /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
         * 
         *                          CLIENT RELATED TESTS
         *
         @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*/
        /// <summary>
        /// checks AddClient happy flow
        /// </summary>
        [TestMethod]
        public void AddACLient()
        {
            bool result = model.AddClient(new Client("FAN", "FIN", "CNP", "ADDRESS"));
            model.DeleteClient("CNP");
            Assert.IsTrue(result, "Expected AddClient to return true for an added client.");
        }
        /// <summary>
        /// checks DeleteClient happy flow
        /// </summary>
        [TestMethod]
        public void DeleteAClient()
        {
            model.AddClient(new Client("FAN", "FIN", "CNP", "ADDRESS"));
            bool result = model.DeleteClient("CNP");
            Assert.IsTrue(result, "Expected DeleteClient to return true for a deleted client.");
        }
        /// <summary>
        /// checks DeleteClient happy flow
        /// </summary>
        [TestMethod]
        public void DeleteAClientThatDoesntExist()
        {
            bool result = model.DeleteClient("CNP");
            Assert.IsFalse(result, "Expected DeleteClient to return false for a deleted client.");
        }
        /// <summary>
        /// checks wherther ClientExists finds a client with given cnp
        /// </summary>
        [TestMethod]
        public void AClientExists()
        {
            bool result = model.ClientExists("0000");
            Assert.IsTrue(result, "Expected ClientExists to return true if a client with given cnp exists");
        }
        /// <summary>
        /// checks whether SearchClient returns a client with given CNP
        /// </summary>
        [TestMethod]
        public void SearchAClient()
        {
            Client client = model.SearchClient("0000");
            Assert.IsTrue(client.CNP == "0000", "Expected SearchClient to return a client with given CNP.");
        }
        /// <summary>
        /// checks whether SearchClient returns null when searching for an nonexistent client
        /// </summary>
        [TestMethod]
        public void SearchAClientThatDoesntExist()
        {
            Client client = model.SearchClient("0001");
            Assert.IsTrue(client == null, "Expected SearchClient to return null when searching for an nonexistent client.");
        }
        /// <summary>
        /// checks whether GetAllClients returns a list with all registered clients in the library
        /// </summary>
        [TestMethod]
        public void GetClientList()
        {
            var list = model.GetAllClients();
            Assert.IsTrue(list != null, "Expected GetAllClients to return a list!=null");
        }
    }
}
