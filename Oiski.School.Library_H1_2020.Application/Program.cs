using Oiski.ConsoleTech.Engine;
using Oiski.ConsoleTech.Engine.Color.Rendering;
using Oiski.ConsoleTech.Engine.Color.Controls;
using Oiski.School.Library_H1_2020.UI;
using System;

namespace Oiski.School.Library_H1_2020.Application
{
    class Program
    {
        static void Main (string[] args)
        {
            #region Inital Setup of Console Window and Engine
            Console.SetWindowSize(100, 50);

            ColorRenderer renderer = new ColorRenderer
            {
                DefaultColor = new RenderColor(ConsoleColor.DarkRed, ConsoleColor.Black)
            };
            OiskiEngine.ChangeRenderer(renderer);
            OiskiEngine.Input.SetNavigation("Horizontal", false);
            OiskiEngine.Run();
            #endregion

            #region Main Manu Setup
            MainMenu main = new MainMenu("Oiski's Library", 15);

            main.LoaneesButtonAction = (s) =>
            {
                throw new NotImplementedException("Missing Navigation class for Loanees Menu!");
            };

            main.BookButtonAction = (s) =>
            {
                throw new NotImplementedException("Missing Navigation class for Books Menu!");
            };

            main.InitMenu();
            main.GetMenu.Show();
            #endregion
        }
    }
}
