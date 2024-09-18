
public interface IPersonService
{
    public bool CreatePerson(Person person);
    public bool DeletePersonById(int id);
    public bool UpdatePerson(Person person);
    public IEnumerable<Person> GetPersons();
    public Person? GetPerson(int id);
}