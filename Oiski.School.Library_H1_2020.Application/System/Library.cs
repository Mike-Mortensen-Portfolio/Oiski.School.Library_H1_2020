using System;
using System.Collections.Generic;
using System.Text;

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A formated string containing the name of the library and the current date</returns>
        public string GetData ()
        {
            return $"{Name} - {DateTime.Now.ToShortDateString()}";
        }

        private Library (string _name)
        {
            Name = _name;
        }
    }
}
