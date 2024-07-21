using System.Windows;
using System.Windows.Controls;
using model;
using service;
using service.Interfaces;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for BorrowPage.xaml
    /// </summary>
    public partial class BorrowPage : Page
    {
        private readonly User user;
        private readonly IBorrowService iBorrowService;
        private readonly IReservationService iReservationService;
        public BorrowPage(User user)
        {
            InitializeComponent();
            this.user = user;
            iBorrowService = new BorrowService();
            iReservationService = new ReservationService();
            LoadList();
        }

        private void LoadList()
        {
            lvBook.ItemsSource = iBorrowService.getAllUnborrowedBookByUser(user);
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
                iBorrowService.borrow(record);
                LoadList();
                MessageBox.Show("Borrowed book successfully!", "Borrow book");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Borrow book");
            }
        }

        private void btnReserve_Click(object sender, RoutedEventArgs e)
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
                iReservationService.reserve(record);
                LoadList();
                MessageBox.Show("Reserved book successfully!", "Reserve book");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Reserve book");
            }
        }
    }
}
