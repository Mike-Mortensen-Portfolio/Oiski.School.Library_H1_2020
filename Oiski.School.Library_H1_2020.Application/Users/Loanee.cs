using Oiski.School.Library_H1_2020.Application.System.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Library_H1_2020.Application.Users
{
    /// <summary>
    /// Represents a person, who can borrow items
    /// </summary>
    public class Loanee : Person
    {
        public int ID { get; }
        public List<Book> BorrowedBooks { get; } = new List<Book>();

        /// <summary>
        /// Represents the ID que for <see cref="Loanee"/>s. This will increment each time a new instance of type <see cref="Loanee"/> is created
        /// </summary>
        public static int IDMod { get; private set; }

        /// <summary>
        /// Prepares the <see cref="Loanee"/> <see langword="object"/> for file print
        /// </summary>
        /// <returns>A <see langword="string"/> formatted for file storage</returns>
        public string ToFile ()
        {
            string borrowedBooks = string.Empty;

            foreach ( Book book in BorrowedBooks )
            {
                borrowedBooks += $"\t\t{book.ToFile()}";
            }

            return $"{Name}\n{{\n\tID: {ID}\n\tEmail: {Email}\n\tBorrowed Book:\n{borrowedBooks}}}\n";
        }

        /// <summary>
        /// Create a new instance of type <see cref="Loanee"/> where <paramref name="_name"/> and <paramref name="_email"/> is set
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_email"></param>
        public Loanee (string _name, string _email) : base(_name, _email)
        {
            ID = IDMod++;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A Formated string containing information about the <see cref="Loanee"/></returns>
        public override string ToString ()
        {
            return $"{base.ToString()}{Environment.NewLine}{ID}";
        }
    }
}
