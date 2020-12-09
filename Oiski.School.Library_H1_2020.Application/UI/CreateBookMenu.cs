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
    public sealed class CreateBookMenu : MasterMenu
    {
        private static CreateBookMenu instance = null;
        public static CreateBookMenu Instance
        {
            get
            {
                if ( instance == null )
                {
                    instance = new CreateBookMenu("Create Loanee", 15)
                    {
                        CreateButtonAction = (s) =>
                        {
                            if ( Library.GetLibrary.CreateBook(instance.TitleValue.Text, instance.AuthorValue.Text, instance.CategoryValue.Text, instance.ISBNCodeValue.Text, out Book _book) )
                            {
                                instance.ResetSelection();
                                BooksItemMenu.Instance.CurrentItemID = _book.ISBNCode;
                                BooksItemMenu.Instance.Refresh();
                                BooksItemMenu.Instance.GetMenu.Show();
                                instance.GetMenu.Show(false);
                            }
                        },
                    };

                    instance.InitMenu();
                }

                return instance;
            }
        }

        /// <summary>
        /// The action applied when a user selects the Create Button <see cref="Control"/>
        /// </summary>
        public Action<SelectableControl> CreateButtonAction { get; set; }

        /// <summary>
        /// The <see cref="ColorableTextField"/> that contains the title of the <see cref="Book"/>
        /// </summary>
        public ColorableTextField TitleValue { get; private set; }
        /// <summary>
        /// The <see cref="ColorableTextField"/> that contains the author of the <see cref="Book"/>
        /// </summary>
        public ColorableTextField AuthorValue { get; private set; }
        /// <summary>
        /// The <see cref="ColorableTextField"/> that contains the ISBN Code of the <see cref="Book"/>
        /// </summary>
        public ColorableTextField ISBNCodeValue { get; private set; }
        /// <summary>
        /// The <see cref="ColorableTextField"/> that contains the category of the <see cref="Book"/>
        /// </summary>
        public ColorableTextField CategoryValue { get; private set; }

        public override void InitMenu ()
        {
            base.InitMenu();

            #region Book Title Value Field Setup
            TitleValue = new ColorableTextField("Type Title of Book...", ControlsFontColor, ControlsBorderColor, false)
            {
                ResetAfterFirstWrite = true,
                SelectedIndex = Vector2.Zero,
                TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black),
                EraseTextOnSelect = true
            };
            TitleValue.BorderStyle(BorderArea.Horizontal, '~');

            TitleValue.Position = new Vector2(Vector2.CenterX(TitleValue.Size.x), HeaderPosY + HeaderOffset);

            GetMenu.Controls.AddControl(TitleValue);
            #endregion

            #region Book Author Value Field Setup
            AuthorValue = new ColorableTextField("Type Author of Book...", ControlsFontColor, ControlsBorderColor, false)
            {
                ResetAfterFirstWrite = true,
                SelectedIndex = new Vector2(0, 1),
                TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black),
                EraseTextOnSelect = true
            };

            AuthorValue.Position = new Vector2(Vector2.CenterX(AuthorValue.Size.x), TitleValue.Position.y + 3);

            GetMenu.Controls.AddControl(AuthorValue);
            #endregion

            #region Book ISBN Code Value Field Setup
            ISBNCodeValue = new ColorableTextField("Type ISBN Code of Book...", ControlsFontColor, ControlsBorderColor, false)
            {
                ResetAfterFirstWrite = true,
                SelectedIndex = new Vector2(0, 2),
                TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black),
                EraseTextOnSelect = true
            };

            ISBNCodeValue.Position = new Vector2(Vector2.CenterX(ISBNCodeValue.Size.x), AuthorValue.Position.y + 3);

            GetMenu.Controls.AddControl(ISBNCodeValue);
            #endregion

            #region Book Category Value Field Setup
            CategoryValue = new ColorableTextField("Type Category for Book...", ControlsFontColor, ControlsBorderColor, false)
            {
                ResetAfterFirstWrite = true,
                SelectedIndex = new Vector2(0, 3),
                TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black),
                EraseTextOnSelect = true
            };

            CategoryValue.Position = new Vector2(Vector2.CenterX(CategoryValue.Size.x), ISBNCodeValue.Position.y + 3);

            GetMenu.Controls.AddControl(CategoryValue);
            #endregion

            #region Create Button Setup
            ColorableOption createButton = new ColorableOption("Create New", ControlsFontColor, ControlsBorderColor, false);

            createButton.Position = new Vector2(Vector2.CenterX(createButton.Size.x), CategoryValue.Position.y + 3);
            createButton.SelectedIndex = new Vector2(0, 4);
            createButton.OnSelect += CreateButtonAction;
            GetMenu.Controls.AddControl(createButton);
            #endregion

            #region Nav Button Setup
            NavButtonAction = (s) =>
            {
                BooksMenu.Instance.GetMenu.Show();
                Instance.ResetSelection();
                Instance.GetMenu.Show(false);
            };
            #endregion
            SetupNavButton();
        }

        public CreateBookMenu (string _headerText, int _headerPosY) : base(_headerText, _headerPosY, "Go Back")
        {
        }
    }
}
