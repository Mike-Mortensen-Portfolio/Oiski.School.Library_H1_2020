﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Oiski.School.Library_H1_2020.Application.System.Items;
using Oiski.School.Library_H1_2020.Application.Users;

namespace Oiski.School.Library_H1_2020.Application.System
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
        private readonly string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        /// <summary>
        /// Build Test data
        /// </summary>
        public void BuildTestData()
        {
            for ( int i = 0; i < 10; i++ )
            {
                CreateLoanee($"Loanee {i}", $"Loanee{i}@Test.dk", out Loanee _loanee);
            }

            for ( int i = 0; i < 10; i++ )
            {
                CreateBook($"Book {i}", $"Bailando Jensen", "Nonsense", $"ISBN{i}", out Book _book);
                books.Add(_book);
            }
        }

        /// <summary>
        /// Write all the data in the <see cref="Library"/>s current state to a .txt file
        /// </summary>
        public void DataToFile()
        {
            using ( StreamWriter file = new StreamWriter($"{path}\\LibraryData.txt") )
            {
                file.WriteLine(GetData());
                file.WriteLine("--------------------------------Loanees--------------------------------");

                foreach ( Loanee loanee in loanees )
                {
                    file.WriteLine(loanee.ToFile());
                }

                file.WriteLine("--------------------------------Books--------------------------------");
                foreach ( Book book in books )
                {
                    file.WriteLine(book.ToFile());
                }
            }
        }

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
        public bool CreateLoanee(string _name, string _email, out Loanee _loanee)
        {
            if ( loanees.Find(item => item.Email.ToLower() == _email.ToLower()) == null )
            {
                Loanee loanee = new Loanee(_name, _email);
                loanees.Add(loanee);
                _loanee = loanee;
                return true;
            }

            _loanee = null;
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

        /// <summary>
        /// Create a new <see cref="Book"/> instance where the title, author and isbnCode is set
        /// </summary>
        /// <param name="_title"></param>
        /// <param name="_author"></param>
        /// <param name="_isbnCode"></param>
        /// <param name="_book">The newly created <see cref="Book"/> instance</param>
        /// <returns><see langword="true"/> if the <see cref="Book"/> could be created; Otherwise <see langword="false"/></returns>
        public bool CreateBook(string _title, string _author, string _isbnCode, out Book _book)
        {
            if ( GetBook(_isbnCode) == null )
            {
                _book = new Book(_title, _author, _isbnCode);
                books.Add(_book);
                return true;
            }

            _book = null;
            return false;
        }
        /// <summary>
        /// Create a new <see cref="Book"/> instance where the title, author, category and isbnCode is set
        /// </summary>
        /// <param name="_title"></param>
        /// <param name="_author"></param>
        /// <param name="_category"></param>
        /// <param name="_isbnCode"></param>
        /// <param name="_book">The newly created <see cref="Book"/> instance</param>
        /// <returns><see langword="true"/> if the <see cref="Book"/> could be created; Otherwise <see langword="false"/></returns>
        public bool CreateBook(string _title, string _author, string _category, string _isbnCode, out Book _book)
        {
            if ( CreateBook(_title, _author, _isbnCode, out _book) )
            {
                _book.Category = _category;

                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_isbnCode"></param>
        /// <returns><see langword="true"/> if the <see cref="Book"/> could be removed; Otherwise <see langword="false"/></returns>
        public bool RemoveBook(string _isbnCode)
        {
            Book book = GetBook(_isbnCode);

            if ( book != null )
            {
                return books.Remove(book);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_isbnCode"></param>
        /// <returns><see langword="true"/> if the book could be borrowed; Otherwise <see langword="false"/></returns>
        public bool BorrowBook(Loanee _loanee, string _isbnCode)
        {
            Book book = GetBook(_isbnCode);
            if ( book != null && !book.IsBorrowed )
            {
                _loanee.BorrowedBooks.Add(book);
                book.IsBorrowed = true;
                book.DateOfLending = DateTime.Now;
                return true;
            }

            return false;
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
            Book book = GetBook(_isbnCode);

            if ( book != null && book.IsBorrowed )
            {
                book.IsBorrowed = false;
                book.DateOfLending = new DateTime();

                return true;
            }

            return false;
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
        /// Saves the current state of the <see cref="Library"/> instance.
        /// </summary>
        /// <returns><see langword="true"/> if the state was saved succesfully; Otherwise <see langword="false"/></returns>
        public bool SaveState()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Loads the previous state of the <see cref="Library"/> instance
        /// </summary>
        /// <returns><see langword="true"/> if the state was succesfully loaded; Otherwise <see langword="false"/></returns>
        public bool LoadState()
        {
            throw new NotImplementedException();
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
