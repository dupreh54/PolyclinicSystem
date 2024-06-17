using PolyclinicWpfApp.AppWindows;
using PolyclinicWpfApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Логика взаимодействия для MainDoctorSchedulePage.xaml
    /// </summary>
    public partial class MainDoctorSchedulePage : Page
    {
        List<Schedule> allSchedulesList;
        Frame mainFunctionFrame;

        Position[] positions = PolyclinicDBEntities.GetContext().Position.ToArray();

        public MainDoctorSchedulePage(Frame frame)
        {
            InitializeComponent();
            mainFunctionFrame = frame;

            allSchedulesList = PolyclinicDBEntities.GetContext().Schedule.ToList();

            foreach(var Position in positions)
            {
                SpecialityComboBox.Items.Add(Position.title);
            }

            SpecialityComboBox.SelectedIndex = 0;
        }

        public void UpdateTable()
        {
            var filteredList = allSchedulesList;

            ScheduleDataGrid.Items.Clear();

            if (SpecialityComboBox.SelectedIndex != -1)
            {
                if (SpecialityComboBox.SelectedIndex > 0)
                    filteredList = filteredList.Where(s => s.positionId == positions[SpecialityComboBox.SelectedIndex].id).ToList();
                else
                    filteredList = allSchedulesList;
            }

            if (ScheduleDatePicker.SelectedDate != null)
            {
                filteredList = allSchedulesList.Where(t => t.ShortDate == ScheduleDatePicker.SelectedDate).ToList();
            }


            if (!String.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                filteredList = filteredList.Where(t => t.User.FullName.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            }

            foreach (var schedule in filteredList)
            {
                ScheduleDataGrid.Items.Add(schedule);
            }
        }

        private void SpecialityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTable();
        }

        private void ScheduleDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTable();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTable();
        }

        private void AddScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            mainFunctionFrame.NavigationService.Navigate(new MainDoctorAddOrEditSchedulePage(new Schedule(), mainFunctionFrame));
        }

        private void EditScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            mainFunctionFrame.NavigationService.Navigate(new MainDoctorAddOrEditSchedulePage((sender as Button).DataContext as Schedule, mainFunctionFrame));
        }

        public int dialogResult = 0;

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            //проверка выделены ли строки в таблице
            if (ScheduleDataGrid.SelectedItems.Count > 0)
            {
                //переменная хранящая объекты расписания для удаления
                var schedulesForRemoving = ScheduleDataGrid.SelectedItems.Cast<Schedule>().ToList();

                //запрос подтверждения пользователя
                MessageWindow messageWindow = new MessageWindow("Внимание!", "Вы действительно хотите продолжить удаление?", true, this);
                messageWindow.ShowDialog();

                if (dialogResult == 1)
                {
                    try
                    {
                        //удаление объектов из БД
                        PolyclinicDBEntities.GetContext().Schedule.RemoveRange(schedulesForRemoving);
                        PolyclinicDBEntities.GetContext().SaveChanges();

                        //обновление таблицы
                        allSchedulesList = PolyclinicDBEntities.GetContext().Schedule.ToList();
                        UpdateTable();
                    }
                    catch
                    {
                        //сообщение об ошибке в случае ошибки обращения к БД
                        MessageWindow errorMessageWindow = new MessageWindow("Внимание!", "Ошибка обращения к базе данных!", false);
                        errorMessageWindow.ShowDialog();
                    }
                }
            }
            else
            {
                //сообщение требуещее от пользователя указать какие строки в таблице нужно удалить
                MessageWindow messageWindow = new MessageWindow("Внимание!", "Для удаления необходимо выделить строку в таблице," +
                    " для выделения нескольких: зажмите клавишу Shift.", false);
                messageWindow.ShowDialog();
            }
        }

        //Анимации
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
