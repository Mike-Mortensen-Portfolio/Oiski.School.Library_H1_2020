using Oiski.ConsoleTech.Engine;
using Oiski.ConsoleTech.Engine.Color.Controls;
using Oiski.ConsoleTech.Engine.Color.Rendering;
using Oiski.ConsoleTech.Engine.Controls;
using Oiski.School.Library_H1_2020.Application.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Library_H1_2020.Application.UI
{
    /// <summary>
    /// 
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
                    instance = new LoaneeItemMenu(15);
                    instance.InitMenu();
                }

                return instance;
            }
        }

        public override void InitMenu()
        {
            base.InitMenu();

            #region ID Setup
            ColorableLabel idLabel = new ColorableLabel("ID", ControlsFontColor, ControlsBorderColor, false);

            string id = ( ( Library.GetLibrary.GetLoanee(CurrentItemID) != null ) ? ( Library.GetLibrary.GetLoanee(CurrentItemID).ID.ToString() ) : ( "Error" ) );

            ColorableLabel idText = new ColorableLabel(string.Format("{0,6}", id), ControlsFontColor, ControlsBorderColor, false);

            idLabel.Position = new Vector2(Vector2.CenterX(idLabel.Size.x + idText.Size.x), HeaderPosY + HeaderOffset);
            idText.Position = new Vector2(idLabel.Position.x + idLabel.Size.x - 1, idLabel.Position.y);
            idText.TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black);

            GetMenu.Controls.AddControl(idLabel);
            GetMenu.Controls.AddControl(idText);
            #endregion

            #region Email Setup
            ColorableLabel emailLabel = new ColorableLabel("ID", ControlsFontColor, ControlsBorderColor, false);

            string email = ( ( Library.GetLibrary.GetLoanee(CurrentItemID) != null ) ? ( Library.GetLibrary.GetLoanee(CurrentItemID).Email ) : ( "Error" ) );

            ColorableLabel emailText = new ColorableLabel(email, ControlsFontColor, ControlsBorderColor, false)
            {
                TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black)
            };

            emailLabel.Position = new Vector2(Vector2.CenterX(emailLabel.Size.x + emailText.Size.x), idLabel.Position.y + 3);
            emailText.Position = new Vector2(emailLabel.Position.x + emailLabel.Size.x - 1, emailLabel.Position.y);

            GetMenu.Controls.AddControl(emailLabel);
            GetMenu.Controls.AddControl(emailText);
            #endregion

            #region Remove Button Setup
            ColorableOption removeButton = new ColorableOption("Remove Loanee", ControlsFontColor, ControlsBorderColor, false)
            {
                SelectedIndex = Vector2.Zero
            };

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
        /// CReates a new instance of type <see cref="LoaneeItemMenu"/> where <paramref name="_itemID"/> and <paramref name="_headerPosY"/> is set
        /// </summary>
        /// <param name="_itemID"></param>
        /// <param name="_headerPosY"></param>
        public LoaneeItemMenu(int _headerPosY) : base("Empty", _headerPosY, "Go Back")
        {
        }
    }
}
