using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Library_H1_2020.System.Items
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
        public string Category { get; set; }
        public bool IsBorrowed { get; set; }
        public DateTime DateOfLending { get; set; }
    }
}
