using System.Windows;
using System.Windows.Controls;
using model;
using service;
using service.Interfaces;

namespace WPFApp
{
    public partial class CommentsPage : Page
    {
        private readonly User user;
        private readonly ICommentService iCommentService;

        public CommentsPage(User user)
        {
            InitializeComponent();
            this.user = user;
            iCommentService = new CommentService();
            LoadList();
        }

        private void LoadList()
        {
            lvComment.ItemsSource = iCommentService.getAllCommentsOfUser(user);
        }

        private void btnComment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Comment comment = new Comment();
                try
                {
                    int bookId = int.Parse(txtBookID.Text);
                    comment.BookId = bookId;
                }
                catch
                {
                    throw new Exception("Please select a book!");
                }

                try
                {
                    string comments = txtComment.Text;
                    if (comments == "" || comments == null)
                    {
                        throw new Exception();
                    }
                    comment.Comments = comments;
                }
                catch
                {
                    throw new Exception("Please enter your comment on the book!");
                }
                try
                {
                    byte rating = byte.Parse(txtRating.Text);
                    if (rating < 0 || rating > 5)
                    {
                        throw new Exception();
                    }
                    comment.Rating = rating;
                }
                catch
                {
                    throw new Exception("Please enter your rating with a positive integer from 0-5!");
                }
                comment.UserId = user.UserId;

                Comment c = iCommentService.comment(comment);
                LoadList();
                MessageBox.Show($"Comment on book {c.Book.Title} successfully!", "Comment");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Comment");
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Comment comment = new Comment();
                try
                {
                    int bookId = int.Parse(txtBookID.Text);
                    comment.BookId = bookId;
                }
                catch
                {
                    throw new Exception("Please select a book!");
                }

                comment.UserId = user.UserId;

                Comment c = iCommentService.removeComment(comment);
                LoadList();
                MessageBox.Show($"Remove comment on book {c.Book.Title} successfully!", "Remove comment");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Remove comment");
            }
        }
    }
}
