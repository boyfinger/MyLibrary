using model;

namespace service.Interfaces
{
    public interface IBorrowService
    {
        List<Book> getAllUnborrowedBookByUser(User user);

        void borrow(BorrowRecord record);
    }
}
