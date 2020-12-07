using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oiski.School.Library_H1_2020.System.Items;
using Oiski.School.Library_H1_2020.Users;

namespace Oiski.School.Library_H1_2020.System
{
    /// <summary>
    /// Defines a library instance that can store and manipulate items
    /// </summary>
    public sealed class Library
    {
        private static Library instance = null;
        public static Library GetLibrary
        {
            get
            {
                if ( instance == null )
                {
                    instance = new Library("Oiski's Library");
                }

                return instance;
            }
        }
        public string Name { get; }
        private readonly List<Loanee> loanees = new List<Loanee>();
        private readonly List<Book> books = new List<Book>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A formated string containing the name of the library and the current date</returns>
        public string GetData()
        {
            return $"{Name} - {DateTime.Now.ToShortDateString()}";
        }

        /// <summary>
        /// Create a new instance of type <see cref="Loanee"/> and adds it to the collection
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_email"></param>
        /// <returns><see langword="true"/> if a <see cref="Loanee"/> with the same <paramref name="_email"/> does <strong>not</strong> already exist; Otherwise <see langword="false"/></returns>
        public bool CreateLoanee(string _name, string _email)
        {
            if ( loanees.Find(item => item.Email.ToLower() == _email.ToLower()) != null )
            {
                loanees.Add(new Loanee(_name, _email));
                return true;
            }

            return false;
        }

        /// <summary>
        /// Remove a <see cref="Loanee"/> from the collection, based on <paramref name="_id"/>
        /// </summary>
        /// <param name="_id"></param>
        /// <returns><see langword="true"/> if the <see cref="Loanee"/> could be removed; Otherwise <see langword="false"/></returns>
        public bool RemoveLoanee(int _id)
        {
            Loanee loanee = loanees.Find(item => item.ID == _id);
            if ( loanee != null )
            {
                loanees.Remove(loanee);
                return true;
            }

            return false;
        }
        /// <summary>
        /// Remove a <see cref="Loanee"/>, from the collection based on <paramref name="_email"/>
        /// </summary>
        /// <param name="_id"></param>
        /// <returns><see langword="true"/> if the <see cref="Loanee"/> could be removed; Otherwise <see langword="false"/></returns>
        public bool RemoveLoanee(string _email)
        {
            Loanee loanee = loanees.Find(item => item.Email.ToLower() == _email.ToLower());
            if ( loanee != null )
            {
                loanees.Remove(loanee);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Searches the collection for a <see cref="Loanee"/> based on <paramref name="_id"/>
        /// </summary>
        /// <param name="_id"></param>
        /// <returns>The first occurrence that matches the <paramref name="_id"/></returns>
        public Loanee GetLoanee(int _id)
        {
            return loanees.Find(item => item.ID == _id);
        }
        /// <summary>
        /// Searches the collection for a <see cref="Loanee"/> based on <paramref name="_email"/>
        /// </summary>
        /// <param name="_email"></param>
        /// <returns>The first occurrence that matches the <paramref name="_email"/></returns>
        public Loanee GetLoanee(string _email)
        {
            return loanees.Find(item => item.Email.ToLower() == _email.ToLower());
        }

        public bool CreateBook(string _title, string _author, string _isbnCode, out Book _book)
        {
            if ( GetBook(_isbnCode) != null )
            {
                books.Add(new Book(_title, _author, _isbnCode));
                return true;
            }

            return false;
        }
        public bool CreateBook(string _title, string _author, string _category, string _isbnCode, out Book _book)
        {
            if ( CreateBook(_title, _author, _isbnCode, out _book) )
            {
                _book.Category = _category;

                return true;
            }

            return false;
        }

        public bool RemoveBook(string _isbnCode)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_isbnCode"></param>
        /// <returns><see langword="true"/> if the book could be borrowed; Otherwise <see langword="false"/></returns>
        public bool BorrowBook(string _isbnCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_isbnCode"></param>
        /// <returns><see langword="true"/> if the book could be reserved; Otherwise <see langword="false"/></returns>
        public bool ReserveBook(string _isbnCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_isbnCode"></param>
        /// <returns><see langword="true"/> if the book could be returned; Otherwise <see langword="false"/></returns>
        public bool ReturnBook(string _isbnCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Searches the collection for a specific <see cref="CreateBook"/> with the matching <paramref name="_isbnCode"/>
        /// </summary>
        /// <param name="_isbnCode"></param>
        /// <returns>The first occurrence of a <see cref="CreateBook"/> that matches <paramref name="_isbnCode"/></returns>
        public Book GetBook(string _isbnCode)
        {
            return books.Find(item => item.ISBNCode == _isbnCode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_title"></param>
        /// <returns>A <see cref="IReadOnlyList{T}"/> that contains all <see cref="CreateBook"/>s where the <see cref="Book.Title"/> contains <paramref name="_title"/></returns>
        public IReadOnlyList<Book> GetBooksByTitle(string _title)
        {
            return books.Where(item => item.Title.Contains(_title)) as IReadOnlyList<Book>;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_category"></param>
        /// <returns>A <see cref="IReadOnlyList{T}"/> that contains all <see cref="CreateBook"/>s where the <see cref="Book.Category"/> contains <paramref name="_category"/></returns>
        public IReadOnlyList<Book> GetBooksByCategory(string _category)
        {
            return books.Where(item => item.Category.Contains(_category)) as IReadOnlyList<Book>;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_author"></param>
        /// <returns>A <see cref="IReadOnlyList{T}"/> that contains all <see cref="CreateBook"/>s where the <see cref="Book.Author"/> contains <paramref name="_author"/></returns>
        public IReadOnlyList<Book> GetBooksByAuthor(string _author)
        {
            return books.Where(item => item.Author.Contains(_author)) as IReadOnlyList<Book>;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_dateOfLending"></param>
        /// <returns>A <see cref="IReadOnlyList{T}"/> that contains all <see cref="CreateBook"/>s where the <see cref="Book.DateOfLending"/> matches <paramref name="_dateOfLending"/></returns>
        public IReadOnlyList<Book> GetBooksByDate(DateTime _dateOfLending)
        {
            return books.Where(item => item.DateOfLending == _dateOfLending) as IReadOnlyList<Book>;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_isBorrowed"></param>
        /// <returns>A <see cref="IReadOnlyList{T}"/> that contains all <see cref="CreateBook"/>s where the <see cref="Book.IsBorrowed"/> matches <paramref name="_isBorrowed"/></returns>
        public IReadOnlyList<Book> GetBooksByStatus(bool _isBorrowed)
        {
            return books.Where(item => item.IsBorrowed == _isBorrowed) as IReadOnlyList<Book>;
        }

        /// <summary>
        /// Create a new instance of type <see cref="Library"/> where <paramref name="_name"/> is set
        /// </summary>
        /// <param name="_name"></param>
        private Library(string _name)
        {
            Name = _name;
        }
    }
}
