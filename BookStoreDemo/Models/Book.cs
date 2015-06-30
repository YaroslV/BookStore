
namespace BookStoreDemo.Models
{
    public class Book
    {
        public Book() {}
        public  int BookId { get; set; }
        public  string BookName { get; set; }
        public  int Price { get; set; }

        public virtual Author  BookAuthor { get; set; }      

    }
}