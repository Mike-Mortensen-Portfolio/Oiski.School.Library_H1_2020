using System;
using System.Collections.Generic;
using System.Text;
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A formated string containing the name of the library and the current date</returns>
        public string GetData ()
        {
            return $"{Name} - {DateTime.Now.ToShortDateString()}";
        }

        /// <summary>
        /// Create a new instance of type <see cref="Loanee"/> and adds it to the collection
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_email"></param>
        /// <returns><see langword="true"/> if a <see cref="Loanee"/> with the same <paramref name="_email"/> does <strong>not</strong> already exist; Otherwise <see langword="false"/></returns>
        public bool CreateLoanee (string _name, string _email)
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
        public bool RemoveLoanee (int _id)
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
        public bool RemoveLoanee (string _email)
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
        public Loanee GetLoanee (int _id)
        {
            return loanees.Find(item => item.ID == _id);
        }
        /// <summary>
        /// Searches the collection for a <see cref="Loanee"/> based on <paramref name="_email"/>
        /// </summary>
        /// <param name="_email"></param>
        /// <returns>The first occurrence that matches the <paramref name="_email"/></returns>
        public Loanee GetLoanee (string _email)
        {
            return loanees.Find(item => item.Email.ToLower() == _email.ToLower());
        }

        /// <summary>
        /// Create a new instance of type <see cref="Library"/> where <paramref name="_name"/> is set
        /// </summary>
        /// <param name="_name"></param>
        private Library (string _name)
        {
            Name = _name;
        }
    }
}
