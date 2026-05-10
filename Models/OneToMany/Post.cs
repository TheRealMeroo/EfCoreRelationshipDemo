namespace EfCoreRelationshipDemo.Models.OneToMany;

public class Post
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    public Guid BlogId { get; private set; }
    public Blog Blog { get; private set; }

    private Post() { }

    internal Post(Guid id, string title, string content, Guid blogId, Blog blog)
    {
        Id = id;
        Title = title;
        Content = content;
        BlogId = blogId;
        Blog = blog;
    }

    public Post(string title, string content, Guid blogId, Blog blog) :
        this(Guid.NewGuid(), title, content, blogId, blog)
    { }
}
