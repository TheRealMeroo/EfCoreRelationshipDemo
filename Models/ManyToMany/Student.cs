namespace EfCoreRelationshipDemo.Models.ManyToMany;

public class Student
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public ICollection<Enrollment> Enrollments { get; private set; } = new List<Enrollment>();

    private Student() { }

    internal Student(Guid id, string fullName, ICollection<Enrollment> enrollments)
    {
        Id = id;
        FullName = fullName;
        Enrollments = enrollments;
    }

    public Student(string fullName, ICollection<Enrollment> enrollments) :
        this(Guid.NewGuid(), fullName, enrollments)
    { }
}
