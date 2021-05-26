using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace PersonalAppLibrary
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer CategoriesRefreshTimer;
        public MainWindow()
        {
            InitializeComponent();
            CategoriesRefreshTimer = new DispatcherTimer();
            CategoriesRefreshTimer.Tick += new EventHandler(CategoriesRefreshTimer_Tick);
            CategoriesRefreshTimer.Interval = new TimeSpan(0, 0, 0, 0, 250);
            CategoriesRefreshTimer.Start();
        }
        private void CategoriesRefreshTimer_Tick(object sender, EventArgs e)
        {
            int num = this.Categories.SelectedIndex;
            int num2 = this.FilesList.SelectedIndex;
            this.Categories.ItemsSource = JSONModel.GetCategories();
            if (num != -1)
            {
                this.Categories.SelectedIndex = num;
                this.FilesList.ItemsSource = JSONModel.GetCategoryFiles(this.Categories.SelectedValue.ToString());
                this.FilesList.SelectedIndex = num2;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Categories.ItemsSource = JSONModel.GetCategories();
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            FileNameWindow fileNameWindow = new FileNameWindow();
            fileNameWindow.Show();
        }

        private void RefreshCategories_Click(object sender, RoutedEventArgs e)
        {
            this.Categories.ItemsSource = JSONModel.GetCategories();
        }

        private void FileCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.FilesList.SelectedIndex != -1 && this.Categories.SelectedIndex != -1)
            {
                JSONModel.LaunchFile(this.FilesList.SelectedIndex, this.Categories.SelectedValue.ToString());
            }
        }

        private void AddFile_Click(object sender, RoutedEventArgs e)
        {
            if (Categories.SelectedIndex != -1)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {

                    JSONModel.AddToCategory(openFileDialog.FileName, Categories.SelectedValue.ToString());

                }
            }
        }

        private void UpdateFilesTable_Click(object sender, RoutedEventArgs e)
        {
            this.FilesList.ItemsSource = JSONModel.GetCategoryFiles(this.Categories.SelectedValue.ToString());
        }

        private void Categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.Categories.SelectedIndex != -1)
            {
                this.FilesList.ItemsSource = JSONModel.GetCategoryFiles(this.Categories.SelectedValue.ToString());
            }
        }

        private void GetToDirectory_Click(object sender, RoutedEventArgs e)
        {
            JSONModel.ToFileDirectory(this.FilesList.SelectedIndex, this.Categories.SelectedValue.ToString());
        }

        private void RemoveFromList_Click(object sender, RoutedEventArgs e)
        {
            JSONModel.RemoveFromCategory(this.FilesList.SelectedIndex, this.Categories.SelectedValue.ToString());
        }
    }
}
