using Knihovna_BCSH2.ViewModel;
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
using System.Windows.Shapes;

namespace Knihovna_BCSH2
{
    /// <summary>
    /// Interaction logic for Autori.xaml
    /// </summary>
    public partial class Autori : Window
    {
        public Autori()
        {
            InitializeComponent();
            DataContext = new AutoriViewModel();
        }
    }
}
