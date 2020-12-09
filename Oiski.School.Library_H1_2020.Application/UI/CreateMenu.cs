using Oiski.ConsoleTech.Engine;
using Oiski.ConsoleTech.Engine.Color.Controls;
using Oiski.ConsoleTech.Engine.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Library_H1_2020.Application.UI
{
    public abstract class CreateMenu : MasterMenu
    {

        public Action<SelectableControl> CreateButtonAction { get; private set; }

        public override void InitMenu()
        {
            base.InitMenu();

            #region Create Button Setup
            ColorableOption createButton = new ColorableOption("Create", ControlsFontColor, ControlsBorderColor, false)
            {
                SelectedIndex = Vector2.Zero,
            };

            createButton.OnSelect += CreateButtonAction;
            #endregion

            SetupNavButton();
        }

        protected CreateMenu(string _headerText, int _headerPosY, string _navButtonText) : base(_headerText, _headerPosY, "Back")
        {
        }
    }
}
