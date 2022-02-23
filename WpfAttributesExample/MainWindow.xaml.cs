using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
using AttributesExample;

namespace WpfAttributesExample
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person(tBoxName.Text, Convert.ToInt32(tBoxAge.Text));
            var results = Program.Validate(person);
            lvProperties.ItemsSource = results;
            if(lvProperties.Items.Count != 0)
            {
                lvProperties.Visibility = Visibility.Visible;
            }
        }
    }
}
