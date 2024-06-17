using PolyclinicWpfApp.AppWindows;
using PolyclinicWpfApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для ReceptionistsEntryEditingPage.xaml
    /// </summary>
    public partial class ReceptionistsEntryEditingPage : Page
    {
        AdmissionTicket currentTicket;
        Frame mainFunctionFrame;

        User[] doctors;
        TicketState[] ticketStates = PolyclinicDBEntities.GetContext().TicketState.ToArray();

        public ReceptionistsEntryEditingPage(AdmissionTicket ticket, Frame frame)
        {
            InitializeComponent();
            currentTicket = ticket;
            mainFunctionFrame = frame;
            doctors = PolyclinicDBEntities.GetContext()
                .User.Where(u => u.DoctorsPosition.Where(p => p.positionId == ticket.doctorPositionId).Count() > 0).ToArray();
            
            foreach(User user in doctors)
            {
                DoctorsComboBox.Items.Add(user.FullName);
            }

            foreach(TicketState ticketState in ticketStates)
            {
                TicketStateComboBox.Items.Add(ticketState.title);
            }

            if(ticket!=null)
            {
                for(int i = 0; i < doctors.Length; i++)
                {
                    if (doctors[i].id == ticket.specialistId)
                    {
                        DoctorsComboBox.SelectedIndex = i; break;
                    }
                }

                for(int i =0; i<ticketStates.Length; i++)
                {
                    if (ticketStates[i].id==ticket.currentStateId)
                    {
                        TicketStateComboBox.SelectedIndex = i; break;
                    }
                }

                DateTime dateTime = (DateTime)ticket.receiptDate;

                ReceiptDatePicker.SelectedDate = dateTime;

                Hours = dateTime.Hour;
                HoursUpBtn_Click(null, null);
                HoursDownBtn_Click(null, null);
                Minutes = dateTime.Minute;
                MinutesUpBtn_Click(null, null);
                MinutesDownBtn_Click(null, null);
            }

            DataContext = currentTicket;
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
        //-------------------------------------------------------------------

        //события элемента выбора времени----------------------------------
        int Hours = 0;

        int Minutes = 0;

        private void HoursUpBtn_Click(object sender, RoutedEventArgs e)
        {
            Hours++;
            if (Hours == 24)
                Hours = 0;
            if (Hours < 10)
                HoursTextBox.Text = "0" + Hours.ToString();
            else
                HoursTextBox.Text = Hours.ToString();
        }

        private void HoursDownBtn_Click(object sender, RoutedEventArgs e)
        {
            Hours--;
            if (Hours == -1)
                Hours = 23;
            if (Hours < 10)
                HoursTextBox.Text = "0" + Hours.ToString();
            else
                HoursTextBox.Text = Hours.ToString();
        }

        private void MinutesUpBtn_Click(object sender, RoutedEventArgs e)
        {
            Minutes++;
            if (Minutes == 60)
                Minutes = 0;
            if (Minutes < 10)
                MinutesTextBox.Text = "0" + Minutes.ToString();
            else
                MinutesTextBox.Text = Minutes.ToString();
        }

        private void MinutesDownBtn_Click(object sender, RoutedEventArgs e)
        {
            Minutes--;
            if (Minutes == -1)
                Minutes = 59;
            if (Minutes < 10)
                MinutesTextBox.Text = "0" + Minutes.ToString();
            else
                MinutesTextBox.Text = Minutes.ToString();
        }

        public string CheckFields()
        {
            string misses = "";
            if (DoctorsComboBox.SelectedIndex == -1)
                misses += "- Не выбран врач!\n";
            if (ReceiptDatePicker.SelectedDate == null) 
                misses += "- Не выбрана дата приёма!\n";
            if (Hours < 8 || Hours > 18)
                misses += "- Указано не корректное время приёма!\n";
            if (String.IsNullOrWhiteSpace(cabinetNumberTextBox.Text)) 
                misses += "- Не указан кабинет для приёма!";

            return misses;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(CheckFields()=="")
            {
                try
                {
                    currentTicket.specialistId = doctors[DoctorsComboBox.SelectedIndex].id;
                    DateTime receiptDateTime = (DateTime)ReceiptDatePicker.SelectedDate;
                    receiptDateTime = receiptDateTime.AddMinutes(-receiptDateTime.Minute).AddHours(-receiptDateTime.Hour);
                    receiptDateTime = receiptDateTime.AddHours(Hours).AddMinutes(Minutes);
                    currentTicket.receiptDate = receiptDateTime;
                    currentTicket.currentStateId = ticketStates[TicketStateComboBox.SelectedIndex].id;
                    PolyclinicDBEntities.GetContext().SaveChanges();
                    mainFunctionFrame.NavigationService.Navigate(new ReceptionistsEntriesListPage(mainFunctionFrame));
                }
                catch
                {
                    MessageWindow messageWindow = new MessageWindow("Внимание!", "Произошла ошибка обращения к базе данных!",false);
                    messageWindow.ShowDialog();
                }
            }
            else
            {
                MessageWindow messageWindow = new MessageWindow("Внимание!", CheckFields(), false);
                messageWindow.ShowDialog();
            }
        }
        //-------------------------------------------------------------------
        //ручной ввод времени
        private static readonly Regex _regex = new Regex("[^0-9]+"); //регулярное выражение для строки содержащей только цифры

        private static bool IsTextAllowed(string text)//метод проверяющий содержит ли строка цифры
        {
            return !_regex.IsMatch(text);
        }

        private void HoursTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(HoursTextBox.Text) < 0 || Convert.ToInt32(HoursTextBox.Text) > 23)
                    throw new Exception();
                Hours = Convert.ToInt32(HoursTextBox.Text);
                if (Hours < 10 && HoursTextBox.Text.Length == 1)
                    HoursTextBox.Text = "0" + Hours.ToString();
            }
            catch
            {
                if (Hours < 10)
                    HoursTextBox.Text = "0" + Hours.ToString();
                else
                    HoursTextBox.Text = Hours.ToString();
            }
        }

        private void MinutesTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(MinutesTextBox.Text) < 0 || Convert.ToInt32(MinutesTextBox.Text) > 59)
                    throw new Exception();
                Minutes = Convert.ToInt32(MinutesTextBox.Text);
                if (Minutes < 10 && MinutesTextBox.Text.Length == 1)
                    MinutesTextBox.Text = "0" + Minutes.ToString();
            }
            catch
            {
                if (Minutes < 10)
                    MinutesTextBox.Text = "0" + Minutes.ToString();
                else
                    MinutesTextBox.Text = Minutes.ToString();
            }
        }

        private void MinutesTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void HoursTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFunctionFrame.NavigationService.Navigate(new ReceptionistsEntriesListPage(mainFunctionFrame));
        }
        //-------------------------------------------------------------------
    }
}
