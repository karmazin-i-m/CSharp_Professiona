using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using Microsoft.Win32;

namespace ITVDN_Task_4
{
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

            string[] values = new string[11];

            values[0] = FontColorPicer.SelectedColor.Value.R.ToString();
            values[1] = FontColorPicer.SelectedColor.Value.G.ToString();
            values[2] = FontColorPicer.SelectedColor.Value.B.ToString();
            values[3] = BackgroundColorPicer.SelectedColor.Value.R.ToString();
            values[4] = BackgroundColorPicer.SelectedColor.Value.G.ToString();
            values[5] = BackgroundColorPicer.SelectedColor.Value.B.ToString();
            values[6] = BoldCheckBox.IsChecked.ToString();
            values[7] = ItalicsCheckBox.IsChecked.ToString();
            values[8] = UnderlinedCheckBox.IsChecked.ToString();
            values[9] = FontComboBox.Text;
            values[10] = FontSizeComboBox.Text;


            for (int i = 0; i < keys.Length; i++)
            {
                XmlElement element = (node.SelectSingleNode(string.Format("//add[@key='{0}']", keys[i])) as XmlElement);

                if (element != null)
                {
                    element.SetAttribute("value", values[i]);
                }
                else
                {
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
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            NameValueCollection allAppSettings = ConfigurationManager.AppSettings;

            if (allAppSettings.Count < 1)
                return;

            byte FontColorR = Byte.Parse(allAppSettings.Get("FontColor.R"));
            byte FontColorG = Byte.Parse(allAppSettings.Get("FontColor.G"));
            byte FontColorB = Byte.Parse(allAppSettings.Get("FontColor.B"));
            this.FontColorPicer.SelectedColor = Color.FromRgb(FontColorR, FontColorG, FontColorB);

            byte BackGroundColorR = Byte.Parse(allAppSettings.Get("BackGroundColor.R"));
            byte BackGroundColorG = Byte.Parse(allAppSettings.Get("BackGroundColor.G"));
            byte BackGroundColorB = Byte.Parse(allAppSettings.Get("BackGroundColor.B"));
            this.BackgroundColorPicer.SelectedColor = Color.FromRgb(BackGroundColorR, BackGroundColorG, BackGroundColorB);

            bool bold = Boolean.Parse(allAppSettings.Get("Bold"));
            bool italics = Boolean.Parse(allAppSettings.Get("Italics"));
            bool underline = Boolean.Parse(allAppSettings.Get("Underline"));
            this.BoldCheckBox.IsChecked = bold;
            this.ItalicsCheckBox.IsChecked = italics;
            this.UnderlinedCheckBox.IsChecked = underline;

            string FontFamily = allAppSettings.Get("FontFamily");
            int FontSize = Int32.Parse(allAppSettings.Get("FontSize"));

            this.TextBox.FontFamily = new FontFamily(FontFamily);
            this.TextBox.FontSize = FontSize;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            using (RegistryKey registry = Registry.CurrentUser)
            {
                using (var subKey = registry.OpenSubKey("Software", true))
                {
                    using (RegistryKey subSubKey = subKey.CreateSubKey("MyApp"))
                    {
                        subSubKey.SetValue("FontColor.R", FontColorPicer.SelectedColor.Value.R, RegistryValueKind.DWord);
                        subSubKey.SetValue("FontColor.G", FontColorPicer.SelectedColor.Value.G, RegistryValueKind.DWord);
                        subSubKey.SetValue("FontColor.B", FontColorPicer.SelectedColor.Value.B, RegistryValueKind.DWord);
                        subSubKey.SetValue("BackGroundColor.R", BackgroundColorPicer.SelectedColor.Value.R, RegistryValueKind.DWord);
                        subSubKey.SetValue("BackGroundColor.G", BackgroundColorPicer.SelectedColor.Value.G, RegistryValueKind.DWord);
                        subSubKey.SetValue("BackGroundColor.B", BackgroundColorPicer.SelectedColor.Value.B, RegistryValueKind.DWord);
                        subSubKey.SetValue("Bold", BoldCheckBox.IsChecked.ToString());
                        subSubKey.SetValue("Italics", ItalicsCheckBox.IsChecked.ToString());
                        subSubKey.SetValue("Underline", UnderlinedCheckBox.IsChecked.ToString());
                        subSubKey.SetValue("FontFamily", FontComboBox.Text);
                        subSubKey.SetValue("FontSize", Int32.Parse(FontSizeComboBox.Text), RegistryValueKind.DWord);
                    }
                }
            }

        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            using(RegistryKey registry = Registry.CurrentUser)
            {
                using(RegistryKey reg = registry.OpenSubKey(@"Software\MyApp"))
                {
                    byte FontColorR = (byte)(int)reg.GetValue("FontColor.R");
                    byte FontColorG = (byte)(int)reg.GetValue("FontColor.G");
                    byte FontColorB = (byte)(int)reg.GetValue("FontColor.B");
                    this.FontColorPicer.SelectedColor = Color.FromRgb(FontColorR, FontColorG, FontColorB);

                    byte BackGroundColorR = (byte)(int)reg.GetValue("BackGroundColor.R");
                    byte BackGroundColorG = (byte)(int)reg.GetValue("BackGroundColor.G");
                    byte BackGroundColorB = (byte)(int)reg.GetValue("BackGroundColor.B");
                    this.BackgroundColorPicer.SelectedColor = Color.FromRgb(BackGroundColorR, BackGroundColorG, BackGroundColorB);

                    bool bold = bool.Parse(reg.GetValue("Bold") as string);
                    bool italics = bool.Parse(reg.GetValue("Italics") as string);
                    bool underline = bool.Parse(reg.GetValue("Underline") as string);
                    this.BoldCheckBox.IsChecked = bold;
                    this.ItalicsCheckBox.IsChecked = italics;
                    this.UnderlinedCheckBox.IsChecked = underline;

                    string FontFamily = (string)reg.GetValue("FontFamily");
                    int FontSize = (int)reg.GetValue("FontSize");

                    this.TextBox.FontFamily = new FontFamily(FontFamily);
                    this.TextBox.FontSize = FontSize;
                    //asfasfasfasf
                }
            }
        }
    }

}
