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

        public override void InitMenu()
        {
            base.InitMenu();

            ResetSelection();
            #region ID Setup
            ColorableLabel idLabel = new ColorableLabel("ID", ControlsFontColor, ControlsBorderColor, false);

            ColorableLabel idText = new ColorableLabel(string.Format("{0,6}", Library.GetLibrary.GetLoanee(CurrentItemID).ID), ControlsFontColor, ControlsBorderColor, false);

            idLabel.Position = new Vector2(Vector2.CenterX(idLabel.Size.x + idText.Size.x), HeaderPosY + HeaderOffset);
            idText.Position = new Vector2(idLabel.Position.x + idLabel.Size.x - 1, idLabel.Position.y);
            idText.TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black);

            GetMenu.Controls.AddControl(idLabel);
            GetMenu.Controls.AddControl(idText);
            #endregion

            #region Email Setup
            ColorableLabel emailLabel = new ColorableLabel("ID", ControlsFontColor, ControlsBorderColor, false);

            ColorableLabel emailText = new ColorableLabel(Library.GetLibrary.GetLoanee(CurrentItemID).Email, ControlsFontColor, ControlsBorderColor, false)
            {
                TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black)
            };

            emailLabel.Position = new Vector2(Vector2.CenterX(emailLabel.Size.x + emailText.Size.x), idLabel.Position.y + 3);
            emailText.Position = new Vector2(emailLabel.Position.x + emailLabel.Size.x - 1, emailLabel.Position.y);

            GetMenu.Controls.AddControl(emailLabel);
            GetMenu.Controls.AddControl(emailText);
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
        }

        /// <summary>
        /// CReates a new instance of type <see cref="LoaneeItemMenu"/> where <paramref name="_itemID"/> and <paramref name="_headerPosY"/> is set
        /// </summary>
        /// <param name="_itemID"></param>
        /// <param name="_headerPosY"></param>
        public LoaneeItemMenu(int _itemID, int _headerPosY) : base(_itemID, Library.GetLibrary.GetLoanee(_itemID).Name, _headerPosY, "Go Back")
        {
        }
    }
}
