using Oiski.ConsoleTech.Engine;
using Oiski.ConsoleTech.Engine.Color.Controls;
using Oiski.ConsoleTech.Engine.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Library_H1_2020.UI
{
    public class LoaneesMenu : MasterMenu
    {
        private static LoaneesMenu instance = null;
        public static LoaneesMenu Instance
        {
            get
            {
                if ( instance == null )
                {
                    instance = new LoaneesMenu("-----Loanees-----", 15)
                    {
                        LoaneeButtonAction = (s) =>
                        {
                            throw new NotImplementedException("Missing Navigation class for Loanee Menu!");
                        },

                        FindLoaneeButton = (s) =>
                        {
                            throw new NotImplementedException("Missing Navigation class for Find Loanee Menu!");
                        }
                    };

                    instance.InitMenu();
                }

                return instance;
            }
        }

        /// <summary>
        /// The action that is applied when a user selects the loanee button
        /// </summary>
        public Action<SelectableControl> LoaneeButtonAction { get; set; }
        /// <summary>
        /// The action that is appliedd when a user selects the find loanee button
        /// </summary>
        public Action<SelectableControl> FindLoaneeButton { get; set; }

        public override void InitMenu ()
        {
            base.InitMenu();

            #region Create Loanee Button Setup
            ColorableOption loaneeButton = new ColorableOption("Create Loanee", ControlsFontColor, ControlsBorderColor, false)
            {
                SelectedIndex = new Vector2(0, 0)
            };
            loaneeButton.BorderStyle(ConsoleTech.Engine.Controls.BorderArea.Horizontal, '~');
            loaneeButton.Position = new Vector2(Vector2.CenterX(loaneeButton.Size.x), HeaderPosY + HeaderOffset);
            loaneeButton.OnSelect += LoaneeButtonAction;
            GetMenu.Controls.AddControl(loaneeButton);
            #endregion

            #region Find Loanee Button Setup
            ColorableOption findLoaneeButton = new ColorableOption("Find Loanee", ControlsFontColor, ControlsBorderColor, false)
            {
                SelectedIndex = new Vector2(0, 1)
            };
            findLoaneeButton.Position = new Vector2(Vector2.CenterX(findLoaneeButton.Size.x), loaneeButton.Position.y + 3);
            findLoaneeButton.OnSelect += FindLoaneeButton;
            GetMenu.Controls.AddControl(findLoaneeButton);
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
        /// Creates a new instance of type <see cref="LoaneesMenu"/> where the <paramref name="_headerText"/> and <paramref name="_headerPosY"/> is set
        /// </summary>
        /// <param name="_headerText"></param>
        /// <param name="_headerPosY"></param>
        private LoaneesMenu (string _headerText, int _headerPosY) : base(_headerText, _headerPosY, "Go back")
        {

        }
    }
}
