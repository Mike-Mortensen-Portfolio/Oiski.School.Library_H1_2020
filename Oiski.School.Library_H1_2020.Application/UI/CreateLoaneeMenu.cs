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
    public sealed class CreateLoaneeMenu : MasterMenu
    {
        private static CreateLoaneeMenu instance = null;
        public static CreateLoaneeMenu Instance
        {
            get
            {
                if ( instance == null )
                {
                    instance = new CreateLoaneeMenu("Create Loanee", 15)
                    {
                        CreateButtonAction = (s) =>
                        {
                            if ( Library.GetLibrary.CreateLoanee(instance.LoaneeNameValue.Text, instance.LoaneeEmailValue.Text, out Loanee _loanee) )
                            {
                                instance.ResetSelection();
                                LoaneeItemMenu.Instance.CurrentItemID = _loanee.ID;
                                LoaneeItemMenu.Instance.Refresh();
                                LoaneeItemMenu.Instance.GetMenu.Show();
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
        /// The <see cref="ColorableTextField"/> that contains the name of the <see cref="Loanee"/>
        /// </summary>
        public ColorableTextField LoaneeNameValue { get; private set; }
        /// <summary>
        /// The <see cref="ColorableTextField"/> that contains the email of the <see cref="Loanee"/>
        /// </summary>
        public ColorableTextField LoaneeEmailValue { get; private set; }

        public override void InitMenu ()
        {
            base.InitMenu();

            #region Loanee Value Field Setup
            LoaneeNameValue = new ColorableTextField("Type Name of Loanee...", ControlsFontColor, ControlsBorderColor, false)
            {
                ResetAfterFirstWrite = true,
                SelectedIndex = Vector2.Zero,
                TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black),
                EraseTextOnSelect = true
            };
            LoaneeNameValue.BorderStyle(BorderArea.Horizontal, '~');

            LoaneeNameValue.Position = new Vector2(Vector2.CenterX(LoaneeNameValue.Size.x), HeaderPosY + HeaderOffset);

            GetMenu.Controls.AddControl(LoaneeNameValue);
            #endregion

            #region Loanee Value Field Setup
            LoaneeEmailValue = new ColorableTextField("Type Email for Loanee...", ControlsFontColor, ControlsBorderColor, false)
            {
                ResetAfterFirstWrite = true,
                SelectedIndex = new Vector2(0, 1),
                TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black),
                EraseTextOnSelect = true
            };

            LoaneeEmailValue.Position = new Vector2(Vector2.CenterX(LoaneeEmailValue.Size.x), LoaneeNameValue.Position.y + 3);

            GetMenu.Controls.AddControl(LoaneeEmailValue);
            #endregion

            #region Create Button Setup
            ColorableOption createButton = new ColorableOption("Create New", ControlsFontColor, ControlsBorderColor, false);

            createButton.Position = new Vector2(Vector2.CenterX(createButton.Size.x), LoaneeEmailValue.Position.y + 3);
            createButton.SelectedIndex = new Vector2(0, 2);
            createButton.OnSelect += CreateButtonAction;
            GetMenu.Controls.AddControl(createButton);
            #endregion

            #region Nav Button Setup
            NavButtonAction = (s) =>
            {
                LoaneesMenu.Instance.GetMenu.Show();
                Instance.ResetSelection();
                Instance.GetMenu.Show(false);
            };
            #endregion
            SetupNavButton();
        }

        public CreateLoaneeMenu (string _headerText, int _headerPosY) : base(_headerText, _headerPosY, "Go Back")
        {
        }
    }
}
