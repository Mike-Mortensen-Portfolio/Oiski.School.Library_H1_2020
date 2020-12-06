using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Library_H1_2020.Users
{
    /// <summary>
    /// Represents a person, who can borrow items
    /// </summary>
    public class Loanee : Person
    {
        public int ID { get; }
        //public List<Books> BorrowedBooks {get;}

        /// <summary>
        /// Represents the ID que for <see cref="Loanee"/>s. This will increment each time a new instance of type <see cref="Loanee"/> is created
        /// </summary>
        public static int IDMod { get; private set; }

        /// <summary>
        /// Create a new instance of type <see cref="Loanee"/> where <paramref name="_name"/> and <paramref name="_email"/> is set
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_email"></param>
        public Loanee (string _name, string _email) : base(_name, _email)
        {
            ID = ++IDMod;
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
