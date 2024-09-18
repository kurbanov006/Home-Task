using Dapper;
using Npgsql;





public class PersonService : IPersonService
{
    public bool CreatePerson(Person person)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.SqlConnection))
            {
                connection.Open();


                return connection.Execute(SqlCommand.SqlCreatePerson, person) > 0;
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public bool DeletePersonById(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.SqlConnection))
            {
                connection.Open();


                return connection.Execute(SqlCommand.SqlDeletePerson, new { Id = id }) > 0;
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public Person? GetPerson(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.SqlConnection))
            {
                connection.Open();

                return connection.QueryFirstOrDefault<Person>(SqlCommand.SqlGetById, new { Id = id });
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public IEnumerable<Person> GetPersons()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.SqlConnection))
            {
                connection.Open();

                return connection.Query<Person>(SqlCommand.SqlGetAllPerson);
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public bool UpdatePerson(Person person)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.SqlConnection))
            {
                connection.Open();

                return connection.Execute(SqlCommand.SqlUpdatePeron, person) > 0;
            }
        }
        catch (NpgsqlException ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }
}



file static class SqlCommand
{
    public const string SqlConnection = "Server=localhost; Port=5432; Database=personsdb; User Id=postgres; Password=12345";

    public const string SqlCreatePerson = "insert into person(id, firstname, lastname, age) values (@id, @firstname, @lastname, @age)";
    public const string SqlGetById = "select * from person where id = @Id";
    public const string SqlGetAllPerson = "select * from person";
    public const string SqlUpdatePeron = "update person set firstname=@firstname, lastname=@lastname, age=@age where id = @id";
    public const string SqlDeletePerson = "delete from person where id = @id";
}