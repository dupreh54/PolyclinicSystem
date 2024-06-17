using PolyclinicWpfApp.AppWindows;
using PolyclinicWpfApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PolyclinicWpfApp.AppPages
{
    /// <summary>
    /// Логика взаимодействия для MainDoctorAddOrEditSchedulePage.xaml
    /// </summary>
    public partial class MainDoctorAddOrEditSchedulePage : Page
    {
        Schedule currentSchedule;
        Frame mainFunctionFrame;

        Position[] positions = PolyclinicDBEntities.GetContext().Position.ToArray();
        List<User> currentDoctorsList;

        public MainDoctorAddOrEditSchedulePage(Schedule schedule, Frame frame)
        {
            InitializeComponent();
            currentSchedule = schedule;
            mainFunctionFrame = frame;

            foreach (var position in positions)
            {
                PositionComboBox.Items.Add(position.title);
            }

            if(currentSchedule.id!=0)
            {
                for(int i=0;i<positions.Length; i++)
                {
                    if (positions[i].id== currentSchedule.positionId)
                    {
                        PositionComboBox.SelectedIndex=i; break;
                    }
                }

                if (currentDoctorsList != null)
                {
                    for(int i=0; i<currentDoctorsList.Count; i++)
                    {
                        if (currentDoctorsList[i].id==currentSchedule.userId)
                        {
                            DoctorComboBox.SelectedIndex = i;
                            break;
                        }
                    }
                }


                AppointmentTimeComboBox.Text = currentSchedule.appointmentTimeToString;

                InitializeTime();

                DataContext = currentSchedule;

            }
        }

        public void InitializeTime()
        {
            DateTime dateTimeStart = (DateTime)currentSchedule.timeStart;
            DateTime dateTimeEnd = (DateTime)currentSchedule.timeEnd;

            startHours = dateTimeStart.Hour;
            startMinutes = dateTimeStart.Minute;
            endHours = dateTimeEnd.Hour;
            endMinutes = dateTimeEnd.Minute;

            HoursDownBtn_Click(null,null);
            HoursUpBtn_Click(null,null);
            MinutesDownBtn_Click(null, null);
            MinutesUpBtn_Click(null, null);

            EndHoursDownBtn_Click(null, null);
            EndHoursUpBtn_Click(null, null);
            EndMinutesDownBtn_Click(null, null);
            EndMinutesUpBtn_Click(null, null);
        }

        private void PositionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(PositionComboBox.SelectedIndex!=-1)
            {
                DoctorComboBox.IsEnabled = true;
                Position selectedPosition = positions[PositionComboBox.SelectedIndex];
                currentDoctorsList = PolyclinicDBEntities.GetContext().User.Where(u => u.DoctorsPosition.Where(p => p.positionId == selectedPosition.id).Count()>0).ToList();

                UpdateDoctorsComboBox();
            }
        }

        public void UpdateDoctorsComboBox()
        {
            DoctorComboBox.Items.Clear();

            foreach (var User in currentDoctorsList)
            {
                DoctorComboBox.Items.Add(User.FullName);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFunctionFrame.NavigationService.Navigate(new MainDoctorSchedulePage(mainFunctionFrame));
        }

        public string CheckFields()
        {
            string misses = "";

            if (PositionComboBox.SelectedIndex == -1)
                misses += "- Не выбрана специализация врача!\n";
            if (DoctorComboBox.SelectedIndex == -1)
                misses += "- Не выбран врач!\n";
            if(ScheduleDatePicker.SelectedDate==null)
                misses += "- Не выбрана дата расписания!\n";
            if (startHours<8||startHours>19||endHours>19||endHours<8)
                misses += "- Указано некоректное время завершения или начала работы!\n";
            if (String.IsNullOrWhiteSpace(CabinetTextBox.Text))
                misses += "- Не указан кабинет!\n";
            if (AppointmentTimeComboBox.SelectedIndex == -1)
                misses += "- Не указано время на 1 приём!";

            return misses;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(CheckFields()=="")//проверка корректности заполнения полей
            {
                try
                {
                    //присвоение введённых в поля значений объекту
                    currentSchedule.positionId = positions[PositionComboBox.SelectedIndex].id;
                    currentSchedule.userId = currentDoctorsList[DoctorComboBox.SelectedIndex].id;
                    DateTime startDateTime = (DateTime)ScheduleDatePicker.SelectedDate;
                    startDateTime = startDateTime.AddHours(startDateTime.Hour).AddMinutes(startDateTime.Minute);
                    DateTime endDateTime = (DateTime)ScheduleDatePicker.SelectedDate;
                    endDateTime = endDateTime.AddHours(endDateTime.Hour).AddMinutes(endDateTime.Minute);
                    startDateTime = startDateTime.AddHours(startHours).AddMinutes(startMinutes);
                    endDateTime = endDateTime.AddHours(endHours).AddMinutes(endMinutes);
                    currentSchedule.timeStart = startDateTime;
                    currentSchedule.timeEnd = endDateTime;
                    currentSchedule.appointmentTime = new TimeSpan(0, Convert.ToInt32(AppointmentTimeComboBox.Text), 0);

                    if(currentSchedule.id==0)//добавление в базу данных в случае если переход к окну был через кнопку "Добавить"
                    {
                        PolyclinicDBEntities.GetContext().Schedule.Add(currentSchedule);
                    }

                    //сохранение данных в БД
                    PolyclinicDBEntities.GetContext().SaveChanges();
                    mainFunctionFrame.NavigationService.Navigate(new MainDoctorSchedulePage(mainFunctionFrame));
                }
                catch//обработка исключения ошибки обращения к базе данных
                {
                    MessageWindow messageWindow = new MessageWindow("Внимание!", "Возникла непредвиденная ошибка обращения к базе данных!", false);
                    messageWindow.Show();
                }
            }
            else//сообщение пользователю о некорректности заполнения полей
            {
                MessageWindow messageWindow = new MessageWindow("Внимание!", "Возникли следующие ошибки:\n"+CheckFields(), false);
                messageWindow.Show();
            }
        }

        //функции элементов ввода времени
        int startHours = 0;
        int startMinutes = 0;
        int endHours = 0;
        int endMinutes = 0;

        private void HoursUpBtn_Click(object sender, RoutedEventArgs e)
        {
            startHours++;
            if (startHours == 24)
                startHours = 0;
            if (startHours < 10)
                HoursTextBox.Text = "0" + startHours.ToString();
            else
                HoursTextBox.Text = startHours.ToString();
        }

        private void HoursDownBtn_Click(object sender, RoutedEventArgs e)
        {
            startHours--;
            if (startHours == -1)
                startHours = 23;
            if (startHours < 10)
                HoursTextBox.Text = "0" + startHours.ToString();
            else
                HoursTextBox.Text = startHours.ToString();
        }

        private void MinutesUpBtn_Click(object sender, RoutedEventArgs e)
        {
            startMinutes++;
            if (startMinutes == 60)
                startMinutes = 0;
            if (startMinutes < 10)
                MinutesTextBox.Text = "0" + startMinutes.ToString();
            else
                MinutesTextBox.Text = startMinutes.ToString();
        }

        private void MinutesDownBtn_Click(object sender, RoutedEventArgs e)
        {
            startMinutes--;
            if (startMinutes == -1)
                startMinutes = 59;
            if (startMinutes < 10)
                MinutesTextBox.Text = "0" + startMinutes.ToString();
            else
                MinutesTextBox.Text = startMinutes.ToString();
        }

        private void EndHoursUpBtn_Click(object sender, RoutedEventArgs e)
        {
            endHours++;
            if (endHours == 24)
                endHours = 0;
            if (endHours < 10)
                EndHoursTextBox.Text = "0" + endHours.ToString();
            else
                EndHoursTextBox.Text = endHours.ToString();
        }

        private void EndHoursDownBtn_Click(object sender, RoutedEventArgs e)
        {
            endHours--;
            if (endHours == -1)
                endHours = 23;
            if (endHours < 10)
                EndHoursTextBox.Text = "0" + endHours.ToString();
            else
                EndHoursTextBox.Text = endHours.ToString();
        }

        private void EndMinutesUpBtn_Click(object sender, RoutedEventArgs e)
        {
            endMinutes++;
            if (endMinutes == 60)
                endMinutes = 0;
            if (endMinutes < 10)
                EndMinutesTextBox.Text = "0" + endMinutes.ToString();
            else
                EndMinutesTextBox.Text = endMinutes.ToString();
        }

        private void EndMinutesDownBtn_Click(object sender, RoutedEventArgs e)
        {
            endMinutes--;
            if (endMinutes == -1)
                endMinutes = 59;
            if (endMinutes < 10)
                EndMinutesTextBox.Text = "0" + endMinutes.ToString();
            else
                EndMinutesTextBox.Text = endMinutes.ToString();
        }

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
                startHours = Convert.ToInt32(HoursTextBox.Text);
                if (startHours < 10 && HoursTextBox.Text.Length == 1)
                    HoursTextBox.Text = "0" + startHours.ToString();
            }
            catch
            {
                if (startHours < 10)
                    HoursTextBox.Text = "0" + startHours.ToString();
                else
                    HoursTextBox.Text = startHours.ToString();
            }
        }

        private void MinutesTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(MinutesTextBox.Text) < 0 || Convert.ToInt32(MinutesTextBox.Text) > 59)
                    throw new Exception();
                startMinutes = Convert.ToInt32(MinutesTextBox.Text);
                if (startMinutes < 10 && MinutesTextBox.Text.Length == 1)
                    MinutesTextBox.Text = "0" + startMinutes.ToString();
            }
            catch
            {
                if (startMinutes < 10)
                    MinutesTextBox.Text = "0" + startMinutes.ToString();
                else
                    MinutesTextBox.Text = startMinutes.ToString();
            }
        }

        private void EndHoursTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(EndHoursTextBox.Text) < 0 || Convert.ToInt32(EndHoursTextBox.Text) > 23)
                    throw new Exception();
                endHours = Convert.ToInt32(EndHoursTextBox.Text);
                if (endHours < 10 && EndHoursTextBox.Text.Length == 1)
                    EndHoursTextBox.Text = "0" + endHours.ToString();
            }
            catch
            {
                if (endHours < 10)
                    EndHoursTextBox.Text = "0" + endHours.ToString();
                else
                    EndHoursTextBox.Text = endHours.ToString();
            }
        }

        private void EndMinutesTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(EndMinutesTextBox.Text) < 0 || Convert.ToInt32(EndMinutesTextBox.Text) > 59)
                    throw new Exception();
                endMinutes = Convert.ToInt32(EndMinutesTextBox.Text);
                if (endMinutes < 10 && EndMinutesTextBox.Text.Length == 1)
                    EndMinutesTextBox.Text = "0" + endMinutes.ToString();
            }
            catch
            {
                if (endMinutes < 10)
                    EndMinutesTextBox.Text = "0" + endMinutes.ToString();
                else
                    EndMinutesTextBox.Text = endMinutes.ToString();
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
    }
}
