using System.Windows;
using System.Windows.Controls;
using model;
using service;
using service.Interfaces;

namespace WPFApp
{
    public partial class BooksManagementPage : Page
    {
        private readonly IBookService iBookService;

        public BooksManagementPage()
        {
            InitializeComponent();
            iBookService = new BookService();
            LoadList();
        }

        private void LoadList()
        {
            lvBook.ItemsSource = iBookService.getAllBooks();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Book book = new Book();
                string title = txtTitle.Text;
                if (title == null || title == "")
                {
                    throw new Exception("Please enter a title!");
                }
                book.Title = title;

                string author = txtAuthor.Text;
                if (author == null || author == "")
                {
                    throw new Exception("Please enter an author!");
                }
                book.Author = author;

                
                try
                {
                    byte quantity;
                    try
                    {
                        quantity = byte.Parse(txtQuantity.Text);
                    }
                    catch
                    {
                        throw new Exception("Please enter quantity as an integer!");
                    }
                    if (quantity < 0)
                    {
                        throw new Exception("Please enter quantity as an non-negative integer!");
                    }
                    book.Quantity = quantity;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                Book b = iBookService.insertBook(book);
                LoadList();
                MessageBox.Show($"Insert book {b.Title} successfully!", "Insert book!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert book!");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Book book = new Book();
                try
                {
                    int id = int.Parse(txtBookId.Text);
                    book.BookId = id;
                }
                catch
                {
                    throw new Exception("Please select a book!");
                }

                string title = txtTitle.Text;
                if (title == null || title == "")
                {
                    throw new Exception("Please enter a title!");
                }
                book.Title = title;

                string author = txtAuthor.Text;
                if (author == null || author == "")
                {
                    throw new Exception("Please enter an author!");
                }
                book.Author = author;


                try
                {
                    byte quantity;
                    try
                    {
                        quantity = byte.Parse(txtQuantity.Text);
                    }
                    catch
                    {
                        throw new Exception("Please enter quantity as an integer!");
                    }
                    if (quantity < 0)
                    {
                        throw new Exception("Please enter quantity as an non-negative integer!");
                    }
                    book.Quantity = quantity;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                Book b = iBookService.updateBook(book);
                LoadList();
                MessageBox.Show($"Update book {b.Title} successfully!", "Update book!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update book!");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Book book = new Book();
                try
                {
                    int id = int.Parse(txtBookId.Text);
                    book.BookId = id;
                }
                catch
                {
                    throw new Exception("Please select a book!");
                }

                Book b = iBookService.removeBook(book);
                LoadList();
                MessageBox.Show($"Remove book {b.Title} successfully!", "Remove book!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Remove book!");
            }
        }
    }
}
