namespace EfCoreRelationshipDemo.Models.ManyToMany;

public class Course
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public ICollection<Enrollment> Enrollments { get; private set; } = new List<Enrollment>();

    private Course() { }

    internal Course(Guid id, string title, ICollection<Enrollment> enrollments)
    {
        Id = id;
        Title = title;
        Enrollments = enrollments;
    }

    public Course(string title, ICollection<Enrollment> enrollments) :
        this(Guid.NewGuid(), title, enrollments)
    { }
}
