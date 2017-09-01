using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Text;
using System.IO;

namespace TLG
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Analyzer anlz = new Analyzer();
            
            //Properties["Analyzer"] = anlz;

            // Set up paths from args
            if (e.Args.Length != 3)
            {
                throw new ArgumentException("Invalid number of path specifications");
            }
            Concordance.GetPaths(e.Args);
            // Get the input data
            Concordance.ReadInputs();
            // Identify paragraphs and sentences
            // Identify words and their location
            anlz.Analyze(Concordance.inputText);

            // Move next line to bottom so that anlz has the properties
            // given by the program.
            Properties["Analyzer"] = anlz;
        }
    }
}
