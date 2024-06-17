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
    /// Логика взаимодействия для AdminAddOrEditUserPage.xaml
    /// </summary>
    public partial class AdminAddOrEditUserPage : Page
    {
        User currentUser;
        Frame mainFunctionFrame;
        User currentEditingUser;
        Role[] roles = PolyclinicDBEntities.GetContext().Role.Where(r => r.id != 1).ToArray();

        List<Position> positions;

        public AdminAddOrEditUserPage(User user, Frame frame, User userForEditing)
        {
            InitializeComponent();
            currentUser = user;
            mainFunctionFrame = frame;
            currentEditingUser = userForEditing;

            foreach (Role role in roles)
            {
                RoleComboBox.Items.Add(role.title);
            }

            positions = GetUserPositionsList(currentEditingUser.id);

            PositionsListBox.ItemsSource = positions;

            if(userForEditing != null)
            {
                DataContext = userForEditing;
            }

        }

        public List<Position> GetUserPositionsList(int id)
        {
            List<DoctorsPosition> userPositions = PolyclinicDBEntities.GetContext().DoctorsPosition.Where(u => u.userId == id).ToList();
            List<Position> positions = PolyclinicDBEntities.GetContext().Position.ToList();
            foreach (var item in positions)
            {
                if(userPositions.Where(u=>u.positionId==item.id).Count() > 0)
                {
                    item.IsUserHaveRole= true;
                }
                else
                {
                    item.IsUserHaveRole= false;
                }
            }

            return positions;
        }

        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (roles[RoleComboBox.SelectedIndex].title=="Врач")
            {
                DoctorsPositionsGrid.Visibility = Visibility.Visible;
            }
            else
                DoctorsPositionsGrid.Visibility = Visibility.Hidden;
        }

        //анимация
        private void AddEntry_MouseEnter(object sender, MouseEventArgs e)
        {
            ColorAnimation ca = new ColorAnimation(Color.FromRgb(13, 150, 155), Color.FromRgb(16, 63, 77), new Duration(TimeSpan.FromMilliseconds(100)));
            Storyboard.SetTarget(ca, (DependencyObject)sender);
            Storyboard.SetTargetProperty(ca, new PropertyPath("Background.Color"));

            Storyboard stb = new Storyboard();
            stb.Children.Add(ca);
            stb.Begin();
        }

        private void AddEntry_MouseLeave(object sender, MouseEventArgs e)
        {
            ColorAnimation ca = new ColorAnimation(Color.FromRgb(16, 63, 77), Color.FromRgb(13, 150, 155), new Duration(TimeSpan.FromMilliseconds(100)));
            Storyboard.SetTarget(ca, (DependencyObject)sender);
            Storyboard.SetTargetProperty(ca, new PropertyPath("Background.Color"));

            Storyboard stb = new Storyboard();
            stb.Children.Add(ca);
            stb.Begin();
        }

        public string CheckFields()
        {
            string misses = "";

            if (String.IsNullOrWhiteSpace(NameTextBox.Text))
                misses += "- Поле Имя не может быть пустым!\n";
            if (String.IsNullOrWhiteSpace(SurnameTextBox.Text))
                misses += "- Поле Фамилия не может быть пустым!\n";
            if (String.IsNullOrWhiteSpace(PatronimycTextBox.Text))
                misses += "- Поле Отчество не может быть пустым!\n";
            if (String.IsNullOrWhiteSpace(LoginTextBox.Text))
                misses += "- Поле Логин не может быть пустым!\n";

            if(currentEditingUser.id==0 && PolyclinicDBEntities.GetContext().User.Any(u=>u.login == LoginTextBox.Text))
                misses += "- Пользователь с данным логином уже существует\n";

            if (positions.Where(p=>p.IsUserHaveRole==true).Count()==0 && DoctorsPositionsGrid.Visibility==Visibility.Visible)
            {
                misses += "- Врач должен иметь хотя бы 1 специализацию!\n";
            }

            return misses;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(CheckFields()=="")
            {
                try
                {
                    currentEditingUser.userRoleId = roles[RoleComboBox.SelectedIndex].id;

                    if (currentEditingUser.id == 0)
                    {
                        currentEditingUser.password = "123456";
                        PolyclinicDBEntities.GetContext().User.Add(currentEditingUser);
                    }

                    PolyclinicDBEntities.GetContext().SaveChanges();

                    if (DoctorsPositionsGrid.Visibility == Visibility.Visible)
                    {
                        PolyclinicDBEntities.GetContext().
                            DoctorsPosition.RemoveRange(
                            PolyclinicDBEntities.GetContext().
                            DoctorsPosition.Where(p => p.userId == currentEditingUser.id).ToList()
                            );

                        foreach (var item in positions)
                        {
                            if (item.IsUserHaveRole == true)
                                PolyclinicDBEntities.GetContext().DoctorsPosition.Add(new DoctorsPosition { userId = currentEditingUser.id, positionId = item.id });
                        }

                        PolyclinicDBEntities.GetContext().SaveChanges();
                    }

                    MessageWindow messageWindow = new MessageWindow("", "Успешно сохранено!", false);
                    mainFunctionFrame.NavigationService.Navigate(new AdminUsersTablePage(currentUser, mainFunctionFrame));
                    messageWindow.Show();
                }
                catch
                {
                    MessageWindow messageWindow = new MessageWindow("Внимение", "Произошла ошибка обращения к базе данных!", false);
                    messageWindow.Show();
                }
            }
            else
            {
                MessageWindow messageWindow = new MessageWindow("Внимание!", CheckFields(), false);
                messageWindow.ShowDialog();
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFunctionFrame.NavigationService.Navigate(new AdminUsersTablePage(currentUser, mainFunctionFrame));
        }

        //-------------------------------------------------------------------
    }
}
