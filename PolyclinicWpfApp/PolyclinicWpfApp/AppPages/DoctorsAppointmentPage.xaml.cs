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
    /// Логика взаимодействия для DoctorsAppointmentPage.xaml
    /// </summary>
    public partial class DoctorsAppointmentPage : Page
    {
        AdmissionTicket currentTicket;
        Frame mainFunctionFrame;
        User currentDoctor;

        public DoctorsAppointmentPage(AdmissionTicket ticket, Frame frame, User doctor)
        {
            InitializeComponent();
            currentTicket = ticket;
            mainFunctionFrame = frame;
            currentDoctor = doctor;

            PatientFullNameTB.Text = ticket.User.FullName;
            PatientMedicalPolicyTB.Text = ticket.User.medicalPolicy;
            ComplaintsTB.Text = ticket.complaints;
            AppointmentResultTextBox.Text = ticket.appointmentResult;
        }

        public int dialogResult = 0;

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrWhiteSpace(AppointmentResultTextBox.Text))
                mainFunctionFrame.NavigationService.Navigate(new DoctorsEntriesListPage(currentDoctor, mainFunctionFrame));
            else
            {
                MessageWindow messageWindow = new MessageWindow("Внимание!", "Вы хотите сохранить изменения данной записи?", true, this);
                messageWindow.ShowDialog();
                this.IsEnabled = false;
                if (dialogResult == 1)
                {
                    currentTicket.appointmentResult = AppointmentResultTextBox.Text;
                    PolyclinicDBEntities.GetContext().SaveChanges();
                    mainFunctionFrame.NavigationService.Navigate(new DoctorsEntriesListPage(currentDoctor, mainFunctionFrame));
                }
                else
                {
                    mainFunctionFrame.NavigationService.Navigate(new DoctorsEntriesListPage(currentDoctor, mainFunctionFrame));
                }
            }
        }

        private void OverdueStateBtn_Click(object sender, RoutedEventArgs e)
        {
            currentTicket.appointmentResult = AppointmentResultTextBox.Text;
            currentTicket.currentStateId = 5;
            PolyclinicDBEntities.GetContext().SaveChanges();
        }

        private void CompletedStateBtn_Click(object sender, RoutedEventArgs e)
        {
            currentTicket.appointmentResult = AppointmentResultTextBox.Text;
            currentTicket.currentStateId = 4;
            PolyclinicDBEntities.GetContext().SaveChanges();
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
