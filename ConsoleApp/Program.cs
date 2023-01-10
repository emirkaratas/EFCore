using ConsoleApp.DAL;
using ConsoleApp.Entities;



using (BookAppDbContext context = new BookAppDbContext())
{
    var book = new Book {
        Title = "Database Management",
        Price = 180,
        Category = context.Categories.OrderBy(c => c.CategoryId).FirstOrDefault(),
        BookDetail = new BookDetail
        {
            City = "Samsun",
            ISSN = "123-456-789"
        }
    };

    context.Books.Add(book);
    context.SaveChanges();
}

static void AddBook(Book book)
{

    using (BookAppDbContext context = new BookAppDbContext())
    {

        context.Books.Add(book);
        context.SaveChanges();
    }
}

static void ListOfBooks()
{
    var list = new List<Book>();
    using (BookAppDbContext context = new BookAppDbContext())
    {
        list = context.Books.ToList();
    }
}

static void UpdateBook()
{
    using (BookAppDbContext context = new BookAppDbContext())
    {
        var book = context.Books.OrderBy(b => b.BookId).FirstOrDefault();
        book.Title = "EFCore2";
        book.Price = 120;
        context.SaveChanges();
    }
}

static void DeleteBook()
{
    using (BookAppDbContext context = new BookAppDbContext())
    {
        var book = context.Books.OrderBy(b => b.BookId).LastOrDefault();
        context.Books.Remove(book);
        context.SaveChanges();
    }
}

static void AddBookWithCategory()
{
    var book = new Book { Title = "Spring Boot", Price = 150, Category = new Category { CategoryName = "Software" } };

    using (BookAppDbContext context = new BookAppDbContext())
    {
        context.Books.Add(book);
        context.SaveChanges();
    }
}