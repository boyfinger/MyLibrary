using System.Windows;
using System.Windows.Controls;
using model;
using service;
using service.Interfaces;

namespace WPFApp
{
    public partial class BorrowRecordsPage : Page
    {
        private readonly IBorrowService iBorrowService;
        private readonly User user;

        public BorrowRecordsPage(User user)
        {
            InitializeComponent();
            iBorrowService = new BorrowService();
            this.user = user;
            LoadList();
        }

        private void LoadList()
        {
            lvRecord.ItemsSource = iBorrowService.getAllBorrowRecordsOfUser(user);
        }

        private BorrowRecord getBorrowRecordInfo()
        {
            BorrowRecord record = new BorrowRecord();
            try
            {
                int bookId = int.Parse(txtBookID.Text);
                record.BookId = bookId;
            }
            catch
            {
                throw new Exception("Please select a book to return!");
            }
            record.UserId = user.UserId;
            return record;
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BorrowRecord record = getBorrowRecordInfo();
                BorrowRecord br = iBorrowService.returnBook(record);
                LoadList();

                DateOnly today = DateOnly.FromDateTime(DateTime.Now);
                if (today.CompareTo(br.DueDate) > 0)
                {
                    MessageBox.Show("You return late!", "Return book");
                }
                else
                {
                    MessageBox.Show($"Returning book {br.Book.Title} successfully!", "Return book");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Return book");
            }
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BorrowRecord record = getBorrowRecordInfo();

                DateOnly returnDate;
                try
                {
                    returnDate = DateOnly.FromDateTime(txtDueDate.SelectedDate.Value);
                }
                catch
                {
                    throw new Exception("Please select a return date!");
                }

                DateOnly today = DateOnly.FromDateTime(DateTime.Now);
                if (today.CompareTo(returnDate) > 0)
                {
                    throw new Exception("Please select new return date not before today!");
                }

                record.DueDate = returnDate;
                BorrowRecord borrowRecord = iBorrowService.changeReturnDate(record);
                LoadList();
                MessageBox.Show($"Change return date for book {borrowRecord.Book.Title} successfully!",
                    "Change book return date");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Change book return date");
            }
        }
    }
}
