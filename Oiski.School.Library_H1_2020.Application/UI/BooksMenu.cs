using Oiski.ConsoleTech.Engine;
using Oiski.ConsoleTech.Engine.Color.Controls;
using Oiski.ConsoleTech.Engine.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Library_H1_2020.Application.UI
{
    public sealed class BooksMenu : MasterMenu
    {
        private static BooksMenu instance = null;
        public static BooksMenu Instance
        {
            get
            {
                if ( instance == null )
                {
                    instance = new BooksMenu("-----Books-----", 15)
                    {
                        BookButtonAction = (s) =>
                        {
                            throw new NotImplementedException("Missing Navigation class for Book Menu!");
                        },

                        FindBookButton = (s) =>
                        {
                            throw new NotImplementedException("Missing Navigation class for Find Book Menu!");
                        }
                    };

                    instance.InitMenu();
                }

                return instance;
            }
        }

        /// <summary>
        /// The action that is applied when a user selects the book button
        /// </summary>
        public Action<SelectableControl> BookButtonAction { get; private set; }
        /// <summary>
        /// The action that is appliedd when a user selects the find book button
        /// </summary>
        public Action<SelectableControl> FindBookButton { get; private set; }

        public override void InitMenu()
        {
            base.InitMenu();

            #region Create Book Button Setup
            ColorableOption createBookButton = new ColorableOption("Create Book", ControlsFontColor, ControlsBorderColor, false)
            {
                SelectedIndex = new Vector2(0, 0)
            };
            createBookButton.BorderStyle(ConsoleTech.Engine.Controls.BorderArea.Horizontal, '~');
            createBookButton.Position = new Vector2(Vector2.CenterX(createBookButton.Size.x), HeaderPosY + HeaderOffset);
            createBookButton.OnSelect += BookButtonAction;
            GetMenu.Controls.AddControl(createBookButton);
            #endregion

            #region Find Book Button Setup
            ColorableOption findBookButton = new ColorableOption("Find Book", ControlsFontColor, ControlsBorderColor, false)
            {
                SelectedIndex = new Vector2(0, 1)
            };
            findBookButton.Position = new Vector2(Vector2.CenterX(findBookButton.Size.x), createBookButton.Position.y + 3);
            findBookButton.OnSelect += FindBookButton;
            GetMenu.Controls.AddControl(findBookButton);
            #endregion

            #region Nav Button Setup
            NavButtonAction = (s) =>
            {
                MainMenu.Instance.GetMenu.Show();
                Instance.ResetSelection();
                Instance.GetMenu.Show(false);
            };

            SetupNavButton();
            #endregion
        }

        /// <summary>
        /// Creates a new instance of type <see cref="BooksMenu"/> where the <paramref name="_headerText"/> and <paramref name="_headerPosY"/> is set
        /// </summary>
        /// <param name="_headerText"></param>
        /// <param name="_headerPosY"></param>
        private BooksMenu(string _headerText, int _headerPosY) : base(_headerText, _headerPosY, "Go back")
        {

        }
    }
}
