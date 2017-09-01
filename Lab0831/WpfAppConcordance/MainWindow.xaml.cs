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
            List<string> content = new List<string>();
            content.Add(Concordance.inputText);
            Input_Text.Text = Concordance.inputText;
        }
    }
}
