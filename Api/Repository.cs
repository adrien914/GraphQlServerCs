public class Repository
{
    List<Author> Authors = new List<Author>();
    List<Book> Books = new List<Book>();

    public Task<List<Book>> GetBooksAsync()
    {
        return Task.FromResult(Books);
    }

    public Task<List<Book>> GetBooksByAuthor(Guid authorId)
    {
        return Task.FromResult(Books.FindAll(book => book.Author.Id == authorId));
    }

    public Task<List<Author>> GetAuthors()
    {
        return Task.FromResult(Authors);
    }

    public Task<Book?> GetBook(Guid bookId)
    {
        return Task.FromResult(Books.FirstOrDefault(book => book.Id == bookId));
    }

    public Task<Author?> GetAuthor(Guid authorId)
    {
        return Task.FromResult( Authors.FirstOrDefault(author => author.Id == authorId));
    }

    public Task AddAuthor(Author author)
    {
        Authors.Add(author);
        return Task.CompletedTask;
    }

    public Task AddBook(Book book)
    {
        Books.Add(book);
        return Task.CompletedTask;
    }

    public Task InitializeRepo()
    {
        var authorId = new Guid();
        var author = new Author{Id=authorId, Name="Akira Toriyama"};
        Authors.Add(author);
        Books.Add(new Book{Id=new Guid(), Title="Dragon Ball", Author=author});
        Books.Add(new Book{Id=new Guid(), Title="Dragon Quest", Author=author});
        Books.Add(new Book{Id=new Guid(), Title="Dr Slump", Author=author});
        return Task.CompletedTask;
    }
}