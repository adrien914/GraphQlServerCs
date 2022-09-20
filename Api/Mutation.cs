public class Mutation 
{
    public async Task<AuthorPayload> AddAuthor(AuthorInput input, [Service] Repository repository)
    {
        var author = new Author{Id=Guid.NewGuid(), Name=input.name};
        await repository.AddAuthor(author);
        return new AuthorPayload(author);
    }

    public async Task<BookPayload> AddBook(BookInput input, [Service] Repository repository)
    {
        var author = await repository.GetAuthor(input.author) ?? 
                        throw new Exception("Author not found");
        var book = new Book{Id=Guid.NewGuid(), Title=input.title, Author=author};
        await repository.AddBook(book);
        return new BookPayload(book);
    }

    public async Task<AuthorPayload> InitializeDb([Service] Repository repository)
    {
        await repository.InitializeRepo();
        return new AuthorPayload(new Author{Id=new Guid(), Name="Akira Toriyama"});
    }
}

public record BookPayload(Book? record, string? error = null);
public record BookInput(string title, Guid author);
public record AuthorPayload(Author record);
public record AuthorInput(string name);