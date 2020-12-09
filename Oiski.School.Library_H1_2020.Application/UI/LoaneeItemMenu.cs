using Oiski.ConsoleTech.Engine;
using Oiski.ConsoleTech.Engine.Color.Controls;
using Oiski.ConsoleTech.Engine.Color.Rendering;
using Oiski.ConsoleTech.Engine.Controls;
using Oiski.School.Library_H1_2020.Application.System;
using Oiski.School.Library_H1_2020.Application.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Library_H1_2020.Application.UI
{
    /// <summary>
    /// Defines menu for navigation of <see cref="Loanee"/> items
    /// </summary>
    public class LoaneeItemMenu : ItemMenu
    {
        private static LoaneeItemMenu instance = null;
        public static LoaneeItemMenu Instance
        {
            get
            {
                if ( instance == null )
                {
                    instance = new LoaneeItemMenu(15)
                    {
                        RemoveLoaneeButtonAction = (s) =>
                        {
                            Library.GetLibrary.RemoveLoanee(instance.CurrentItemID);
                            instance.GetMenu.Show(false);
                            LoaneesMenu.Instance.GetMenu.Show();
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
        public Action<SelectableControl> RemoveLoaneeButtonAction { get; private set; }

        #region These are the controls that make out the value fields
        private ColorableLabel idLabel;
        private ColorableLabel idText;
        private ColorableLabel emailLabel;
        private ColorableLabel emailText;
        #endregion

        /// <summary>
        /// Initiate the <see cref="Menu"/> <see cref="Control"/>s. (<strong>NOTE:</strong> should only be called once to avoid duplicate <see cref="Control"/>s)
        /// </summary>
        public override void InitMenu()
        {
            base.InitMenu();

            #region ID Setup
            idLabel = new ColorableLabel("ID", ControlsFontColor, ControlsBorderColor, false);

            idText = new ColorableLabel(string.Empty, ControlsFontColor, ControlsBorderColor, false);
            Console.WriteLine(idText.Size);

            #region Setting the controls to be center
            idLabel.Position = new Vector2(Vector2.CenterX(idLabel.Size.x + idText.Size.x), HeaderPosY + HeaderOffset);
            idText.Position = new Vector2(idLabel.Position.x + idLabel.Size.x - 1, idLabel.Position.y);
            idText.TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black);
            #endregion

            GetMenu.Controls.AddControl(idLabel);
            GetMenu.Controls.AddControl(idText);
            #endregion

            #region Email Setup
            emailLabel = new ColorableLabel("Email", ControlsFontColor, ControlsBorderColor, false);

            emailText = new ColorableLabel(string.Empty, ControlsFontColor, ControlsBorderColor, false)
            {
                TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black)
            };

            #region Setting Controls to be Center
            emailLabel.Position = new Vector2(Vector2.CenterX(emailLabel.Size.x + emailText.Size.x), idLabel.Position.y + 3);
            emailText.Position = new Vector2(emailLabel.Position.x + emailLabel.Size.x - 1, emailLabel.Position.y);
            #endregion

            GetMenu.Controls.AddControl(emailLabel);
            GetMenu.Controls.AddControl(emailText);
            #endregion

            #region Remove Button Setup
            ColorableOption removeButton = new ColorableOption("Remove Loanee", ControlsFontColor, ControlsBorderColor, false)
            {
                SelectedIndex = Vector2.Zero
            };
            removeButton.Position = new Vector2(Vector2.CenterX(removeButton.Size.x), emailText.Position.y + 3);
            removeButton.OnSelect += RemoveLoaneeButtonAction;
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
            Loanee loanee = Library.GetLibrary.GetLoanee(CurrentItemID);

            #region Refresh Header
            Header.Text = ( ( loanee != null ) ? ( loanee.Name ) : ( "Error" ) );
            Header.Position = new Vector2(Vector2.CenterX(Header.Text.Length + 2), HeaderPosY);
            #endregion

            #region Refresh ID
            string id = ( ( loanee != null ) ? ( loanee.ID.ToString() ) : ( "Error" ) );
            idText.Text = string.Format("{0,6}", id);

            idLabel.Position = new Vector2(Vector2.CenterX(idLabel.Size.x + idText.Text.Length + 2), HeaderPosY + HeaderOffset);
            idText.Position = new Vector2(idLabel.Position.x + idLabel.Size.x - 1, HeaderPosY + HeaderOffset);
            #endregion

            #region Refresh Email
            string email = ( ( loanee != null ) ? ( loanee.Email ) : ( "Error" ) );
            emailText.Text = email;

            emailLabel.Position = new Vector2(Vector2.CenterX(emailLabel.Size.x + emailText.Text.Length + 2), idLabel.Position.y + 3);
            emailText.Position = new Vector2(emailLabel.Position.x + emailLabel.Size.x - 1, emailLabel.Position.y);
            #endregion
        }

        /// <summary>
        /// CReates a new instance of type <see cref="LoaneeItemMenu"/> where <paramref name="_itemID"/> and <paramref name="_headerPosY"/> is set
        /// </summary>
        /// <param name="_itemID"></param>
        /// <param name="_headerPosY"></param>
        private LoaneeItemMenu(int _headerPosY) : base("Empty", _headerPosY, "Go Back")
        {
        }
    }
}
