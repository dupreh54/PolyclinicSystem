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
    /// Логика взаимодействия для NewUserChangePasswordPage.xaml
    /// </summary>
    public partial class NewUserChangePasswordPage : Page
    {
        User currentUser;
        LoginWindow loginWindow;

        public NewUserChangePasswordPage(User CurrentUser, LoginWindow LoginWindow)
        {
            InitializeComponent();
            this.currentUser = CurrentUser;
            this.loginWindow = LoginWindow;
        }

        public string CheckPassword(string Password)
        {
            string misses = "";


            if(PasswordTextBox.IsVisible)
            {
                if(PasswordTextBox.Text!=RepeatPasswordTextBox.Text)
                {
                    misses += "Пароли не совпадают!\n";
                }
            }
            else
            {
                if (PasswordBox.Password!=RepeatPasswordBox.Password) 
                {
                    misses = "Пароли не совпадают!\n";
                }
            }

            if (String.IsNullOrWhiteSpace(Password))
            {
                misses = "Необходимо заполнить поле пароля!\n";
            }

            for (int i = 0; i < Password.Length; i++)
            {
                if (i == Password.Length - 1 && !Char.IsLetter(Password[i]))
                {
                    misses += "Пароль должен содержать буквы\n";
                }
                if (Char.IsLetter(Password[i]))
                {
                    break;
                }
            }

            for (int i = 0; i < Password.Length; i++)
            {
                if (i == Password.Length - 1 && !Char.IsDigit(Password[i]))
                {
                    misses += "Пароль должен содержать цифры\n";
                }
                if (Char.IsDigit(Password[i]))
                {
                    break;
                }
            }

            return misses;
        }

        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            string password;
            if (PasswordBox.IsVisible)
                password = PasswordBox.Password;
            else
                password = PasswordTextBox.Text;

            if(CheckPassword(password)=="")
            {
                try
                {
                    currentUser.password = password;
                    PolyclinicDBEntities.GetContext().SaveChanges();
                    UsersWindow a = new UsersWindow(currentUser);
                    a.Show();
                    loginWindow.Close();
                    return;
                }
                catch
                {
                    MessageWindow messageWindow = new MessageWindow("Внимание!", "Произошла ошибка обращения к базе данных!", false);
                    messageWindow.Show();
                }
            }
            else
            {
                MessageWindow messageWindow = new MessageWindow("Внимание!",CheckPassword(password),false);
                messageWindow.Show();
            }
        }


        //кнопки смены видимости пароля
        private void PasswordHideBtn_Click(object sender, RoutedEventArgs e)//изменение видимости элментов для демонстрации пароля
        {
            PasswordHideBtn.Visibility = Visibility.Hidden;
            PasswordViewBtn.Visibility = Visibility.Visible;
            PasswordTextBox.Text = PasswordBox.Password;
            RepeatPasswordTextBox.Text = RepeatPasswordBox.Password;
            PasswordBox.Visibility = Visibility.Hidden;
            RepeatPasswordBox.Visibility = Visibility.Hidden;
            PasswordTextBox.Visibility = Visibility.Visible;
            RepeatPasswordTextBox.Visibility = Visibility.Visible;
        }

        private void PasswordViewBtn_Click(object sender, RoutedEventArgs e)//изменение видимости элментов для скрытия пароля
        {
            PasswordViewBtn.Visibility = Visibility.Hidden;
            PasswordHideBtn.Visibility = Visibility.Visible;
            PasswordBox.Password = PasswordTextBox.Text;
            RepeatPasswordBox.Password = RepeatPasswordTextBox.Text;
            PasswordBox.Visibility = Visibility.Visible;
            RepeatPasswordBox.Visibility = Visibility.Visible;
            PasswordTextBox.Visibility = Visibility.Hidden;
            RepeatPasswordTextBox.Visibility = Visibility.Hidden;
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
    }
}
