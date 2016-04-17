using System;
using System.Diagnostics;
using System.IO;
using Rebirth.EditorClasses;
using System.Windows.Forms;

namespace Rebirth{
    static class Program{
        private static Game1 game;

        static void printError(){
            System.Console.Out.WriteLine("Invalid set of arguments.");
        }

        static void callKiller(){
            string target = "killer.exe";
            target = Path.Combine(System.IO.Directory.GetCurrentDirectory(),target);
            try {
                Process.Start(target);
            }
            catch (Exception e){
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args){

#if EDITOR
            if (args.Length != 0){
                if (args.Length > 1) printError();
                else {
                    callKiller();

                    switch (args[0]){
                        case ("-editor"):
                            LevelEditor form = new LevelEditor();
                            form.Show();
                            // This line creates a Game1 object in the gameEntry field created earlier.
                            form.gameEntry = new Game1(form.gameBox.Handle, form, form.gameBox);
                            form.gameEntry.Run();
                            break;
                        case ("-loadDemo"):
                            DisplayManager.LoadingDemo();
                            game = new Game1();
                            game.Run();
                            break;
                        case ("-formTest"):
                            //Application.EnableVisualStyles();
                            //Application.SetCompatibleTextRenderingDefault(false);
                            goto case ("-loadDemo");
                            Application.Run(new Form1());
                            break;
                        default:
                            printError();
                            break;
                    }
                }
            }
            else {
#endif
                game = new Game1();
                game.graphics.IsFullScreen = true;
                game.Run();
#if EDITOR
            }
#endif
        }
    }
}
