using Oiski.ConsoleTech.Engine;
using Oiski.ConsoleTech.Engine.Color.Controls;
using Oiski.ConsoleTech.Engine.Color.Rendering;
using Oiski.ConsoleTech.Engine.Controls;
using Oiski.School.Library_H1_2020.Application.System;
using Oiski.School.Library_H1_2020.Application.System.Items;
using Oiski.School.Library_H1_2020.Application.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Library_H1_2020.Application.UI
{
    public sealed class FindBookMenu : MasterMenu
    {
        private static FindBookMenu instance = null;
        public static FindBookMenu Instance
        {
            get
            {
                if ( instance == null )
                {
                    instance = new FindBookMenu("----Find Book----", 10)
                    {
                        SearchLoaneeButton = (s) =>
                        {
                            Book book = null;
                            if ( instance.searchByValue.Text == "ISBN Code" )
                            {
                                book = Library.GetLibrary.GetBook(instance.searchKeyValue.Text);
                            }

                            if ( book != null )
                            {
                                BooksItemMenu.Instance.CurrentItemID = book.ISBNCode;
                                BooksItemMenu.Instance.Refresh();
                                BooksItemMenu.Instance.GetMenu.Show();
                                instance.GetMenu.Show(false);
                            }

                            instance.searchKeyValue.Text = "Type Search key here...";
                            instance.searchKeyValue.EraseTextOnSelect = true;
                        }
                    };
                    instance.InitMenu();
                }

                return instance;
            }
        }

        #region Combo Control Fields
        private ColorableOption searchByLabel;
        private ColorableLabel searchByValue;
        private ColorableTextField searchKeyValue;
        #endregion

        /// <summary>
        /// The action that is applied when the user selects the switch search type button
        /// </summary>
        public Action<SelectableControl> SwitchSearchByButtonAction { get; private set; }
        /// <summary>
        /// The action that is applied when the user selects the search <see cref="ColorableTextField"/>
        /// </summary>
        public Action<SelectableControl> SearchLoaneeButton { get; private set; }

        public override void InitMenu ()
        {
            base.InitMenu();

            #region Search By Setup
            searchByLabel = new ColorableOption("Search By", ControlsFontColor, ControlsBorderColor, false)
            {
                SelectedIndex = Vector2.Zero
            };
            searchByLabel.OnSelect += SwitchSearchByButtonAction;

            searchByValue = new ColorableLabel("ISBN Code", ControlsFontColor, ControlsBorderColor, false)
            {
                TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black)
            };

            searchByLabel.Position = new Vector2(Vector2.CenterX(searchByLabel.Size.x + searchByValue.Size.x), HeaderPosY + HeaderOffset);
            searchByValue.Position = new Vector2(searchByLabel.Position.x + searchByLabel.Size.x - 1, searchByLabel.Position.y);

            GetMenu.Controls.AddControl(searchByLabel);
            GetMenu.Controls.AddControl(searchByValue);
            #endregion

            #region Search Button Setup
            searchKeyValue = new ColorableTextField("Type Search key here...", ControlsFontColor, ControlsBorderColor, false)
            {
                SelectedIndex = new Vector2(0, 1),
                TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black),
                EraseTextOnSelect = true,
                ResetAfterFirstWrite = true
            };

            searchKeyValue.Position = new Vector2(Vector2.CenterX(searchKeyValue.Size.x), searchByValue.Position.y + 3);
            searchKeyValue.OnSelect += SearchLoaneeButton;

            GetMenu.Controls.AddControl(searchKeyValue);
            #endregion

            #region Nav Button Setup
            NavButtonAction = (s) =>
            {
                instance.searchKeyValue.Text = "Type Search key here...";
                BooksMenu.Instance.GetMenu.Show();
                Instance.ResetSelection();
                Instance.GetMenu.Show(false);
            };
            #endregion
            SetupNavButton();
            instance.ResetSelection();
        }

        public FindBookMenu (string _headerText, int _headerPosY) : base(_headerText, _headerPosY, "Go back")
        {
        }
    }
}
