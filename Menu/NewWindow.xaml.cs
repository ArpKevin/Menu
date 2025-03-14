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

namespace Menu
{
    /// <summary>
    /// Interaction logic for NewWindow.xaml
    /// </summary>
    public partial class NewWindow : Window
    {
        List<Fuggohid> fuggohidak = new();
        public NewWindow(List<Fuggohid> f)
        {
            InitializeComponent();

            fuggohidak = f;

            orszagokCombobox.ItemsSource = fuggohidak.Select(f => f.Orszag).Distinct();
            orszagokCombobox.SelectedIndex = 0;
        }

        private void keresesGomb_Click(object sender, RoutedEventArgs e)
        {
            List<Fuggohid> keresettHidak = null;
            if (_1kmnelHosszabbCheckbox.IsChecked == true)
            {
                keresettHidak = fuggohidak.Where(f => f.Orszag == orszagokCombobox.SelectedValue.ToString() && f.HidHossz > 1000).ToList();
            }
            else
            {
                keresettHidak = fuggohidak.Where(f => f.Orszag == orszagokCombobox.SelectedValue.ToString()).ToList();
            }

            keresettHidakListbox.ItemsSource = keresettHidak.Select(k => k.HidNev);

            //keresettHidakListbox.ItemsSource = fuggohidak.Select(k => k.HidNev);
        }

        private void bezarasGomb_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
