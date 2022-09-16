public class Query
{
    public Task<List<Book>> GetBooks([Service] Repository repository) =>
         repository.GetBooksAsync();

    public Task<List<Author>> GetAuthors([Service] Repository repository) =>
        repository.GetAuthors();

    public Task<Book?> GetBook([Service] Repository repository, Guid bookId) =>
        repository.GetBook(bookId);
}