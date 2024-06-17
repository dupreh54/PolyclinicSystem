using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using PolyclinicWpfApp.AppWindows;
using PolyclinicWpfApp.Database;

namespace PolyclinicWpfApp.AppPages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        LoginWindow thisWindow;

        public AuthorizationPage(LoginWindow Window)
        {
            InitializeComponent();
            thisWindow = Window;

            //автоматическая авторизация для отладки
            //LoginTextBox.Text = "maindoctor";
            //PasswordBox.Password = "maindoctor";
            //LoginBtn_Click(new object(), new RoutedEventArgs());
        }

        private void PasswordHideBtn_Click(object sender, RoutedEventArgs e)//изменение видимости элментов для демонстрации пароля
        {
            PasswordHideBtn.Visibility = Visibility.Hidden;
            PasswordViewBtn.Visibility = Visibility.Visible;
            PasswordTextBox.Text = PasswordBox.Password;
            PasswordBox.Visibility = Visibility.Hidden;
            PasswordTextBox.Visibility = Visibility.Visible;
        }

        private void PasswordViewBtn_Click(object sender, RoutedEventArgs e)//изменение видимости элментов для скрытия пароля
        {
            PasswordViewBtn.Visibility = Visibility.Hidden;
            PasswordHideBtn.Visibility = Visibility.Visible;
            PasswordBox.Password = PasswordTextBox.Text;
            PasswordBox.Visibility = Visibility.Visible;
            PasswordTextBox.Visibility = Visibility.Hidden;
        }

        public string GenerateCaptcha()//метод генерации строки с капчей
        {
            string allowchar = " ";
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";

            char[] a = { ',' };
            string[] ar = allowchar.Split(a);

            string pwd = " ";
            string temp = " ";

            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                temp = ar[(r.Next(0, ar.Length))];
                pwd += temp;
            }

            return pwd;
        }

        public void ShowCaptchaDialog(bool CaptchaVisibility)//группировка интерфейса для демонстрации модуля капчи
        {
            if (CaptchaVisibility)
            {
                Grid.SetRowSpan(LoginBlock, 1);
                Grid.SetRowSpan(PasswordBlock, 1);
                Grid.SetRowSpan(LoginTextBox, 1);
                Grid.SetRowSpan(PasswordTextBox, 1);
                Grid.SetRowSpan(PasswordBox, 1);
                Grid.SetRowSpan(PasswordHideBtn, 1);
                Grid.SetRowSpan(PasswordViewBtn, 1);


                ShowCapchaImage(true);
                UpdateBtn_Click(null, new RoutedEventArgs());
            }
            else
            {
                Grid.SetRowSpan(LoginBlock, 2);
                Grid.SetRowSpan(PasswordBlock, 2);
                Grid.SetRowSpan(LoginTextBox, 2);
                Grid.SetRowSpan(PasswordTextBox, 2);
                Grid.SetRowSpan(PasswordBox, 2);
                Grid.SetRowSpan(PasswordHideBtn, 2);
                Grid.SetRowSpan(PasswordViewBtn, 2);

                ShowCapchaImage(false);
            }
        }

        public void ShowCapchaImage(bool isVisible)//изменение видимости модуля интерфейса капчи
        {
            if (isVisible)
            {
                captchaGrid.Visibility = Visibility.Visible;
            }
            else
            {
                captchaGrid.Visibility = Visibility.Hidden;
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

        private User LogIn(string Login, string Password)
        {
            User currentUser = null;

            try
            {
                //поиск пользователя в БД
                currentUser = PolyclinicDBEntities.GetContext().User.Where(
                    u => u.login == Login && u.password == Password && u.userRoleId!=1
                    ).FirstOrDefault();
            }
            catch
            {
                MessageWindow message = new MessageWindow("Внимание!", "Ошибка обращения к базе данных!", false);
                message.Show();
            }

            return currentUser;
        }

        int LoginAttempts = 0;//попытки входа

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            //переменные хранящие введённые данные
            var login = LoginTextBox.Text;
            var password = PasswordTextBox.Text;
            if (PasswordBox.IsVisible)//проверка скрытости пароля
                password = PasswordBox.Password;

            User currentUser = LogIn(login, password);

            if (currentUser!=null)
            {
                if(currentUser.password=="123456")//переход к странице смены пароля, если пользователь новый
                {
                    thisWindow.MainFrame.NavigationService.Navigate(new NewUserChangePasswordPage(currentUser, thisWindow));
                }
                else
                {
                    //открытие окна пользователей
                    UsersWindow a = new UsersWindow(currentUser);
                    a.Show();
                    thisWindow.Close();
                    return;
                }
            }
            else
            {
                //вывод сообщения об ошибке
                MessageWindow message = new MessageWindow("Внимание!", "Неверный логин или пароль!", false);
                message.Show();
                //фиксация попытки входа
                LoginAttempts++;
                //выведение блока CAPTCHA в случае если
                //было произведенно более 2-х неудачных попыток входа
                if (LoginAttempts > 2)
                {
                    LoginBtn.IsEnabled = false;
                    ShowCaptchaDialog(true);
                }
            }
        }

        public void UpdateBtn_Click(object sender, RoutedEventArgs e)//рандомизация свойств элементов капчи
        {
            string HardCaptcha = GenerateCaptcha();
            if (HardCaptcha.Length > 6)
                HardCaptcha = HardCaptcha.Substring(0, 7);
            TextBlock3.Text = HardCaptcha.Substring(0, HardCaptcha.Length - 3);
            TextBlock4.Text = GenerateCaptcha().Substring(4);
            Random random = new Random();
            RandomLine.Y2 = random.Next(13, 50);
            RandomLine.Y1 = random.Next(13, 50);
            Color RandomColor = Color.FromRgb(Convert.ToByte(random.Next(0, 255)), Convert.ToByte(random.Next(0, 255)), Convert.ToByte(random.Next(0, 255)));
            RandomLine.Stroke = new SolidColorBrush(RandomColor);
            TextBlock3.Foreground = new SolidColorBrush(Color.FromRgb(Convert.ToByte(random.Next(0, 255)), Convert.ToByte(random.Next(0, 255)), Convert.ToByte(random.Next(0, 255))));
            Thread.Sleep(50);
            TextBlock4.Foreground = new SolidColorBrush(Color.FromRgb(Convert.ToByte(random.Next(0, 255)), Convert.ToByte(random.Next(0, 255)), Convert.ToByte(random.Next(0, 255))));
        }


        public void BlockLogin()
        {
            LoginBlockInfo.Visibility = Visibility.Visible;
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            ShowCaptchaDialog(false);
        }

        int SecondsBlock = 60;

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            SecondsBlock--;
            if (SecondsBlock < 0)
            {
                dispatcherTimer.Stop();
                SecondsBlock = 60;

                LoginBlockInfo.Visibility = Visibility.Hidden;
                ShowCaptchaDialog(true);
            }
            if (SecondsBlock >= 10)
                LoginBlockInfo.Text = "Вход заблокирован на 0:" + SecondsBlock.ToString();
            else
                LoginBlockInfo.Text = "Вход заблокирован на 0:0" + SecondsBlock.ToString();
        }


        private void CheckCaptchaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TextBlock3.Text + TextBlock4.Text == " " + CaptchaTextBox.Text)
            {
                MessageWindow message = new MessageWindow("", "Проверка пройдена!", false);
                message.Show();
                CaptchaTextBox.Clear();
                ShowCaptchaDialog(false);
                LoginBtn.IsEnabled = true;
            }
            else
            {
                BlockLogin();
                MessageWindow message = new MessageWindow("Внимание!", "Проверка не пройдена! Вход заблокирован.", false);
                message.Show();
            }
        }

        private void windowHideBtn_Click(object sender, RoutedEventArgs e)
        {
            thisWindow.WindowState = WindowState.Minimized;
        }


        private void windowCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            thisWindow.Close();
        }

        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            thisWindow.DragMove();
        }

    }
}
