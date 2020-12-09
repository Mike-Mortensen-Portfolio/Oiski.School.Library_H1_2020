using Oiski.ConsoleTech.Engine;
using Oiski.ConsoleTech.Engine.Color.Rendering;
using Oiski.ConsoleTech.Engine.Color.Controls;
using Oiski.School.Library_H1_2020.Application.UI;
using System;
using Oiski.School.Library_H1_2020.Application.System;
using Oiski.School.Library_H1_2020.Application.System.Items;
using Oiski.School.Library_H1_2020.Application.Users;

namespace Oiski.School.Library_H1_2020.Application
{
    class Program
    {
        static void Main()
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

            MainMenu.Instance.GetMenu.Show();          
        }
    }
}
