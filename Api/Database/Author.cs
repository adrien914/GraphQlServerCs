using System.Collections.Generic;

namespace Api.Database
{
    public class Author
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public List<Book> Books { get; set; }
        }
}
