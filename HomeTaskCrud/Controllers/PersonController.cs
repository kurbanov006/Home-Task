using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("Person")]

public class PersonController : ControllerBase
{
    private readonly IPersonService personService = new PersonService();

    [HttpGet]
    public IEnumerable<Person> GetPersons()
    {
        return personService.GetPersons();
    }

    [HttpGet("{id}")]
    public Person? GetPerson(int id)
    {
        return personService.GetPerson(id);
    }

    [HttpPost]
    public bool CreatePerson(Person person)
    {
        return personService.CreatePerson(person);
    }

    [HttpPut]
    public bool UpdatePerson(Person person)
    {
        return personService.UpdatePerson(person);
    }

    [HttpDelete("{id}")]
    public bool DeletePersonById(int id)
    {
        return personService.DeletePersonById(id);
    }

    [HttpOptions]
    public IActionResult Options()
    {
        Response.Headers.Add("Allow", "GET, POST, PUT, DELETE, OPTIONS, PATCH");
        return Ok();
    }

    [HttpPatch]
    public bool Patch(Person person)
    {
        return personService.UpdatePerson(person);
    }
}