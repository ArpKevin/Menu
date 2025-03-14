using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Menu;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public List<Fuggohid> fuggohidak = new List<Fuggohid>();
    public MainWindow()
    {
        InitializeComponent();
        foreach (var item in File.ReadAllLines(@"..\..\..\src\fuggohidak.csv").Skip(1))
        {
            var x = item.Split("\t");
            fuggohidak.Add(new(
                int.Parse(x[0]),
                x[1],
                x[2],
                x[3],
                int.Parse(x[4]),
                int.Parse(x[5])
                ));
        }

        hidakListbox.ItemsSource = fuggohidak.Select(f => f.HidNev);
    }

    private void MenuItemNew_Click(object sender, RoutedEventArgs e)
    {
        NewWindow newWindow = new(fuggohidak);
        newWindow.Owner = this;
        newWindow.Show();
    }

    private void MenuItemExit_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void MenuItemDialog_Click(object sender, RoutedEventArgs e)
    {
        NewWindow newWindow = new(fuggohidak);
        newWindow.Owner = this;
        this.Visibility = Visibility.Hidden;
        newWindow.Closed += (s, args) => this.Visibility = Visibility.Visible;
        newWindow.ShowDialog();
    }

    private void Kilepes_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new();
        if (openFileDialog.ShowDialog() == true)
        {
            //előzetesen elhelyezzük a forrásfájlt a szokott helyen
            string filePath = openFileDialog.FileName; //ide bekerül a fájl abszolút elérési útja
            //feldolgozzuk a forrásfájlt a szokott módon
        }
    }

    private void hidakListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (hidakListbox.SelectedItem != null)
        {
            var valasztottHid = fuggohidak.FirstOrDefault(f => hidakListbox.SelectedValue == f.HidNev);

            helyTextbox.Text = valasztottHid.FoldrajziHely;
            orszagTextbox.Text = valasztottHid.Orszag;
            hosszTextbox.Text = valasztottHid.HidHossz.ToString();
            evTextbox.Text = valasztottHid.AtadasEve.ToString();
        }
        
    }

    private void _2000elottRadioButton_Checked(object sender, RoutedEventArgs e)
    {
        hidakSzamaTextbox.Text = fuggohidak.Count(f => f.AtadasEve < 2000).ToString();
    }

    private void _2000benVagyUtanRadioButton_Checked(object sender, RoutedEventArgs e)
    {
        hidakSzamaTextbox.Text = fuggohidak.Count(f => f.AtadasEve >= 2000).ToString();
    }
}