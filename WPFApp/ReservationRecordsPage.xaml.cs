using System.Windows;
using System.Windows.Controls;
using model;
using service;
using service.Interfaces;

namespace WPFApp
{
    public partial class ReservationRecordsPage : Page
    {
        private readonly User user;
        private readonly IReservationService iReservationService;
        private readonly IBorrowService iBorrowService;

        public ReservationRecordsPage(User user)
        {
            InitializeComponent();
            this.user = user;
            iReservationService = new ReservationService();
            iBorrowService = new BorrowService();
            LoadList();
        }

        private void LoadList()
        {
            lvRecord.ItemsSource = iReservationService.getAllReservationRecordsOfUser(user);
        }

        private void btnBorrow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BorrowRecord record = new BorrowRecord();
                try
                {
                    int bookId = int.Parse(txtBookID.Text);
                    record.BookId = bookId;
                }
                catch
                {
                    throw new Exception("Please select a book!");
                }
                try
                {
                    DateTime? selectedDate = null;
                    try
                    {
                        selectedDate = txtDueDate.SelectedDate.Value;
                    }
                    catch
                    {
                        throw new Exception("Please select return date!");
                    }
                    DateOnly dueDate = DateOnly.FromDateTime((DateTime)selectedDate);
                    DateOnly today = DateOnly.FromDateTime(DateTime.Now);

                    if (dueDate.CompareTo(today) < 0)
                    {
                        throw new Exception("Please select return date not before today!");
                    }
                    record.DueDate = dueDate;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                record.UserId = user.UserId;
                BorrowRecord borrowRecord = iBorrowService.borrow(record);
                LoadList();
                MessageBox.Show($"Borrowed book {borrowRecord.Book.Title} successfully!", "Borrow book");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Borrow book");
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ReservationRecord record = new ReservationRecord();
                try
                {
                    int bookId = int.Parse(txtBookID.Text);
                    record.BookId = bookId;
                }
                catch
                {
                    throw new Exception("Please select a book!");
                }
                record.UserId = user.UserId;

                ReservationRecord reservationRecord = iReservationService.removeReservation(record);
                LoadList();
                MessageBox.Show($"Remove reservation for book {reservationRecord.Book.Title} successfully!", 
                    "Reserve book");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Reserve book");
            }
        }
    }
}
