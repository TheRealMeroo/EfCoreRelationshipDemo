namespace EfCoreRelationshipDemo.Models.OneToOne;

public class Passport
{
    public Guid Id { get; private set; }
    public string Number { get; private set; }
    public Guid PersonId { get; private set; }
    public Person Person { get; private set; }

    private Passport() { }

    internal Passport(string number, Person person)
    {
        Id = person.Id;
        Number = number;
        PersonId = person.Id;
        Person = person;
    }

    public Passport(string number, Guid personId, Person person) :
        this(number, person)
    { }
}
