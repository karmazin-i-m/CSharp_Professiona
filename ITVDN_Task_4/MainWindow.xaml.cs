using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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
using System.Xml;

namespace ITVDN_Task_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool flag = true;
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
            if (flag)
            {
                flag = !flag;
            }
            else
            {
                //MessageBox.Show(TextBox.FontSize.ToString());
                double doub = Double.Parse((FontSizeComboBox.SelectedItem as ComboBoxItem).Content.ToString());
                TextBox.FontSize = doub;


            }

        }

        private void FontColorPicer_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            this.TextBox.Foreground = new SolidColorBrush((Color)FontColorPicer.SelectedColor);
        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            this.TextBox.Background = new SolidColorBrush((Color)BackgroundColorPicer.SelectedColor);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Configuration file

            XmlDocument doc = loadConfigDocument();

            XmlNode node = doc.SelectSingleNode("//appSettings");

            string[] keys = new string[] {
                                          "FontColor.R",
                                          "FontColor.G",
                                          "FontColor.B",
                                          "BackGroundColor.R",
                                          "BackGroundColor.G",
                                          "BackGroundColor.B",
                                          "Bold",
                                          "Italics",
                                          "Underline",
                                          "FontFamily",
                                          "FontSize",
                                          };

            string[] values = new string[] {
                                             FontColorPicer.SelectedColor.Value.R.ToString(),
                                             FontColorPicer.SelectedColor.Value.G.ToString(),
                                             FontColorPicer.SelectedColor.Value.B.ToString(),
                                             BackgroundColorPicer.SelectedColor.Value.R.ToString(),
                                             BackgroundColorPicer.SelectedColor.Value.G.ToString(),
                                             BackgroundColorPicer.SelectedColor.Value.B.ToString(),
                                             BoldCheckBox.IsChecked.ToString(),
                                             ItalicsCheckBox.IsChecked.ToString(),
                                             UnderlinedCheckBox.IsChecked.ToString(),
                                             FontComboBox.Text,
                                             FontSizeComboBox.Text,
                                            };
            for (int i = 0; i < keys.Length; i++)
            {
                // Обращаемся к конкретной строке по ключу.
                XmlElement element = (node.SelectSingleNode(string.Format("//add[@key='{0}']", keys[i])) as XmlElement);

                // Если строка с таким ключем существует - записываем значение.
                if (element != null) { element.SetAttribute("value", values[i]); }
                else
                {
                    // Иначе: создаем строку и формируем в ней пару [ключ]-[значение].
                    element = doc.CreateElement("add");
                    element.SetAttribute("key", keys[i]);
                    element.SetAttribute("value", values[i]);
                    node.AppendChild(element);
                }
            }

            // Сохраняем результат модификации.
            doc.Save(Assembly.GetExecutingAssembly().Location + ".config");
        }

        private static XmlDocument loadConfigDocument()
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(Assembly.GetExecutingAssembly().Location + ".config");
                return doc;
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new Exception("No configuration file found.", e);
            }
        }
    }
}
