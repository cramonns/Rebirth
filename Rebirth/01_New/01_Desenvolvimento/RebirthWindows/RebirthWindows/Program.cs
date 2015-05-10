#region Using Statements
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.IO;
#endregion

namespace Rebirth{
    static class Program{
        private static Game1 game;

        static void printError(){
            System.Console.Out.WriteLine("Invalid set of arguments.");
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args){

            if (args.Length != 0){
                if (args.Length > 1) printError();
                else {
                    if (args[0].Equals("-editor")){

                        string target = "killer.exe";
                        target = Path.Combine(System.IO.Directory.GetCurrentDirectory(),target);
                        try {
                            Process.Start(target);
                        }
                        catch (Exception e){
                        }

                        LevelEditor form = new LevelEditor();
                        form.gameEditor = new Editor();
                        form.Show();
                        // This line creates a Game1 object in the gameEntry field created earlier.
                        form.gameEntry = new Game1(form.gameBox.Handle, form, form.gameBox);
                        form.gameEntry.Run();
                    }
                    else printError();
                }
            }
            else {
                game = new Game1();
                game.Run();
            }
        }
    }
}
