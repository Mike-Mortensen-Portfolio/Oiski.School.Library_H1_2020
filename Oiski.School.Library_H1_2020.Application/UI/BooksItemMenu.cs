using Oiski.ConsoleTech.Engine;
using Oiski.ConsoleTech.Engine.Color.Controls;
using Oiski.ConsoleTech.Engine.Color.Rendering;
using Oiski.ConsoleTech.Engine.Controls;
using Oiski.School.Library_H1_2020.Application.System;
using Oiski.School.Library_H1_2020.Application.System.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Library_H1_2020.Application.UI
{
    /// <summary>
    /// Defines menu for navigation of <see cref="Book"/> items
    /// </summary>
    public sealed class BooksItemMenu : ItemMenu<string>
    {
        private static BooksItemMenu instance = null;
        public static BooksItemMenu Instance
        {
            get
            {
                if ( instance == null )
                {
                    instance = new BooksItemMenu(15)
                    {
                        RemoveBookButtonAction = (s) =>
                        {
                            Library.GetLibrary.RemoveBook(instance.CurrentItemID);
                            instance.GetMenu.Show(false);
                            BooksMenu.Instance.GetMenu.Show();                            
                        },

                        BorrowButtonAction = (s) =>
                        {
                            Library.GetLibrary.BorrowBook(instance.CurrentItemID);
                            instance.Refresh();
                        },

                        ReturnBookButtonAction = (s) =>
                        {
                            Library.GetLibrary.ReturnBook(instance.CurrentItemID);
                            instance.Refresh();
                        }
                    };

                    instance.InitMenu();
                }

                return instance;
            }
        }

        /// <summary>
        /// The action that is applied when a user selects the Remove Button <see cref="Control"/>
        /// </summary>
        public Action<SelectableControl> RemoveBookButtonAction { get; private set; }
        public Action<SelectableControl> ReturnBookButtonAction { get; private set; }
        public Action<SelectableControl> BorrowButtonAction { get; private set; }

        #region These are the controls that make out the value fields
        private ColorableLabel authorLabel;
        private ColorableLabel authorText;
        private ColorableLabel isbnCodeLabel;
        private ColorableLabel isbnCodeText;
        private ColorableLabel categoryLabel;
        private ColorableLabel categoryText;
        private ColorableLabel statusLabel;
        private ColorableLabel statusText;
        private ColorableLabel dolLabel;
        private ColorableLabel dolText; //  Displays the day of which the book was borrowed
        #endregion

        /// <summary>
        /// Initiate the <see cref="Menu"/> <see cref="Control"/>s. (<strong>NOTE:</strong> should only be called once to avoid duplicate <see cref="Control"/>s)
        /// </summary>
        public override void InitMenu()
        {
            base.InitMenu();

            #region Author Setup
            authorLabel = new ColorableLabel("Author", ControlsFontColor, ControlsBorderColor, false);

            authorText = new ColorableLabel(string.Empty, ControlsFontColor, ControlsBorderColor, false);

            #region Setting the controls to be center
            authorLabel.Position = new Vector2(Vector2.CenterX(authorLabel.Size.x + authorText.Size.x), HeaderPosY + HeaderOffset);
            authorText.Position = new Vector2(authorLabel.Position.x + authorLabel.Size.x - 1, authorLabel.Position.y);
            authorText.TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black);
            #endregion

            GetMenu.Controls.AddControl(authorLabel);
            GetMenu.Controls.AddControl(authorText);
            #endregion

            #region ISBN Code Setup
            isbnCodeLabel = new ColorableLabel("ISBN Code", ControlsFontColor, ControlsBorderColor, false);

            isbnCodeText = new ColorableLabel(string.Empty, ControlsFontColor, ControlsBorderColor, false)
            {
                TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black)
            };

            #region Setting Controls to be Center
            isbnCodeLabel.Position = new Vector2(Vector2.CenterX(isbnCodeLabel.Size.x + isbnCodeText.Size.x), authorLabel.Position.y + 3);
            isbnCodeText.Position = new Vector2(isbnCodeLabel.Position.x + isbnCodeLabel.Size.x - 1, isbnCodeLabel.Position.y);
            #endregion

            GetMenu.Controls.AddControl(isbnCodeLabel);
            GetMenu.Controls.AddControl(isbnCodeText);
            #endregion

            #region Category Setup
            categoryLabel = new ColorableLabel("Category", ControlsFontColor, ControlsBorderColor, false);

            categoryText = new ColorableLabel(string.Empty, ControlsFontColor, ControlsBorderColor, false)
            {
                TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black)
            };

            #region Setting Controls to be Center
            categoryLabel.Position = new Vector2(Vector2.CenterX(categoryLabel.Size.x + categoryText.Size.x), isbnCodeText.Position.y + 3);
            categoryText.Position = new Vector2(categoryLabel.Position.x + categoryLabel.Size.x - 1, categoryLabel.Position.y);
            Console.WriteLine(categoryLabel.Position);
            Console.WriteLine(categoryText.Position);
            #endregion

            GetMenu.Controls.AddControl(categoryLabel);
            GetMenu.Controls.AddControl(categoryText);
            #endregion

            #region Status Setup
            statusLabel = new ColorableLabel("Status", ControlsFontColor, ControlsBorderColor, false);

            statusText = new ColorableLabel(string.Empty, ControlsFontColor, ControlsBorderColor, false)
            {
                TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black)
            };

            #region Setting Controls to be Center
            statusLabel.Position = new Vector2(Vector2.CenterX(statusLabel.Size.x + statusText.Size.x), categoryText.Position.y + 3);
            statusText.Position = new Vector2(statusLabel.Position.x + statusLabel.Size.x - 1, statusLabel.Position.y);
            #endregion

            GetMenu.Controls.AddControl(statusLabel);
            GetMenu.Controls.AddControl(statusText);
            #endregion

            #region Day of Lending Setup
            dolLabel = new ColorableLabel("DOL", ControlsFontColor, ControlsBorderColor, false);

            dolText = new ColorableLabel(string.Empty, ControlsFontColor, ControlsBorderColor, false)
            {
                TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black)
            };

            #region Setting Controls to be Center
            dolLabel.Position = new Vector2(Vector2.CenterX(dolLabel.Size.x + dolText.Text.Length + 2), statusText.Position.y + 3);
            dolText.Position = new Vector2(dolLabel.Position.x + dolLabel.Size.x - 1, dolLabel.Position.y);
            #endregion

            GetMenu.Controls.AddControl(dolLabel);
            GetMenu.Controls.AddControl(dolText);
            #endregion

            #region Borrow Book Button
            ColorableOption borrowButton = new ColorableOption("Borrow Book", ControlsFontColor, ControlsBorderColor, false)
            {
                SelectedIndex = Vector2.Zero
            };

            borrowButton.Position = new Vector2(Vector2.CenterX(borrowButton.Size.x), dolText.Position.y + 3);
            borrowButton.OnSelect += BorrowButtonAction;
            GetMenu.Controls.AddControl(borrowButton);
            #endregion

            #region Return Book Button
            ColorableOption returnButton = new ColorableOption("Return Book", ControlsFontColor, ControlsBorderColor, false)
            {
                SelectedIndex = new Vector2(0, 1)
            };

            returnButton.Position = new Vector2(Vector2.CenterX(returnButton.Size.x), borrowButton.Position.y + 3);
            returnButton.OnSelect += ReturnBookButtonAction;
            GetMenu.Controls.AddControl(returnButton);
            #endregion

            #region Remove Button Setup
            ColorableOption removeButton = new ColorableOption("Remove Book", ControlsFontColor, ControlsBorderColor, false)
            {
                SelectedIndex = new Vector2(0, 2)
            };

            removeButton.Position = new Vector2(Vector2.CenterX(removeButton.Size.x), returnButton.Position.y + 3);
            removeButton.OnSelect += RemoveBookButtonAction;
            GetMenu.Controls.AddControl(removeButton);
            #endregion

            #region Nav Button Setup
            NavButtonAction = (s) =>
            {
                LoaneesMenu.Instance.GetMenu.Show();
                ResetSelection();
                GetMenu.Show(false);
            };

            SetupNavButton();
            #endregion

            ResetSelection();
        }

        /// <summary>
        /// Refresh the <see cref="Control"/>s contained in the <see cref="Menu"/>
        /// </summary>
        public void Refresh()
        {
            Book book = Library.GetLibrary.GetBook(CurrentItemID.ToString());

            #region Refresh Header
            Header.Text = ( ( book != null ) ? ( book.Title ) : ( "Error" ) );
            Header.Position = new Vector2(Vector2.CenterX(Header.Text.Length + 2), HeaderPosY);
            #endregion

            #region Refresh Author
            string author = ( ( book != null ) ? ( book.Author ) : ( "Error" ) );
            authorText.Text = author;

            authorLabel.Position = new Vector2(Vector2.CenterX(authorLabel.Size.x + authorText.Text.Length + 2), HeaderPosY + HeaderOffset);
            authorText.Position = new Vector2(authorLabel.Position.x + authorLabel.Size.x - 1, HeaderPosY + HeaderOffset);
            #endregion

            #region Refresh ISBN Code
            string isbnCode = ( ( book != null ) ? ( book.ISBNCode ) : ( "Error" ) );
            isbnCodeText.Text = isbnCode;

            isbnCodeLabel.Position = new Vector2(Vector2.CenterX(isbnCodeLabel.Size.x + isbnCodeText.Text.Length + 2), authorLabel.Position.y + 3);
            isbnCodeText.Position = new Vector2(isbnCodeLabel.Position.x + isbnCodeLabel.Size.x - 1, isbnCodeLabel.Position.y);
            #endregion

            #region Refresh Category
            string category = ( ( book != null ) ? ( book.Category ) : ( "Error" ) );
            categoryText.Text = category;

            categoryLabel.Position = new Vector2(Vector2.CenterX(categoryLabel.Size.x + categoryText.Text.Length + 2), isbnCodeText.Position.y + 3);
            categoryText.Position = new Vector2(categoryLabel.Position.x + categoryLabel.Size.x - 1, categoryLabel.Position.y);
            #endregion

            #region Refresh Status
            string status = ( ( book != null ) ? ( ( book.IsBorrowed ) ? ( "Borrowed" ) : ( "Available" ) ) : ( "Error" ) );
            statusText.Text = status;

            statusLabel.Position = new Vector2(Vector2.CenterX(statusLabel.Size.x + statusText.Text.Length + 2), categoryText.Position.y + 3);
            statusText.Position = new Vector2(statusLabel.Position.x + statusLabel.Size.x - 1, statusLabel.Position.y);
            #endregion

            #region Refresh Category
            string dol = ( ( book != null ) ? ( book.DateOfLending.ToShortDateString() ) : ( "Error" ) );
            dolText.Text = dol;

            dolLabel.Position = new Vector2(Vector2.CenterX(dolLabel.Size.x + dolText.Text.Length + 2), statusText.Position.y + 3);
            dolText.Position = new Vector2(dolLabel.Position.x + dolLabel.Size.x - 1, dolLabel.Position.y);
            #endregion
        }

        /// <summary>
        /// CReates a new instance of type <see cref="BooksItemMenu"/> where <paramref name="_itemID"/> and <paramref name="_headerPosY"/> is set
        /// </summary>
        /// <param name="_itemID"></param>
        /// <param name="_headerPosY"></param>
        private BooksItemMenu(int _headerPosY) : base("Empty", _headerPosY, "Go Back")
        {
        }
    }
}
