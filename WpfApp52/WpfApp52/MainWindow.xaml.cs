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
using WpfCustomControlLibrary1;

namespace WpfApp52
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ///var ttt1 =typeof(CustomControl1).AssemblyQualifiedName; // WpfCustomControlLibrary1.CustomControl1, WpfCustomControlLibrary1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=50f4576d5e2012eb
        }
    }
}
