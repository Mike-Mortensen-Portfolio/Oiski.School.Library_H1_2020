using Oiski.ConsoleTech.Engine.Color.Rendering;
using Oiski.ConsoleTech.Engine.Controls;
using Oiski.ConsoleTech.Engine.Color.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using Oiski.ConsoleTech.Engine;

namespace Oiski.School.Library_H1_2020.UI
{
    /// <summary>
    /// The master class for all menues. This is meant to be the foundation for a menu heirachy
    /// </summary>
    public class MasterMenu
    {
        protected string HeaderText { get; }
        protected int HeaderPosY { get; }
        protected string NavButtonText { get; }
        /// <summary>
        /// The ID used to locate the Nav Button <see cref="Control"/> in the <see cref="ControlCollection"/>
        /// </summary>
        protected int NavButtonID { get; private set; }

        /// <summary>
        /// The <see cref="RenderColor"/> that is applied as border color for <see cref="Control"/>s
        /// </summary>
        public RenderColor ControlsBorderColor { get; set; } = new RenderColor(ConsoleColor.Cyan, ConsoleColor.Black);
        /// <summary>
        /// THe <see cref="RenderColor"/> that is applied as font color for <see cref="Control"/>s
        /// </summary>
        public RenderColor ControlsFontColor { get; set; } = new RenderColor(ConsoleColor.DarkBlue, ConsoleColor.Black);

        /// <summary>
        /// The <see cref="Menu"/> <see cref="Control"/> that contains the <see cref="ControlCollection"/>
        /// </summary>
        public Menu GetMenu { get; } = new Menu();

        /// <summary>
        /// The action that is applied when a user selects the Nav Button
        /// </summary>
        public Action<SelectableControl> NavButtonAction { get; set; }

        public virtual void InitMenu ()
        {
            #region Header Setup
            ColorableLabel header = new ColorableLabel(HeaderText, ControlsFontColor, ControlsBorderColor, false);
            header.Position = new Vector2(Vector2.CenterX(header.Size.x), HeaderPosY);
            GetMenu.Controls.AddControl(header);
            #endregion

            #region Nav Button Setup
            ColorableOption navButton = new ColorableOption(NavButtonText, ControlsFontColor, ControlsBorderColor, false);
            GetMenu.Controls.AddControl(navButton);
            NavButtonID = navButton.IndexID;
            #endregion

            SetupNavButton();
        }

        /// <summary>
        /// Set the nav button configuration to ensure it's placed as the last <see cref="Control"/> in the option heirachy
        /// </summary>
        public virtual void SetupNavButton ()
        {
            if ( GetMenu.Controls.FindControl(item => item.IndexID == NavButtonID) is ColorableOption navButton )
            {
                navButton.Position = new Vector2(Vector2.CenterX(navButton.Size.x), GetMenu.Controls[GetMenu.Controls.GetControls.Count - 1].Position.y + 3);
                navButton.SelectedIndex = new Vector2(0, GetMenu.Controls.GetSelectableControls.Count - 1);
                navButton.OnSelect += NavButtonAction;
            }

        }

        /// <summary>
        /// Create a new instance of type <see cref="MasterMenu"/> where the <paramref name="_headerText"/>, <paramref name="_headerPosY"/> and <paramref name="_navButtonText"/> is set
        /// </summary>
        /// <param name="_headerText"></param>
        /// <param name="_headerPosY"></param>
        /// <param name="_navButtonText"></param>
        public MasterMenu (string _headerText, int _headerPosY, string _navButtonText)
        {
            HeaderText = _headerText;
            HeaderPosY = _headerPosY;

            NavButtonText = _navButtonText;
        }
    }
}
