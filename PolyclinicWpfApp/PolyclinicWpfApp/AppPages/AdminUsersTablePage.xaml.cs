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
    /// Логика взаимодействия для AdminUsersTablePage.xaml
    /// </summary>
    public partial class AdminUsersTablePage : Page
    {
        User currentUser;
        Frame mainFunctionFrame;
        List<User> allUsers;
        Role[] allRoles = PolyclinicDBEntities.GetContext().Role.Where(r=>r.id!=1).ToArray();

        public AdminUsersTablePage(User user, Frame frame)
        {
            InitializeComponent();
            currentUser = user;
            mainFunctionFrame = frame;

            allUsers = PolyclinicDBEntities.GetContext().User.Where(u=>u.id!=user.id&&u.userRoleId!=1).ToList();

            foreach(var Role in allRoles)
            {
                RoleComboBox.Items.Add(Role.title);
            }

            RoleComboBox.SelectedIndex = 0;
        }

        public void UpdateTable()
        {
            var filteredUsers = allUsers;
            UsersDataGrid.Items.Clear();

            if(RoleComboBox.SelectedIndex!=-1)
            {
                if(RoleComboBox.SelectedIndex==0)
                    filteredUsers= allUsers;
                if (RoleComboBox.SelectedIndex >= 1)
                    filteredUsers = filteredUsers.Where(u=>u.Role.title == RoleComboBox.SelectedItem.ToString()).ToList();
            }

            if(!String.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                filteredUsers = filteredUsers.Where(u => u.login.ToLower().Contains(SearchTextBox.Text.ToLower()) || u.FullName.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            }

            foreach (var user in filteredUsers)
            {
                UsersDataGrid.Items.Add(user);
            }
        }

        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTable();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTable();
        }

        private void EditUserButton_Click(object sender, RoutedEventArgs e)
        {
            mainFunctionFrame.NavigationService.Navigate(new AdminAddOrEditUserPage(currentUser, mainFunctionFrame, (sender as Button).DataContext as User));
        }

        //анимации
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

        public int dialogResult = 0;

        private void RemoveUserButton_Click(object sender, RoutedEventArgs e)
        {
            if(UsersDataGrid.SelectedItems.Count>0)
            {
                var usersForRemoving = UsersDataGrid.SelectedItems.Cast<User>().ToList();

                MessageWindow messageWindow = new MessageWindow("Внимание!", "При удалении пользователя с ролью врач, также будут удалены все данные о нём. Вы действительно хотите продолжить?", true, this);
                messageWindow.ShowDialog();

                if(dialogResult==1)
                {
                    try
                    {
                        foreach(var user in usersForRemoving)
                        {
                            if(user.userRoleId==2)
                            {
                                PolyclinicDBEntities.GetContext()
                                    .DoctorsPosition.RemoveRange(
                                    PolyclinicDBEntities.GetContext().DoctorsPosition.Where(u => u.userId == user.id).ToList());
                                PolyclinicDBEntities.GetContext()
                                    .AdmissionTicket.RemoveRange(
                                    PolyclinicDBEntities.GetContext().AdmissionTicket.Where(u => u.specialistId == user.id).ToList());
                                PolyclinicDBEntities.GetContext().SaveChanges();
                            }
                        }
                        PolyclinicDBEntities.GetContext().User.RemoveRange(usersForRemoving);
                        PolyclinicDBEntities.GetContext().SaveChanges();
                        allUsers = PolyclinicDBEntities.GetContext().User.Where(u => u.id != currentUser.id).ToList();
                        UpdateTable();
                    }
                    catch
                    {
                        MessageWindow errorMessageWindow = new MessageWindow("Внимание!", "Произошла непредвиденная ошибка!", false);
                        errorMessageWindow.ShowDialog();
                    }
                }
            }
            else
            {
                MessageWindow messageWindow = new MessageWindow("Внимание!", "Для удаления необходимо выделить пользователя в таблице, для выделения нескольких: зажмите клавишу Shift.", false);
                messageWindow.ShowDialog();
            }    
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            mainFunctionFrame.NavigationService.Navigate(new AdminAddOrEditUserPage(currentUser, mainFunctionFrame,new User()));
        }
    }
}
