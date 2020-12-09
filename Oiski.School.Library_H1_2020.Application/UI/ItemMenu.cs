using Oiski.ConsoleTech.Engine;
using Oiski.ConsoleTech.Engine.Color.Controls;
using Oiski.School.Library_H1_2020.Application.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Library_H1_2020.Application.UI
{
    /// <summary>
    /// Defines an <see langword="abstract"/> base class for all menues that should target a specific item
    /// </summary>
    public abstract class ItemMenu<IDType> : MasterMenu
    {
        public IDType CurrentItemID { get; set; }

        /// <summary>
        /// Creates a new instance of type <see cref="ItemMenu"/> where <paramref name="_itemID"/>, <paramref name="_headerText"/>, <paramref name="_headerPosY"/> and <paramref name="_navButtonText"/> is set
        /// </summary>
        /// <param name="_itemID"></param>
        /// <param name="_headerText"></param>
        /// <param name="_headerPosY"></param>
        /// <param name="_navButtonText"></param>
        protected ItemMenu(string _headerText, int _headerPosY, string _navButtonText) : base(_headerText, _headerPosY, _navButtonText)
        {

        }
    }
}
