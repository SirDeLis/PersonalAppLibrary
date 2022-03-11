using System.Windows;
using System.IO;

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
