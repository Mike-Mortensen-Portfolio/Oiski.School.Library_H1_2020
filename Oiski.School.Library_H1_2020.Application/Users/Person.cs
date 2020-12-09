using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Library_H1_2020.Application.Users
{
    /// <summary>
    /// Defines the base for all users
    /// </summary>
    public abstract class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Creates a new instance of type <see cref="Person"/> where <paramref name="_name"/> and <paramref name="_email"/> is set
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_email"></param>
        public Person (string _name, string _email)
        {
            Name = _name;
            Email = _email;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A formatted strong containing information about the <see cref="Person"/></returns>
        public override string ToString ()
        {
            return $"Name: {Name}{Environment.NewLine}Email: {Email}";
        }
    }
}
