using PolyclinicWpfApp.AppWindows;
using PolyclinicWpfApp.Database;
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
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PolyclinicWpfApp.AppPages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        UsersWindow currentWindow;
        User currentUser;

        public AdminPage(User User, UsersWindow WindowForPage)
        {
            InitializeComponent();

            currentWindow = WindowForPage;
            currentUser = User;

            FunctionFrame.NavigationService.Navigate(new AdminUsersTablePage(currentUser,FunctionFrame));
        }

        private void ExitBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            ColorAnimation ca = new ColorAnimation(Color.FromRgb(13, 150, 155), Color.FromRgb(16, 63, 77), new Duration(TimeSpan.FromMilliseconds(100)));
            Storyboard.SetTarget(ca, (DependencyObject)sender);
            Storyboard.SetTargetProperty(ca, new PropertyPath("Background.Color"));

            Storyboard stb = new Storyboard();
            stb.Children.Add(ca);
            stb.Begin();
        }

        private void ExitBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            ColorAnimation ca = new ColorAnimation(Color.FromRgb(16, 63, 77), Color.FromRgb(13, 150, 155), new Duration(TimeSpan.FromMilliseconds(100)));
            Storyboard.SetTarget(ca, (DependencyObject)sender);
            Storyboard.SetTargetProperty(ca, new PropertyPath("Background.Color"));

            Storyboard stb = new Storyboard();
            stb.Children.Add(ca);
            stb.Begin();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            currentWindow.Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => currentWindow.DragMove();

        private void windowHideBtn_Click(object sender, RoutedEventArgs e)
        {
            currentWindow.WindowState = WindowState.Minimized;
        }

        private void windowMaxMinBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentWindow.WindowState == WindowState.Maximized)
                currentWindow.WindowState = WindowState.Normal;
            else
            {
                currentWindow.WindowState = WindowState.Maximized;
            }
        }

        private void windowCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            currentWindow.Close();
        }
    }
}
