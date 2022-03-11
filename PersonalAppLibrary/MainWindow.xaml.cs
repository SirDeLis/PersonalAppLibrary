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
        //DispatcherTimer CategoriesRefreshTimer;
        public MainWindow()
        {
            InitializeComponent();
            //CategoriesRefreshTimer = new DispatcherTimer();
            //CategoriesRefreshTimer.Tick += new EventHandler(CategoriesRefreshTimer_Tick);
            //CategoriesRefreshTimer.Interval = new TimeSpan(0, 0, 0, 0, 250);
            //CategoriesRefreshTimer.Start();
        }
        //private void CategoriesRefreshTimer_Tick(object sender, EventArgs e)
        //{
        //    int num = this.Categories.SelectedIndex;
        //    int num2 = this.FilesList.SelectedIndex;
        //    this.Categories.ItemsSource = DBModel.GetCategories();
        //    if (num != -1)
        //    {
        //        this.Categories.SelectedIndex = num;
        //        this.FilesList.ItemsSource = DBModel.GetCategoryFiles(this.Categories.SelectedValue.ToString());
        //        this.FilesList.SelectedIndex = num2;
        //    }
        //}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Categories.ItemsSource = DBModel.GetCategories();
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            FileNameWindow fileNameWindow = new FileNameWindow();
            fileNameWindow.Show();
        }

        private void RefreshCategories_Click(object sender, RoutedEventArgs e)
        {
            this.Categories.ItemsSource = DBModel.GetCategories();
        }

        private void FileCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.FilesList.SelectedIndex != -1 && this.Categories.SelectedIndex != -1)
            {
                DBModel.LaunchFile(this.FilesList.SelectedIndex, this.Categories.SelectedValue.ToString());
            }
        }

        private void AddFile_Click(object sender, RoutedEventArgs e)
        {
            if (Categories.SelectedIndex != -1)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {

                    DBModel.AddToCategory(openFileDialog.FileName, Categories.SelectedValue.ToString());
                    this.FilesList.ItemsSource = DBModel.GetCategoryFiles(this.Categories.SelectedValue.ToString());

                }
            }
            else
            {
                MessageBox.Show("Choose or create category first", "No chosen category", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RemoveFromList_Click(object sender, RoutedEventArgs e)
        {
            if (this.Categories.SelectedIndex != -1)
            {
                DBModel.RemoveFromCategory(this.FilesList.SelectedIndex, this.Categories.SelectedValue.ToString());
                this.FilesList.ItemsSource = DBModel.GetCategoryFiles(this.Categories.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show("Choose category and file first", "No chosen file", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void UpdateFilesTable_Click(object sender, RoutedEventArgs e)
        {
            if (this.Categories.SelectedIndex != -1)
            {
                this.FilesList.ItemsSource = DBModel.GetCategoryFiles(this.Categories.SelectedValue.ToString());
            }
        }

        private void Categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.Categories.SelectedIndex != -1)
            {
                this.FilesList.ItemsSource = DBModel.GetCategoryFiles(this.Categories.SelectedValue.ToString());
            }
        }

        private void GetToDirectory_Click(object sender, RoutedEventArgs e)
        {
            if (this.Categories.SelectedIndex != -1)
            {
                DBModel.ToFileDirectory(this.FilesList.SelectedIndex, this.Categories.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show("Choose category and file first", "No chosen file", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        

        private void RemoveCategory_Click(object sender, RoutedEventArgs e)
        {
            if (this.Categories.SelectedIndex != -1)
            {
                string chosencat = this.Categories.SelectedValue.ToString();
                this.Categories.SelectedIndex = -1;
                DBModel.RemoveCategory(chosencat);
            }
            else
            {
                MessageBox.Show("Choose category first", "No chosen category", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
