using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ImageEdgeDetection
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            Console.WriteLine("HELOOOOOOOOO");

            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("TestImageEdgeDetection.assets.openSuse.png");


            const string original = @"C:\Users\openSuse.png";
            //const string original = @"..\\..\\assets\\openSuse.png";
            Console.WriteLine(File.Exists(original));
        }
    }
}
