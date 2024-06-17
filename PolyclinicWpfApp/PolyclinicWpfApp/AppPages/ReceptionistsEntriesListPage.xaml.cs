using PolyclinicWpfApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PolyclinicWpfApp.AppPages
{
    /// <summary>
    /// Логика взаимодействия для ReceptionistsEntriesListPage.xaml
    /// </summary>
    public partial class ReceptionistsEntriesListPage : Page
    {
        List<AdmissionTicket> allAdmissionTicketsList;
        Frame mainFunctionFrame;

        public ReceptionistsEntriesListPage(Frame frame)
        {
            InitializeComponent();
            allAdmissionTicketsList = PolyclinicDBEntities.GetContext().AdmissionTicket.ToList();
            mainFunctionFrame = frame;

            EntryStatePicker.SelectedIndex = 0;
        }

        public void UpdateList()
        {
            var filteredList = allAdmissionTicketsList;

            if (EntryDatePicker.SelectedDate != null)
            {
                filteredList = allAdmissionTicketsList.Where(t => t.ShortDate == EntryDatePicker.SelectedDate).ToList();
            }

            if (EntryStatePicker.SelectedIndex != -1)
            {
                if (EntryStatePicker.SelectedIndex == 0)
                    filteredList = filteredList.Where(t => t.currentStateId >= 1 || t.currentStateId <= 5).ToList();
                if (EntryStatePicker.SelectedIndex == 1)
                    filteredList = filteredList.Where(t => t.currentStateId == 2).ToList();
                if (EntryStatePicker.SelectedIndex == 2)
                    filteredList = filteredList.Where(t => t.currentStateId == 4).ToList();
                if (EntryStatePicker.SelectedIndex == 3)
                    filteredList = filteredList.Where(t => t.currentStateId == 5).ToList();
            }

            if (!String.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                filteredList = filteredList.Where(t => t.User.FullName.ToLower().Contains(SearchTextBox.Text.ToLower()) || t.User.medicalPolicy.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            }

            if (EntryDateSortComboBox.SelectedIndex != -1)
            {
                if (EntryDateSortComboBox.SelectedIndex == 0)
                    filteredList = filteredList.OrderByDescending(t => t.receiptDate).ToList();
                if (EntryDateSortComboBox.SelectedIndex == 1)
                    filteredList = filteredList.OrderBy(t => t.receiptDate).ToList();
            }

            EntriesListView.ItemsSource = filteredList;
        }

        private void EntriesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mainFunctionFrame.NavigationService.Navigate(new ReceptionistsEntryEditingPage(EntriesListView.SelectedItem as AdmissionTicket, mainFunctionFrame));
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }

        private void EntryStatePicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }

        private void EntryDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }

        private void EntryDateSortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }
    }
}
