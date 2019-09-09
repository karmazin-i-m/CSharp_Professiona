using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.IO;
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
using Xceed.Wpf.Toolkit;

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
            this.ColorPicker.SelectedColorChanged += ColorPicker_SelectedColorChanged;
            initializeColor();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            using (IsolatedStorageFile fileStorage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                using (IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream("UsersSetings.txt", FileMode.Create, fileStorage))
                {
                    using(StreamWriter streamWriter = new StreamWriter(fileStream))
                    {
                        streamWriter.Write(ColorPicker.SelectedColor.ToString());
                    }
                }
            }
            TextBox.Text += "Изменения сохранены!\n";
        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            this.TextBox.Background = (Brush) new BrushConverter().ConvertFrom(e.NewValue.ToString());
            TextBox.Text += $"Установлен цвет фона: {e.NewValue.ToString()}\n";
        }

        private void initializeColor()
        {
            using (IsolatedStorageFile fileStorage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                
                using (IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream("UsersSetings.txt", FileMode.Open, fileStorage))
                {
                    if (fileStorage.FileExists("UsersSetings.txt"))
                    {
                        TextBox.Text += "Найден файл с настройками!\n";
                        using (StreamReader streamReader = new StreamReader(fileStream))
                        {
                            string color = streamReader.ReadToEnd();
                            this.TextBox.Background = (Brush)new BrushConverter().ConvertFrom(color);
                            TextBox.Text += $"Восстановлен цвет фона: {color}\n";
                        }
                    } 
                }
            }
        }
    }
}
