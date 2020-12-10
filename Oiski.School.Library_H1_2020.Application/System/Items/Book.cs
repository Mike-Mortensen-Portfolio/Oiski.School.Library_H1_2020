using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Library_H1_2020.Application.System.Items
{
    /// <summary>
    /// Represents a <see cref="Book"/> that can be borrowed
    /// </summary>
    public class Book
    {
        public string Title { get; }
        public string Author { get; }
        /// <summary>
        /// The unique ID for the <see cref="Book"/>
        /// </summary>
        public string ISBNCode { get; }
        public string Category { get; set; } = string.Empty;
        public bool IsBorrowed { get; set; } = false;
        public DateTime DateOfLending { get; set; }

        public string ToFile()
        {
            return $"{Title},{Author},{ISBNCode},{Category},{IsBorrowed},{DateOfLending.ToShortDateString()}";
        }

        /// <summary>
        /// Creates a new instance of type <see cref="Book"/> where <paramref name="_title"/>, <paramref name="_author"/> and <paramref name="_isbnCode"/> is set
        /// </summary>
        /// <param name="_title"></param>
        /// <param name="_author"></param>
        /// <param name="_isbnCode"></param>
        public Book(string _title, string _author, string _isbnCode)
        {
            Title = _title;
            Author = _author;
            ISBNCode = _isbnCode;
        }
    }
}
