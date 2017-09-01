using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace TLG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal TLG.Analyzer analyzer;

        public MainWindow()
        {
            analyzer = (TLG.Analyzer)Application.Current.Properties["Analyzer"];
            InitializeComponent();
           
            Input_Text.Text = Concordance.inputText;
        }

        private void WordCount_Click(object sender, RoutedEventArgs e)
        {
            Input_Text.Text = File.ReadAllText(Concordance.outputFilePaths[0]);
        }

        private void WordCount2_Click(object sender, RoutedEventArgs e)
        {
            Input_Text.Text = File.ReadAllText(Concordance.outputFilePaths[2]);
        }

        private void WordLocation_Click(object sender, RoutedEventArgs e)
        {
            Input_Text.Text = File.ReadAllText(Concordance.outputFilePaths[1]);
        }

        private void WordLocation2_Click(object sender, RoutedEventArgs e)
        {
            Input_Text.Text = File.ReadAllText(Concordance.outputFilePaths[3]);
        }
    }
}
