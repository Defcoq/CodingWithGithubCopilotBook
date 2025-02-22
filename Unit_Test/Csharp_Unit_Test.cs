public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsAvailable { get; set; } = true;
}

Service Layer:
public class LibraryService
{
    private readonly ILibraryRepository _repository;

    public LibraryService(ILibraryRepository repository)
    {
        _repository = repository;
    }

    public void AddBook(Book book)
    {
        if (book == null || string.IsNullOrWhiteSpace(book.Title))
        {
            throw new ArgumentException("Book must have a valid title.");
        }
        _repository.Add(book);
    }

    public Book FindBookByTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title cannot be empty.");
        }
        return _repository.FindByTitle(title);
    }

    public void LoanBook(int bookId)
    {
        var book = _repository.GetById(bookId);
        if (book == null || !book.IsAvailable)
        {
            throw new InvalidOperationException("Book is not available for loan.");
        }
        book.IsAvailable = false;
        _repository.Update(book);
    }

    public void ReturnBook(int bookId)
    {
        var book = _repository.GetById(bookId);
        if (book == null || book.IsAvailable)
        {
            throw new InvalidOperationException("Book is not currently on loan.");
        }
        book.IsAvailable = true;
        _repository.Update(book);
    }
}


Repository Layer:
public interface ILibraryRepository
{
    void Add(Book book);
    Book GetById(int id);
    Book FindByTitle(string title);
    void Update(Book book);
}

public class LibraryRepository : ILibraryRepository
{
    private readonly List<Book> _books = new();

    public void Add(Book book) => _books.Add(book);
    public Book GetById(int id) => _books.FirstOrDefault(b => b.Id == id);
    public Book FindByTitle(string title) => _books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    public void Update(Book book)
    {
        var existing = GetById(book.Id);
        if (existing != null)
        {
            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.IsAvailable = book.IsAvailable;
        }
    }
}



