public class Author
{
    public Guid Id { get; set; }
    public string? Name { get; set; }

    public Task<List<Book>> GetBooksAsync(
      [Parent]Author author, [Service] Repository repository) => repository.GetBooksByAuthor(author.Id);
}

