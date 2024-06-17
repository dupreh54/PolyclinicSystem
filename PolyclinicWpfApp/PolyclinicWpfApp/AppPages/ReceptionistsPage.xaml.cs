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
    /// Логика взаимодействия для ReceptionistsPage.xaml
    /// </summary>
    public partial class ReceptionistsPage : Page
    {
        UsersWindow CurrentWindow;

        public ReceptionistsPage(User User, UsersWindow WindowForPage)
        {
            InitializeComponent();
            CurrentWindow = WindowForPage;

            FunctionFrame.NavigationService.Navigate(new ReceptionistsEntriesListPage(FunctionFrame));

            if (User.FullName!=null)
            {
                UserFullNameTB.Text = User.FullName;
            }
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
            CurrentWindow.Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => CurrentWindow.DragMove();

        private void windowHideBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrentWindow.WindowState = WindowState.Minimized;
        }

        private void windowMaxMinBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentWindow.WindowState == WindowState.Maximized)
                CurrentWindow.WindowState = WindowState.Normal;
            else
            {
                CurrentWindow.WindowState = WindowState.Maximized;
            }
        }

        private void windowCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrentWindow.Close();
        }
    }
}
