using GiniHomeTaskUI.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace GiniHomeTaskUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
               messageTB.Text=await SearchService.GetRepositoryInfo(queryTB.Text);
            }
        }

        private async void searchBN_Click(object sender, RoutedEventArgs e)
        {
            SearchService.GetRepositoryInfo(queryTB.Text);
        }

        private void bookmarkBN_Click(object sender, RoutedEventArgs e)
        {
            var bookmark = new Bookmarks
            {
                Owner = this
            }; //create your new form.

            bookmark.Show(); //show the new form.
        }
    }
}
