using PolyclinicWpfApp.AppPages;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PolyclinicWpfApp.AppWindows
{
    /// <summary>
    /// Логика взаимодействия для UsersWindow.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {
        User CurrentUser; 

        public UsersWindow(User user)
        {
            InitializeComponent();
            CurrentUser = user;

            if (user.userRoleId == 1)
                infoBorder.Visibility = Visibility.Visible;
            if (user.userRoleId == 2)
                mainFrame.NavigationService.Navigate(new DoctorsPage(CurrentUser, this));
            if (user.userRoleId == 3)
                mainFrame.NavigationService.Navigate(new ReceptionistsPage(CurrentUser, this));
            if (user.userRoleId == 4)
                mainFrame.NavigationService.Navigate(new AdminPage(CurrentUser, this));
            if (user.userRoleId == 5)
                mainFrame.NavigationService.Navigate(new MainDoctorPage(CurrentUser, this));
        }
    }
}
