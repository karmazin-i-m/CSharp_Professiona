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
//using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing.Text;

namespace ITVDN_Task_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InstalledFontCollection installedFontCollection = new InstalledFontCollection();

            System.Drawing.FontFamily[] fontCollections = (System.Drawing.FontFamily[])installedFontCollection.Families;

            foreach (System.Drawing.FontFamily item in fontCollections)
            {
                FontComboBox.Items.Add(item.Name);
            }
        }

        private void FontComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBox.FontFamily = new System.Windows.Media.FontFamily(FontComboBox.Text);
        }

        private void BoldCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            TextBox.FontWeight = FontWeights.Bold;
        }

        private void BoldCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            TextBox.FontWeight = FontWeights.Normal;
        }

        private void ItalicsCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            TextBox.FontStyle = FontStyles.Normal;
        }

        private void ItalicsCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            TextBox.FontStyle = FontStyles.Italic;
        }

        private void UnderlinedCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            TextBox.TextDecorations = TextDecorations.Underline;
        }

        private void UnderlinedCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            TextBox.TextDecorations = new TextDecorationCollection();
        }

        private void FontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBox.FontSize = Double.Parse(((ComboBoxItem)FontSizeComboBox.SelectedItem).Content.ToString());
        }
    }
}
