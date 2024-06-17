using PolyclinicWpfApp.AppPages;
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
using System.Windows.Shapes;

namespace PolyclinicWpfApp.AppWindows
{
    /// <summary>
    /// Логика взаимодействия для MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public MessageWindow(string MessageTitle, string MessageText, bool IsYesNoDialogWindow)
        {
            InitializeComponent();
            MessageTitleTB.Text = MessageTitle;
            MessageTextTB.Text = MessageText;

            if (IsYesNoDialogWindow)
            {
                YesNoBtnsGrid.Visibility = Visibility.Visible;
                OkBtn.Visibility = Visibility.Hidden;
            }
        }

        //SchedulePage currentPage;
        DoctorsAppointmentPage currentPage;
        AdminUsersTablePage currentPage2;
        MainDoctorSchedulePage currentPage3;

        public MessageWindow(string MessageTitle, string MessageText, bool IsYesNoDialogWindow, DoctorsAppointmentPage PageFromResult)
        {
            InitializeComponent();
            MessageTitleTB.Text = MessageTitle;
            MessageTextTB.Text = MessageText;
            currentPage = PageFromResult;

            if (IsYesNoDialogWindow)
            {
                YesNoBtnsGrid.Visibility = Visibility.Visible;
                OkBtn.Visibility = Visibility.Hidden;
            }
        }

        public MessageWindow(string MessageTitle, string MessageText, bool IsYesNoDialogWindow, MainDoctorSchedulePage PageFromResult)
        {
            InitializeComponent();
            MessageTitleTB.Text = MessageTitle;
            MessageTextTB.Text = MessageText;
            currentPage3 = PageFromResult;

            if (IsYesNoDialogWindow)
            {
                YesNoBtnsGrid.Visibility = Visibility.Visible;
                OkBtn.Visibility = Visibility.Hidden;
            }
        }

        public MessageWindow(string MessageTitle, string MessageText, bool IsYesNoDialogWindow, AdminUsersTablePage PageFromResult)
        {
            InitializeComponent();
            MessageTitleTB.Text = MessageTitle;
            MessageTextTB.Text = MessageText;
            currentPage2 = PageFromResult;

            if (IsYesNoDialogWindow)
            {
                YesNoBtnsGrid.Visibility = Visibility.Visible;
                OkBtn.Visibility = Visibility.Hidden;
            }
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public int DialogResult = 0;
        //0 - ожидание
        //1 - да
        //2 - нет

        public void GetDialogResult()
        {
            if(currentPage!=null)
                currentPage.dialogResult = DialogResult;
            if(currentPage2!=null)
                currentPage2.dialogResult = DialogResult;
            if (currentPage3 != null)
                currentPage3.dialogResult = DialogResult;
            this.Close();
        }

        private void YesBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = 1;
            GetDialogResult();
        }

        private void NoBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = 2;            
            GetDialogResult();
        }

        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
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
    }
}
