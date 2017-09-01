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
    /// Developers: Sara Jade, Tyler Walser, Jose Cheyo Jimenez
    /// 9/1/17
    /// 
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// <remarks>
    /// MainWindow currently displays output in a textbox.
    /// The textbox output comes from output files rather than an
    /// input text file that has been analyzed.
    /// 
    /// TODO: Display code on MainWindow that has been programmatically created
    /// by project Concordance. Probably use a listview.
    /// </remarks>
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

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //MainWindow.HeightProperty.PropertyType.Attributes. 
        }
    }
}
