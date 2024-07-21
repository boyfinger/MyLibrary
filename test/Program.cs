using bo;
using bo.Interface;
using dal;
using model;

User getUserByEmail(String email)
{
    var db = new LibraryContext();
    return db.Users.FirstOrDefault(user => user.Email == email);
}

IBookManagement iBookManagement = new BookManagement();
IBorrowManagement iBorrowManagement = new BorrowManagement();
List<Book> getBorrowedBookListByUser(User user)
{
    var ret = new List<Book>();
    foreach (BorrowRecord record in iBorrowManagement.getAllBorrowRecordsOfUser(user))
    {
        var book = iBookManagement.getBookById(record.BookId);
        ret.Add(book);
    }
    return ret;
}

List<Book> getAllUnborrowedBookByUser(User user)
{
    List<Book> all = iBookManagement.getAllBooks();
    List<Book> borrowed = getBorrowedBookListByUser(user);
    List<Book> ret = new List<Book>();

    foreach (Book book in all)
    {
        if (!borrowed.Contains(book))
        {
            ret.Add(book);
        }
    }
    return ret;
}

foreach (Book b in getAllUnborrowedBookByUser(getUserByEmail("jdoe@example.com")))
{
    Console.WriteLine($"{b.BookId} {b.Title} {b.Author}");
}