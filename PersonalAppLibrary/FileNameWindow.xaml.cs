using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Newtonsoft.Json;

namespace PersonalAppLibrary
{
    /// <summary>
    /// Логика взаимодействия для FileNameWindow.xaml
    /// </summary>
    public partial class FileNameWindow : Window
    {
        private static string path = Directory.GetCurrentDirectory().ToString() + @"\Categories";
        public FileNameWindow()
        {
            InitializeComponent();
        }
        

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            var createdFile = File.Create(Directory.GetCurrentDirectory().ToString() + @"\Categories\" + CategoryName.Text + ".bar");
            createdFile.Close();
            this.Close();
        }
    }
}
