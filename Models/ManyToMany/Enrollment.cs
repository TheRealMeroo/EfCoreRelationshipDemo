namespace EfCoreRelationshipDemo.Models.ManyToMany;

public class Enrollment
{
    public Guid StudentId { get; private set; }
    public Student Student { get; private set; }
    public Guid CourseId { get; private set; }
    public Course Course { get; private set; }
    public DateTime EnrolledOn { get; private set; }

    private Enrollment() { }

    internal Enrollment(Guid studentId, Student student, Guid courseId, Course course, DateTime enrolledOn)
    {
        StudentId = studentId;
        Student = student;
        CourseId = courseId;
        Course = course;
        EnrolledOn = enrolledOn;
    }

    public Enrollment(Student student, Course course, DateTime enrolledOn) :
        this(student.Id, student, course.Id, course, enrolledOn)
    { }

}
